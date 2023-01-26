using System;
using db_cp.Models;
using db_cp.ModelsBL;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using db_cp.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;

namespace db_cp.Services
{
    public interface ICoachService
    {
        void Add(Coach coach);
        void Delete(Coach coach);
        void Update(Coach coach);

        IEnumerable<Coach> GetAll();
        Coach GetByID(int id);

        IEnumerable<Coach> GetBySurname(string surname);
        IEnumerable<Coach> GetByCountry(string country);
        IEnumerable<Coach> GetByWorkExperience(uint workExperience);
        IEnumerable<Coach> GetByParameters(string surname, string country,
                                           uint minWorkExperience, uint maxWorkExperience);

        IEnumerable<Coach> GetSortCoachesByOrder(IEnumerable<Coach> coaches, CoachSortState sortOrder);

        IEnumerable<CoachBL> GetAllCoaches(CoachBaseDto filter, CoachSortState? sortState);
    }

    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;
        private readonly IMapper _mapper;

        public CoachService(ICoachRepository coachRepository, IMapper mapper)
        {
            _coachRepository = coachRepository;
            _mapper = mapper;
        }


        private bool IsExist(Coach coach)
        {
            return _coachRepository.GetAll().FirstOrDefault(elem =>
                    elem.Surname == coach.Surname &&
                    elem.Country == coach.Country) != null;
        }

        private bool IsNotExist(int id)
        {
            return _coachRepository.GetByID(id) == null;
        }

        public void Add(Coach coach)
        {
            if (IsExist(coach))
                throw new Exception("Такой тренер уже существует");

            _coachRepository.Add(coach);
        }

        public void Delete(Coach coach)
        {
            if (IsNotExist(coach.Id))
                throw new Exception("Такого тренера не существует");

            _coachRepository.Delete(coach.Id);
        }

        public IEnumerable<Coach> GetAll()
        {
            return _coachRepository.GetAll();
        }

        public IEnumerable<Coach> GetByCountry(string country)
        {
            return _coachRepository.GetByCountry(country);
        }

        public Coach GetByID(int id)
        {
            return _coachRepository.GetByID(id);
        }

        public IEnumerable<Coach> GetBySurname(string surname)
        {
            return _coachRepository.GetBySurname(surname);
        }

        public IEnumerable<Coach> GetByWorkExperience(uint workExperience)
        {
            return _coachRepository.GetByWorkExperience(workExperience);
        }

        public void Update(Coach coach)
        {
            if (IsNotExist(coach.Id))
                throw new Exception("Такого тренера не существует");

            _coachRepository.Update(coach);
        }

      
        public IEnumerable<Coach> GetSortCoachesByOrder(IEnumerable<Coach> coaches, CoachSortState sortOrder)
        {
            IEnumerable<Coach> needCoaches = sortOrder switch
            {
                CoachSortState.IdDesc => coaches.OrderByDescending(elem => elem.Id),

                CoachSortState.SurnameAsc => coaches.OrderBy(elem => elem.Surname),
                CoachSortState.SurnameDesc => coaches.OrderByDescending(elem => elem.Surname),

                CoachSortState.CountryAsc => coaches.OrderBy(elem => elem.Country),
                CoachSortState.CountryDesc => coaches.OrderByDescending(elem => elem.Country),

                CoachSortState.WorkExperienceAsc => coaches.OrderBy(elem => elem.WorkExperience),
                CoachSortState.WorkExperienceDesc => coaches.OrderByDescending(elem => elem.WorkExperience),

                _ => coaches.OrderBy(elem => elem.Id)
            };

            return needCoaches;
        }


        public IEnumerable<Coach> GetByParameters(string surname, string country,
                                                  uint minWorkExperience, uint maxWorkExperience)
        {
            IEnumerable<Coach> coaches = _coachRepository.GetAll();

            if (coaches.Count() != 0 && surname != null)
                coaches = coaches.Where(elem => elem.Surname == surname);

            if (coaches.Count() != 0 && country != null)
                coaches = coaches.Where(elem => elem.Country == country);

            if (coaches.Count() != 0 && minWorkExperience != 0)
                coaches = coaches.Where(elem => elem.WorkExperience >= minWorkExperience);

            if (coaches.Count() != 0 && maxWorkExperience != 0)
                coaches = coaches.Where(elem => elem.WorkExperience <= maxWorkExperience);

            return coaches;
        }


        private IEnumerable<CoachBL> FilterCoaches(IEnumerable<CoachBL> coaches, CoachBaseDto filter)
        {
            var filteredCoaches = coaches;

            if (filter.WorkExperience != null)
                filteredCoaches = filteredCoaches.Where(s => s.WorkExperience == filter.WorkExperience);

            if (!String.IsNullOrEmpty(filter.Country))
                filteredCoaches = filteredCoaches.Where(s => s.Country.Contains(filter.Country));

            if (!String.IsNullOrEmpty(filter.Surname))
                filteredCoaches = filteredCoaches.Where(s => s.Surname.Contains(filter.Surname));

            return filteredCoaches;
        }

        private IEnumerable<CoachBL> SortCoachesByOption(IEnumerable<CoachBL> coaches, CoachSortState sortOrder)
        {
            IEnumerable<CoachBL> sortedServers;

            if (sortOrder == CoachSortState.IdDesc)
            {
                sortedServers = coaches.OrderByDescending(s => s.Surname);
            }
            else if (sortOrder == CoachSortState.SurnameAsc)
            {
                sortedServers = coaches.OrderBy(s => s.Surname);
            }
            else if (sortOrder == CoachSortState.SurnameDesc)
            {
                sortedServers = coaches.OrderByDescending(s => s.Surname);
            }
            else if (sortOrder == CoachSortState.CountryAsc)
            {
                sortedServers = coaches.OrderBy(s => s.Country);
            }
            else if (sortOrder == CoachSortState.CountryDesc)
            {
                sortedServers = coaches.OrderByDescending(s => s.Country);
            }
            else if (sortOrder == CoachSortState.WorkExperienceAsc)
            {
                sortedServers = coaches.OrderBy(s => s.WorkExperience);
            }
            else if (sortOrder == CoachSortState.WorkExperienceDesc)
            {
                sortedServers = coaches.OrderByDescending(s => s.WorkExperience);
            }
            else
            {
                sortedServers = coaches.OrderBy(s => s.Id);
            }

            return sortedServers;
        }


        public IEnumerable<CoachBL> GetAllCoaches(CoachBaseDto filter, CoachSortState? sortState)
        {
            var coaches = _mapper.Map<IEnumerable<CoachBL>>(_coachRepository.GetAll());

            coaches = FilterCoaches(coaches, filter);

            if (sortState != null)
                coaches = SortCoachesByOption(coaches, sortState.Value);

            return coaches;
        }
    }
}
