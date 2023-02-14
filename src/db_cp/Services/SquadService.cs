using System;
using db_cp.Models;
using db_cp.ModelsBL;
using db_cp.Enums;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using db_cp.Repository;
using db_cp.DTO;

namespace db_cp.Services
{
    public interface ISquadService
    {
        SquadBL Add(SquadBL squad);
        SquadBL Delete(int id);
        SquadBL Update(SquadBL squad);

        SquadBL GetByID(int id);
        SquadBL GetByName(string name);
        SquadPlayerBL GetSquadPlayer(int squadId, int playerId);

        IEnumerable<SquadBL> GetByRating(uint rating);
        IEnumerable<SquadBL> GetAll(SquadSortState? sortOrder);

        void DeleteSquadPlayersByPlayerId(int playerId);
        void DeleteSquadPlayersBySquadId(int squadId);

        IEnumerable<PlayerBL> GetMyPlayersBySquadId(int squadId);
        IEnumerable<PlayerBL> GetMyPlayersByUserLogin(string userLogin);
        int GetMyCoachIdByUserLogin(string userLogin);

        SquadBL AddPlayerToMySquad(int squadId, int playerId);
        SquadBL AddCoachToMySquad(int squadId, int coachId);
        SquadBL DeletePlayerFromMySquad(int squadId, int playerId);
        SquadBL DeleteCoachFromMySquad(int squadId, int coachId);
    }

