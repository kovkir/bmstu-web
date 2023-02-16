using System;
using db_cp.Models;
using db_cp.ModelsBL;
using db_cp.Enums;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using db_cp.DTO;
using db_cp.Repository;

namespace db_cp.Services
{
    public interface IUserService
    {
        UserBL Add(UserBL user);
        UserBL Delete(int id);
        UserBL Update(UserBL user);

        UserBL GetByID(int id);
        UserBL GetByLogin(string login);
        UserBL Login(LoginDto loginDto);

        IEnumerable<UserBL> GetByPermission(string permission);
        IEnumerable<UserBL> GetAll(UserSortState? sortState);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISquadRepository _squadRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           ISquadRepository squadRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _squadRepository = squadRepository;
            _mapper = mapper;
        }


        public UserBL Add(UserBL user)
        {
            if (IsExist(user))
                throw new Exception("Пользователь с таким логином уже существует");

            return _mapper.Map<UserBL>(_userRepository.Add(_mapper.Map<User>(user)));

        }

        public UserBL Delete(int id)
        {
            return _mapper.Map<UserBL>(_userRepository.Delete(id));
        }

        public UserBL Update(UserBL user)
        {
            if (IsNotExist(user.Id))
                return null;

            // if (IsExist(user))
            //     throw new Exception("Пользователь с таким логином уже существует");

            return _mapper.Map<UserBL>(_userRepository.Update(_mapper.Map<User>(user)));
        }


        public UserBL GetByID(int id)
        {
            return _mapper.Map<UserBL>(_userRepository.GetByID(id));
        }

        public UserBL GetByLogin(string login)
        {
            return _mapper.Map<UserBL>(_userRepository.GetByLogin(login));
        }

        public UserBL Login(LoginDto loginDto)
        {
            UserBL user = GetByLogin(loginDto.Login);

            if (user == null)
                return null;

            if (user.Password == loginDto.Password)
                return user;
            else
                return null;
        }

        public IEnumerable<UserBL> GetByPermission(string permission)
        {
            return _mapper.Map<IEnumerable<UserBL>>(_userRepository.GetByPermission(permission));
        }

        public IEnumerable<UserBL> GetAll(UserSortState? sortState)
        {
            var users = _mapper.Map<IEnumerable<UserBL>>(_userRepository.GetAll());

            if (sortState != null)
                users = SortUsersByOption(users, sortState.Value);
            else
                users = SortUsersByOption(users, UserSortState.IdAsc);

            return users;
        }


        private IEnumerable<UserBL> SortUsersByOption(IEnumerable<UserBL> users, UserSortState sortOrder)
        {
            IEnumerable<UserBL> sortedUsers;

            if (sortOrder == UserSortState.IdDesc)
            {
                sortedUsers = users.OrderByDescending(elem => elem.Id);
            }
            else if (sortOrder == UserSortState.LoginAsc)
            {
                sortedUsers = users.OrderBy(elem => elem.Login);
            }
            else if (sortOrder == UserSortState.LoginDesc)
            {
                sortedUsers = users.OrderByDescending(elem => elem.Login);
            }
            else if (sortOrder == UserSortState.PermissionAsc)
            {
                sortedUsers = users.OrderBy(elem => elem.Permission);
            }
            else if (sortOrder == UserSortState.PermissionDesc)
            {
                sortedUsers = users.OrderByDescending(elem => elem.Permission);
            }
            else if (sortOrder == UserSortState.RatingSquadAsc)
            {
                sortedUsers = users.OrderBy(elem => _squadRepository.GetByID(elem.Id).Rating);
            }
            else if (sortOrder == UserSortState.RatingSquadDesc)
            {
                sortedUsers = users.OrderByDescending(elem => _squadRepository.GetByID(elem.Id).Rating);
            }
            else
            {
                sortedUsers = users.OrderBy(elem => elem.Id);
            }

            return sortedUsers;
        }


        private bool IsExist(UserBL user)
        {
            return _userRepository.GetAll().FirstOrDefault(elem =>
                    elem.Login == user.Login) != null;
        }

        private bool IsNotExist(int id)
        {
            return _userRepository.GetByID(id) == null;
        }
    }
}
