using System;
using db_cp.Models;
using db_cp.ModelsBL;
using db_cp.Enums;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using db_cp.DTO;
using Microsoft.Build.Tasks;
using AutoMapper;
using db_cp.Repository;
using System.Numerics;
using static System.Reflection.Metadata.BlobBuilder;

namespace db_cp.Services
{
    public interface IAgentService
    {
        AgentBL Add(AgentBL agent);
        AgentBL Delete(int id);
        AgentBL Update(AgentBL agent);

        AgentBL GetByID(int id);

        IEnumerable<AgentBL> GetBySurname(string surname);
        IEnumerable<AgentBL> GetByCountry(string country);
        IEnumerable<AgentBL> GetAll(AgentSortState? sortState);
    }

    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public AgentService(IAgentRepository agentRepository,
                            IPlayerRepository playerRepository,
                            IMapper mapper)
        {
            _agentRepository = agentRepository;
            _playerRepository = playerRepository;
            _mapper = mapper;
        }


        public AgentBL Add(AgentBL agent)
        {
            if (IsExist(agent))
                throw new Exception("Такой агент уже существует");

            return _mapper.Map<AgentBL>(_agentRepository.Add(_mapper.Map<Agent>(agent)));
        }

        public AgentBL Delete(int id)
        {
            return _mapper.Map<AgentBL>(_agentRepository.Delete(id));
        }

        public AgentBL Update(AgentBL agent)
        {
            if (IsNotExist(agent.Id))
                return null;

            if (IsExist(agent))
                throw new Exception("Такой агент уже существует");

            return _mapper.Map<AgentBL>(_agentRepository.Update(_mapper.Map<Agent>(agent)));
        }


        public AgentBL GetByID(int id)
        {
            return _mapper.Map<AgentBL>(_agentRepository.GetByID(id));
        }

        public IEnumerable<AgentBL> GetBySurname(string surname)
        {
            return _mapper.Map<IEnumerable<AgentBL>>(_agentRepository.GetBySurname(surname));
        }

        public IEnumerable<AgentBL> GetByCountry(string country)
        {
            return _mapper.Map<IEnumerable<AgentBL>>(_agentRepository.GetByCountry(country));
        }


        public IEnumerable<AgentBL> GetAll(AgentSortState? sortState)
        {
            var agents = _mapper.Map<IEnumerable<AgentBL>>(_agentRepository.GetAll());

            if (sortState != null)
                agents = SortAgentsByOption(agents, sortState.Value);
            else
                agents = SortAgentsByOption(agents, AgentSortState.IdAsc);

            return agents;
        }


        private IEnumerable<AgentBL> SortAgentsByOption(IEnumerable<AgentBL> agents, AgentSortState sortOrder)
        {
            IEnumerable<AgentBL> sortedAgents;

            if (sortOrder == AgentSortState.IdDesc)
            {
                sortedAgents = agents.OrderByDescending(elem => elem.Id);
            }
            else if (sortOrder == AgentSortState.SurnameAsc)
            {
                sortedAgents = agents.OrderBy(elem => elem.Surname);
            }
            else if (sortOrder == AgentSortState.SurnameDesc)
            {
                sortedAgents = agents.OrderByDescending(elem => elem.Surname);
            }
            else if (sortOrder == AgentSortState.CountryAsc)
            {
                sortedAgents = agents.OrderBy(elem => elem.Country);
            }
            else if (sortOrder == AgentSortState.CountryDesc)
            {
                sortedAgents = agents.OrderByDescending(elem => elem.Country);
            }
            else if (sortOrder == AgentSortState.PlayerSurnameAsc)
            {
                sortedAgents = agents.OrderBy(elem => _playerRepository.GetByID(elem.PlayerId).Surname);
            }
            else if (sortOrder == AgentSortState.PlayerSurnameDesc)
            {
                sortedAgents = agents.OrderByDescending(elem => _playerRepository.GetByID(elem.PlayerId).Surname);
            }
            else
            {
                sortedAgents = agents.OrderBy(elem => elem.Id);
            }

            return sortedAgents;
        }


        private bool IsExist(AgentBL agent)
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
    }
}