    public class SquadService : ISquadService
    {
        private readonly ISquadRepository _squadRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SquadService(ISquadRepository squadRepository,
                            ICoachRepository coachRepository,
                            IUserRepository userRepository,
                            IMapper mapper)
        {
            _squadRepository = squadRepository;
            _coachRepository = coachRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public SquadBL Add(SquadBL squad)
        {
            if (IsExist(squad))
                throw new Exception("Состав с таким названием уже существует");

            return _mapper.Map<SquadBL>(_squadRepository.Add(_mapper.Map<Squad>(squad)));
        }

        public SquadBL Delete(int id)
        {
            return _mapper.Map<SquadBL>(_squadRepository.Delete(id));
        }

        public SquadBL Update(SquadBL squad)
        {
            if (IsNotExist(squad.Id))
                return null;

            if (IsExist(squad))
                throw new Exception("Состав с таким названием уже существует");

            return _mapper.Map<SquadBL>(_squadRepository.Update(_mapper.Map<Squad>(squad)));
        }


        public SquadBL GetByID(int id)
        {
            return _mapper.Map<SquadBL>(_squadRepository.GetByID(id));
        }
        
        public SquadBL GetByName(string name)
        {
            return _mapper.Map<SquadBL>(_squadRepository.GetByName(name));
        }

        public SquadPlayerBL GetSquadPlayer(int squadId, int playerId)
        {
            return _mapper.Map<SquadPlayerBL>(_squadRepository.GetSquadPlayer(squadId, playerId));
        }

        public IEnumerable<SquadBL> GetByRating(uint rating)
        {
            return _mapper.Map<IEnumerable<SquadBL>>(_squadRepository.GetByRating(rating));
        }

        public IEnumerable<SquadBL> GetAll(SquadSortState? sortState)
        {
            var squads = _mapper.Map<IEnumerable<SquadBL>>(_squadRepository.GetAll());

            if (sortState != null)
                squads = SortSquadsByOption(squads, sortState.Value);

            return squads;
        }


        private IEnumerable<SquadBL> SortSquadsByOption(IEnumerable<SquadBL> squads, SquadSortState sortOrder)
        {
            IEnumerable<SquadBL> sortedSquads;

            if (sortOrder == SquadSortState.IdDesc)
            {
                sortedSquads = squads.OrderByDescending(elem => elem.Id);
            }
            else if (sortOrder == SquadSortState.NameAsc)
            {
                sortedSquads = squads.OrderBy(elem => elem.Name);
            }
            else if (sortOrder == SquadSortState.NameDesc)
            {
                sortedSquads = squads.OrderByDescending(elem => elem.Name);
            }
            else if (sortOrder == SquadSortState.RatingAsc)
            {
                sortedSquads = squads.OrderBy(elem => elem.Rating);
            }
            else if (sortOrder == SquadSortState.RatingDesc)
            {
                sortedSquads = squads.OrderByDescending(elem => elem.Rating);
            }
            else if (sortOrder == SquadSortState.CoachSurnameAsc)
            {
                sortedSquads = squads.OrderBy(elem => _coachRepository.GetByID(elem.CoachId).Surname);
            }
            else if (sortOrder == SquadSortState.CoachSurnameDesc)
            {
                sortedSquads = squads.OrderByDescending(elem => _coachRepository.GetByID(elem.CoachId).Surname);
            }
            else
            {
                sortedSquads = squads.OrderBy(elem => elem.Id);
            }

            return sortedSquads;
        }


        private bool IsExist(SquadBL squad)
        {
            return _squadRepository.GetAll().FirstOrDefault(elem =>
                    elem.Name == squad.Name) != null;
        }

        private bool IsNotExist(int id)
        {
            return _squadRepository.GetByID(id) == null;
        }


        public void DeleteSquadPlayersByPlayerId(int playerId)
        {
            var squadPlayerList = _squadRepository.GetAllSquadPlayer()
                .Where(elem => elem.PlayerId == playerId);

            foreach (SquadPlayer elem in squadPlayerList)
            {
                DeletePlayerFromMySquad(elem.SquadId, playerId);
            }
        }

        public void DeleteSquadPlayersBySquadId(int squadId)
        {
            var squadPlayerList = _squadRepository.GetAllSquadPlayer()
                .Where(elem => elem.SquadId == squadId);

            foreach (SquadPlayer elem in squadPlayerList)
            {
                DeletePlayerFromMySquad(squadId, elem.PlayerId);
            }
        }


        public IEnumerable<PlayerBL> GetMyPlayersBySquadId(int squadId)
        {
            return _mapper.Map<IEnumerable<PlayerBL>>(_squadRepository.GetMyPlayersBySquadId(squadId));
        }

        public IEnumerable<PlayerBL> GetMyPlayersByUserLogin(string userLogin)
        {
            User user = _userRepository.GetByLogin(userLogin);
            IEnumerable<Player> myPlayers;

            if (user == null)
                myPlayers = Enumerable.Empty<Player>();
            else
                myPlayers = _squadRepository.GetMyPlayersBySquadId(user.Id);

            return _mapper.Map<IEnumerable<PlayerBL>>(myPlayers);
        }

        public int GetMyCoachIdByUserLogin(string userLogin)
        {
            User user = _userRepository.GetByLogin(userLogin);
            int myCoachId;

            if (user == null)
                myCoachId = 0;
            else
                myCoachId = _squadRepository.GetByID(user.Id).CoachId;
                
            return myCoachId;
        }


        public SquadBL AddPlayerToMySquad(int squadId, int playerId)
        {
            if (SquadPlayerIsExist(squadId, playerId))
                throw new Exception("Данный футболист уже добавлен в состав");

            _squadRepository.AddSquadPlayer(squadId, playerId);

            return UpdateMySquadRating(squadId);
        }

        public SquadBL AddCoachToMySquad(int squadId, int coachId)
        {
            Squad squad = _squadRepository.GetByID(squadId);

            if (squad == null)
                throw new Exception("Такого состава не существует");

            squad.CoachId = coachId;

            return _mapper.Map<SquadBL>(_squadRepository.Update(squad));
        }

        public SquadBL DeletePlayerFromMySquad(int squadId, int playerId)
        {
            if (SquadPlayerIsNotExist(squadId, playerId))
                throw new Exception("Такого футболиста в составе нет");

            _squadRepository.DeleteSquadPlayer(squadId, playerId);

            return UpdateMySquadRating(squadId);
        }

        public SquadBL DeleteCoachFromMySquad(int squadId, int coachId)
        {
            Squad squad = _squadRepository.GetByID(squadId);

            if (squad == null)
                throw new Exception("Такого состава не существует");

            squad.CoachId = 0;

            return _mapper.Map<SquadBL>(_squadRepository.Update(squad));
        }


        private uint SumRating(IEnumerable<Player> players)
        {
            uint sumRating = 0;

            foreach (Player player in players)
                sumRating += player.Rating;

            return sumRating;
        }

        private SquadBL UpdateMySquadRating(int squadId)
        {
            Squad squad = _squadRepository.GetByID(squadId);
            IEnumerable<Player> players = _squadRepository.GetMyPlayersBySquadId(squadId);

            int numbPlayers = players.Count();
            uint newRating = 0;

            if (numbPlayers > 0)
                newRating = (uint)(SumRating(players) / numbPlayers);

            squad.Rating = newRating;

            return _mapper.Map<SquadBL>(_squadRepository.Update(squad));
        }


        private bool SquadPlayerIsExist(int squadId, int playerId)
        {
            return _squadRepository.GetAllSquadPlayer().FirstOrDefault(elem =>
                    elem.SquadId == squadId &&
                    elem.PlayerId == playerId) != null;
        }

        private bool SquadPlayerIsNotExist(int squadId, int playerId)
        {
            return _squadRepository.GetSquadPlayer(squadId, playerId) == null;
        }
    }
}
