using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public User Add(User model)
        {
            try
            {
                _appDBContext.User.Add(model);
                _appDBContext.SaveChanges();

                return GetByID(model.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Ошибка при добавлении пользователя");
            }
        }

        public User Delete(int id)
        {
            try
            {
                User user = _appDBContext.User.Find(id);

                if (user != null)
                {
                    _appDBContext.User.Remove(user);
                    _appDBContext.SaveChanges();
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Ошибка при удалении пользователя");
            }
        }

        public User Update(User model)
        {
            try
            {
                var curModel = _appDBContext.User.FirstOrDefault(elem => elem.Id == model.Id);

                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);
                _appDBContext.SaveChanges();

                return GetByID(model.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Ошибка при обновлении пользователя");
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _appDBContext.User.ToList();
        }

        public User GetByID(int id)
        {
            return _appDBContext.User.Find(id);
        }

        public User GetByLogin(string login)
        {
            return _appDBContext.User.FirstOrDefault(elem => elem.Login == login);
        }

        public IEnumerable<User> GetByPermission(string permission)
        {
            return _appDBContext.User.Where(elem => elem.Permission == permission).ToList();
        }
    }
}
