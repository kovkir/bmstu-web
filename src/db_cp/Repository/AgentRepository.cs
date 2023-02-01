using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDBContext _appDBContext;

        public AgentRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Agent Add(Agent model)
        {
            try
            {
                _appDBContext.Agent.Add(model);
                _appDBContext.SaveChanges();

                return GetByID(model.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Ошибка при добавлении агента");
            }
        }

        public Agent Delete(int id)
        {
            try
            {
                Agent agent = _appDBContext.Agent.Find(id);

                if (agent != null)
                {
                    _appDBContext.Agent.Remove(agent);
                    _appDBContext.SaveChanges();
                }

                return agent;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Ошибка при удалении агента");
            }
        }

        public Agent Update(Agent model)
        {
            try
            {
                var curModel = _appDBContext.Agent.FirstOrDefault(elem => elem.Id == model.Id);

                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);
                _appDBContext.SaveChanges();

                return GetByID(model.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Ошибка при обновлении агента");
            }
        }


        public IEnumerable<Agent> GetAll()
        {
            return _appDBContext.Agent.ToList();
        }

        public IEnumerable<Agent> GetByCountry(string country)
        {
            return _appDBContext.Agent.Where(elem => elem.Country == country).ToList();
        }

        public Agent GetByID(int id)
        {
            return _appDBContext.Agent.Find(id);
        }

        public IEnumerable<Agent> GetBySurname(string surname)
        {
            return _appDBContext.Agent.Where(elem => elem.Surname == surname).ToList();
        }
    }
}
