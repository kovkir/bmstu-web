//using System;
//using db_cp.Models;
//using db_cp.Interfaces;
//using System.Collections.Generic;
//using System.Linq;

//namespace db_cp.Mocks
//{
//    public class AgentMock : DataMock, IAgentRepository
//    {
//        public void Add(Agent model)
//        {
//            _agents.Add(model);
//        }

//        public void Delete(int id)
//        {
//            Agent agent = _agents[id - 1];
//            _agents.Remove(agent);
//        }

//        public IEnumerable<Agent> GetAll()
//        {
//            return _agents;
//        }

//        public IEnumerable<Agent> GetByCountry(string country)
//        {
//            return _agents.Where(elem => elem.Country == country);
//        }

//        public Agent GetByID(int id)
//        {
//            return _agents[id - 1];
//        }

//        public IEnumerable<Agent> GetBySurname(string surname)
//        {
//            return _agents.Where(elem => elem.Surname == surname);
//        }

//        public void Update(Agent model)
//        {
//            Agent agent = _agents[model.Id - 1];

//            agent.PlayerId = model.PlayerId;
//            agent.Surname = model.Surname;
//            agent.Country = model.Country;

//            _agents[agent.Id - 1] = agent;
//        }
//    }
//}
