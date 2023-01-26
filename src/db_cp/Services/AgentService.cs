using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Services
{
    public interface IAgentService
    {
        void Add(Agent agent);
        void Delete(Agent agent);
        void Update(Agent agent);

        IEnumerable<Agent> GetAll();
        Agent GetByID(int id);

        IEnumerable<Agent> GetBySurname(string surname);
        IEnumerable<Agent> GetByCountry(string country);
    }

    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }


        private bool IsExist(Agent agent)
        {
            return _agentRepository.GetAll().FirstOrDefault(elem =>
                    elem.Surname == agent.Surname &&
                    elem.Country == agent.Country &&
                    elem.PlayerId == agent.PlayerId) != null;
        }

        private bool IsNotExist(int id)
        {
            return _agentRepository.GetByID(id) == null;
        }

        public void Add(Agent agent)
        {
            if (IsExist(agent))
                throw new Exception("Такой агент уже существует");

            _agentRepository.Add(agent);
        }

        public void Delete(Agent agent)
        {
            if (IsNotExist(agent.Id))
                throw new Exception("Такого агента не существует");

            _agentRepository.Delete(agent.Id);
        }

        public void Update(Agent agent)
        {
            if (IsNotExist(agent.Id))
                throw new Exception("Такого агента не существует");

            _agentRepository.Update(agent);
        }

        public IEnumerable<Agent> GetAll()
        {
            return _agentRepository.GetAll();
        }

        public Agent GetByID(int id)
        {
            return _agentRepository.GetByID(id);
        }

        public IEnumerable<Agent> GetBySurname(string surname)
        {
            return _agentRepository.GetBySurname(surname);
        }

        public IEnumerable<Agent> GetByCountry(string country)
        {
            return _agentRepository.GetByCountry(country);
        }
    }
}
