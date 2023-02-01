using System;
using db_cp.Models;
using db_cp.ModelsBL;
using db_cp.Enums;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using db_cp.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using System.Numerics;
using db_cp.Repository;

namespace db_cp.Services
{
    public interface ICoachService
    {
        CoachBL Add(CoachBL coach);
        CoachBL Delete(int id);
        CoachBL Update(CoachBL coach);

        CoachBL GetByID(int id);

        IEnumerable<CoachBL> GetBySurname(string surname);
        IEnumerable<CoachBL> GetByCountry(string country);
        IEnumerable<CoachBL> GetByWorkExperience(uint workExperience);

        IEnumerable<CoachBL> GetAll(CoachFilterDto filter, CoachSortState? sortState);
        CoachBL GetCoachBySquadId(int squadId);
    }

    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;
        private readonly ISquadRepository _squadRepository;
        private readonly IMapper _mapper;

        public CoachService(ICoachRepository coachRepository, IMapper mapper,
                            ISquadRepository squadRepository)
        {
            _coachRepository = coachRepository;
            _squadRepository = squadRepository;
            _mapper = mapper;
        }


        public CoachBL Add(CoachBL coach)
        {
            if (IsExist(coach))
                throw new Exception("Такой тренер уже существует");

            return _mapper.Map<CoachBL>(_coachRepository.Add(_mapper.Map<Coach>(coach)));
        }

        public CoachBL Delete(int id)
        {
            return _mapper.Map<CoachBL>(_coachRepository.Delete(id));
        }

        public CoachBL Update(CoachBL coach)
        {
            if (IsNotExist(coach.Id))
                return null;

            if (IsExist(coach))
                throw new Exception("Такой тренер уже существует");

            return _mapper.Map<CoachBL>(_coachRepository.Update(_mapper.Map<Coach>(coach)));
        }


        public CoachBL GetByID(int id)
        {
            return _mapper.Map<CoachBL>(_coachRepository.GetByID(id));
        }

        public IEnumerable<CoachBL> GetByCountry(string country)
        {
            return _mapper.Map<IEnumerable<CoachBL>>(_coachRepository.GetByCountry(country));
        }

        public IEnumerable<CoachBL> GetBySurname(string surname)
        {
            return _mapper.Map<IEnumerable<CoachBL>>(_coachRepository.GetBySurname(surname));
        }

        public IEnumerable<CoachBL> GetByWorkExperience(uint workExperience)
        {
            return _mapper.Map<IEnumerable<CoachBL>>(_coachRepository.GetByWorkExperience(workExperience));
        }


        public IEnumerable<CoachBL> GetAll(CoachFilterDto filter, CoachSortState? sortState)
        {
            var coaches = FilterCoaches(filter);

            if (sortState != null)
                coaches = SortCoachesByOption(coaches, sortState.Value);

            return coaches;
        }

        public CoachBL GetCoachBySquadId(int squadId)
        {
            var squad = _squadRepository.GetByID(squadId);

            if (squad != null)
                return _mapper.Map<CoachBL>(_coachRepository.GetByID(squad.CoachId));
            else
                return null;
        }


        private IEnumerable<CoachBL> FilterCoaches(CoachFilterDto filter)
        {
            var filteredCoaches = _coachRepository.GetAll();

            if (filter.MinWorkExperience != null)
                filteredCoaches = filteredCoaches.Where(elem => elem.WorkExperience >= filter.MinWorkExperience);

            if (filter.MaxWorkExperience != null)
                filteredCoaches = filteredCoaches.Where(elem => elem.WorkExperience <= filter.MaxWorkExperience);

            if (!String.IsNullOrEmpty(filter.Country))
                filteredCoaches = filteredCoaches.Where(elem => elem.Country.Contains(filter.Country));

            if (!String.IsNullOrEmpty(filter.Surname))
                filteredCoaches = filteredCoaches.Where(elem => elem.Surname.Contains(filter.Surname));

            return _mapper.Map<IEnumerable<CoachBL>>(filteredCoaches);
        }

        private IEnumerable<CoachBL> SortCoachesByOption(IEnumerable<CoachBL> coaches, CoachSortState sortOrder)
        {
            IEnumerable<CoachBL> sortedCoaches;

            if (sortOrder == CoachSortState.IdDesc)
            {
                sortedCoaches = coaches.OrderByDescending(elem => elem.Id);
            }
            else if (sortOrder == CoachSortState.SurnameAsc)
            {
                sortedCoaches = coaches.OrderBy(elem => elem.Surname);
            }
            else if (sortOrder == CoachSortState.SurnameDesc)
            {
                sortedCoaches = coaches.OrderByDescending(elem => elem.Surname);
            }
            else if (sortOrder == CoachSortState.CountryAsc)
            {
                sortedCoaches = coaches.OrderBy(elem => elem.Country);
            }
            else if (sortOrder == CoachSortState.CountryDesc)
            {
                sortedCoaches = coaches.OrderByDescending(elem => elem.Country);
            }
            else if (sortOrder == CoachSortState.WorkExperienceAsc)
            {
                sortedCoaches = coaches.OrderBy(elem => elem.WorkExperience);
            }
            else if (sortOrder == CoachSortState.WorkExperienceDesc)
            {
                sortedCoaches = coaches.OrderByDescending(elem => elem.WorkExperience);
            }
            else
            {
                sortedCoaches = coaches.OrderBy(elem => elem.Id);
            }

            return sortedCoaches;
        }


        private bool IsExist(CoachBL coach)
        {
            return _coachRepository.GetAll().FirstOrDefault(elem =>
                    elem.Surname == coach.Surname &&
                    elem.Country == coach.Country) != null;
        }

        private bool IsNotExist(int id)
        {
            return _coachRepository.GetByID(id) == null;
        }
    }
}
