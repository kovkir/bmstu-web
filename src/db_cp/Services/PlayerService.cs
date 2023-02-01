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
using Microsoft.Build.Tasks;

namespace db_cp.Services
{
    public interface IPlayerService
    {
        PlayerBL Add(PlayerBL player);
        PlayerBL Delete(int id);
        PlayerBL Update(PlayerBL player);

        PlayerBL GetByID(int id);

        IEnumerable<PlayerBL> GetBySurname(string surname);
        IEnumerable<PlayerBL> GetByRating(uint rating);
        IEnumerable<PlayerBL> GetByCountry(string country);
        IEnumerable<PlayerBL> GetByPrice(uint minPrice, uint maxPrice);
        IEnumerable<PlayerBL> GetByClubName(string clubName);

        IEnumerable<PlayerBL> GetAll(PlayerFilterDto filter, PlayerSortState? sortState);
        IEnumerable<PlayerBL> GetPlayersBySquadId(int squadId, PlayerFilterDto filter, PlayerSortState? sortState);
    }

    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IClubRepository _clubRepository;
        private readonly ISquadRepository _squadRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository,
                             IClubRepository clubRepository,
                             ISquadRepository squadRepository,
                             IMapper mapper)
        {
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
            _squadRepository = squadRepository;
            _mapper = mapper;
        }


        public PlayerBL Add(PlayerBL player)
        {
            if (IsExist(player))
                throw new Exception("Такой футболист уже существует");

            return _mapper.Map<PlayerBL>(_playerRepository.Add(_mapper.Map<Player>(player)));
        }

        public PlayerBL Delete(int id)
        {
            return _mapper.Map<PlayerBL>(_playerRepository.Delete(id));
        }

        public PlayerBL Update(PlayerBL player)
        {
            if (IsNotExist(player.Id))
                return null;

            if (IsExist(player))
                throw new Exception("Такой футболист уже существует");

            return _mapper.Map<PlayerBL>(_playerRepository.Update(_mapper.Map<Player>(player)));
        }


        public PlayerBL GetByID(int id)
        {
            return _mapper.Map<PlayerBL>(_playerRepository.GetByID(id));
        }

        public IEnumerable<PlayerBL> GetByCountry(string country)
        {
            return _mapper.Map<IEnumerable<PlayerBL>>(_playerRepository.GetByCountry(country));
        }

        public IEnumerable<PlayerBL> GetByPrice(uint minPrice, uint maxPrice)
        {
            return _mapper.Map<IEnumerable<PlayerBL>>(_playerRepository.GetByPrice(minPrice, maxPrice));
        }

        public IEnumerable<PlayerBL> GetByRating(uint rating)
        {
            return _mapper.Map<IEnumerable<PlayerBL>>(_playerRepository.GetByRating(rating));
        }

        public IEnumerable<PlayerBL> GetBySurname(string surname)
        {
            return _mapper.Map<IEnumerable<PlayerBL>>(_playerRepository.GetBySurname(surname));
        }

        public IEnumerable<PlayerBL> GetByClubName(string clubName)
        {
            Club club = _clubRepository.GetByName(clubName);

            if (club == null)
                return Enumerable.Empty<PlayerBL>();
            else
                return _mapper.Map<IEnumerable<PlayerBL>>(_playerRepository.GetAll().Where(elem => elem.ClubId == club.Id));
        }

        public IEnumerable<PlayerBL> GetAll(PlayerFilterDto filter, PlayerSortState? sortState)
        {
            var players = _mapper.Map<IEnumerable<PlayerBL>>(_playerRepository.GetAll());

            players = FilterPlayers(players, filter);

            if (sortState != null)
                players = SortPlayersByOption(players, sortState.Value);

            return players;
        }

        public IEnumerable<PlayerBL> GetPlayersBySquadId(int squadId, PlayerFilterDto filter, PlayerSortState? sortState)
        {
            var players = _mapper.Map<IEnumerable<PlayerBL>>(_squadRepository.GetMyPlayersBySquadId(squadId));

            players = FilterPlayers(players, filter);

            if (sortState != null)
                players = SortPlayersByOption(players, sortState.Value);

            return players;
        }


        private IEnumerable<PlayerBL> FilterPlayers(IEnumerable<PlayerBL> players, PlayerFilterDto filter)
        {
            var filteredPlayers = players;

            if (filter.MinPrice != null)
                filteredPlayers = filteredPlayers.Where(elem => elem.Price >= filter.MinPrice);

            if (filter.MaxPrice != null)
                filteredPlayers = filteredPlayers.Where(elem => elem.Price <= filter.MaxPrice);

            if (filter.MinRating != null)
                filteredPlayers = filteredPlayers.Where(elem => elem.Rating >= filter.MinRating);

            if (filter.MaxRating != null)
                filteredPlayers = filteredPlayers.Where(elem => elem.Rating <= filter.MaxRating);

            if (!String.IsNullOrEmpty(filter.Country))
                filteredPlayers = filteredPlayers.Where(elem => elem.Country.Contains(filter.Country));

            if (!String.IsNullOrEmpty(filter.Surname))
                filteredPlayers = filteredPlayers.Where(elem => elem.Surname.Contains(filter.Surname));

            if (!String.IsNullOrEmpty(filter.ClubName))
            {
                Club club = _clubRepository.GetByName(filter.ClubName);

                if (club == null)
                    filteredPlayers = Enumerable.Empty<PlayerBL>();
                else
                    filteredPlayers = filteredPlayers.Where(elem => elem.ClubId == club.Id);
            }

            return filteredPlayers;
        }

        private IEnumerable<PlayerBL> SortPlayersByOption(IEnumerable<PlayerBL> players, PlayerSortState sortOrder)
        {
            IEnumerable<PlayerBL> sortedPlayers;

            if (sortOrder == PlayerSortState.IdDesc)
            {
                sortedPlayers = players.OrderByDescending(elem => elem.Id);
            }
            else if (sortOrder == PlayerSortState.SurnameAsc)
            {
                sortedPlayers = players.OrderBy(elem => elem.Surname);
            }
            else if (sortOrder == PlayerSortState.SurnameDesc)
            {
                sortedPlayers = players.OrderByDescending(elem => elem.Surname);
            }
            else if (sortOrder == PlayerSortState.CountryAsc)
            {
                sortedPlayers = players.OrderBy(elem => elem.Country);
            }
            else if (sortOrder == PlayerSortState.CountryDesc)
            {
                sortedPlayers = players.OrderByDescending(elem => elem.Country);
            }
            else if (sortOrder == PlayerSortState.RatingAsc)
            {
                sortedPlayers = players.OrderBy(elem => elem.Rating);
            }
            else if (sortOrder == PlayerSortState.RatingDesc)
            {
                sortedPlayers = players.OrderByDescending(elem => elem.Rating);
            }
            else if (sortOrder == PlayerSortState.PriceAsc)
            {
                sortedPlayers = players.OrderBy(elem => elem.Price);
            }
            else if (sortOrder == PlayerSortState.PriceDesc)
            {
                sortedPlayers = players.OrderByDescending(elem => elem.Price);
            }
            else if (sortOrder == PlayerSortState.ClubNameAsc)
            {
                sortedPlayers = players.OrderBy(elem => _clubRepository.GetByID(elem.ClubId).Name);
            }
            else if (sortOrder == PlayerSortState.ClubNameDesc)
            {
                sortedPlayers = players.OrderByDescending(elem => _clubRepository.GetByID(elem.ClubId).Name);
            }
            else
            {
                sortedPlayers = players.OrderBy(elem => elem.Id);
            }

            return sortedPlayers;
        }


        private bool IsExist(PlayerBL player)
        {
            return _playerRepository.GetAll().FirstOrDefault(elem =>
                    elem.Surname == player.Surname &&
                    elem.ClubId == player.ClubId &&
                    elem.Country == player.Country &&
                    elem.Rating == player.Rating) != null;
        }

        private bool IsNotExist(int id)
        {
            return _playerRepository.GetByID(id) == null;
        }
    }
}
