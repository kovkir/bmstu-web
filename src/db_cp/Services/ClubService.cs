using System;
using db_cp.Models;
using db_cp.ModelsBL;
using db_cp.Enums;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Build.Tasks;
using db_cp.DTO;
using db_cp.Repository;

namespace db_cp.Services
{
    public interface IClubService
    {
        ClubBL Add(ClubBL club);
        ClubBL Delete(int id);
        ClubBL Update(ClubBL club);

        ClubBL GetByID(int id);
        ClubBL GetByName(string name);

        IEnumerable<ClubBL> GetByCountry(string country);
        IEnumerable<ClubBL> GetByFoundationDate(uint year);

        IEnumerable<ClubBL> GetAll(ClubFilterDto filter, ClubSortState? sortState);
    }

    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public ClubService(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }


        public ClubBL Add(ClubBL club)
        {
            if (IsExist(club))
                throw new Exception("Клуб с таким названием уже существует");

            return _mapper.Map<ClubBL>(_clubRepository.Add(_mapper.Map<Club>(club)));
        }

        public ClubBL Delete(int id)
        {
            return _mapper.Map<ClubBL>(_clubRepository.Delete(id));
        }

        public ClubBL Update(ClubBL club)
        {
            if (IsNotExist(club.Id))
                return null;

            if (IsExist(club))
                throw new Exception("Клуб с таким названием уже существует");

            return _mapper.Map<ClubBL>(_clubRepository.Update(_mapper.Map<Club>(club)));
        }


        public ClubBL GetByID(int id)
        {
            return _mapper.Map<ClubBL>(_clubRepository.GetByID(id));
        }

        public ClubBL GetByName(string name)
        {
            return _mapper.Map<ClubBL>(_clubRepository.GetByName(name));
        }

        public IEnumerable<ClubBL> GetByCountry(string country)
        {
            return _mapper.Map<IEnumerable<ClubBL>>(_clubRepository.GetByCountry(country));
        }

        public IEnumerable<ClubBL> GetByFoundationDate(uint year)
        {
            return _mapper.Map<IEnumerable<ClubBL>>(_clubRepository.GetByFoundationDate(year));
        }


        public IEnumerable<ClubBL> GetAll(ClubFilterDto filter, ClubSortState? sortState)
        {
            var clubs = FilterClubs(filter);

            if (sortState != null)
                clubs = SortClubsByOption(clubs, sortState.Value);
            else
                clubs = SortClubsByOption(clubs, ClubSortState.IdAsc);

            return clubs;
        }

        private IEnumerable<ClubBL> FilterClubs(ClubFilterDto filter)
        {
            var filteredClubs = _clubRepository.GetAll();

            if (filter.MinFoundationDate != null)
                filteredClubs = filteredClubs.Where(elem => elem.FoundationDate >= filter.MinFoundationDate);

            if (filter.MaxFoundationDate != null)
                filteredClubs = filteredClubs.Where(elem => elem.FoundationDate <= filter.MaxFoundationDate);

            if (!String.IsNullOrEmpty(filter.Country))
                filteredClubs = filteredClubs.Where(elem => elem.Country.Contains(filter.Country));

            if (!String.IsNullOrEmpty(filter.Name))
                filteredClubs = filteredClubs.Where(elem => elem.Name.Contains(filter.Name));

            return _mapper.Map<IEnumerable<ClubBL>>(filteredClubs);
        }

        private IEnumerable<ClubBL> SortClubsByOption(IEnumerable<ClubBL> clubs, ClubSortState sortOrder)
        {
            IEnumerable<ClubBL> sortedClubs;

            if (sortOrder == ClubSortState.IdDesc)
            {
                sortedClubs = clubs.OrderByDescending(elem => elem.Id);
            }
            else if (sortOrder == ClubSortState.FoundationDateAsc)
            {
                sortedClubs = clubs.OrderBy(elem => elem.FoundationDate);
            }
            else if (sortOrder == ClubSortState.FoundationDateDesc)
            {
                sortedClubs = clubs.OrderByDescending(elem => elem.FoundationDate);
            }
            else if (sortOrder == ClubSortState.CountryAsc)
            {
                sortedClubs = clubs.OrderBy(elem => elem.Country);
            }
            else if (sortOrder == ClubSortState.CountryDesc)
            {
                sortedClubs = clubs.OrderByDescending(elem => elem.Country);
            }
            else if (sortOrder == ClubSortState.NameAsc)
            {
                sortedClubs = clubs.OrderBy(elem => elem.Name);
            }
            else if (sortOrder == ClubSortState.NameDesc)
            {
                sortedClubs = clubs.OrderByDescending(elem => elem.Name);
            }
            else
            {
                sortedClubs = clubs.OrderBy(elem => elem.Id);
            }

            return sortedClubs;
        }


        private bool IsExist(ClubBL club)
        {
            return _clubRepository.GetAll().FirstOrDefault(elem =>
                    elem.Name == club.Name) != null;
        }

        private bool IsNotExist(int id)
        {
            return _clubRepository.GetByID(id) == null;
        }
    }
}
