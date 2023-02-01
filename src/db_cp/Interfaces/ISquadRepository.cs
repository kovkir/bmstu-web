using System;
using db_cp.Models;
using System.Collections.Generic;

namespace db_cp.Interfaces
{
    public interface ISquadRepository : IRepository<Squad>
    {
        Squad GetByName(string name);
        IEnumerable<Squad> GetByRating(uint rating);

        void AddSquadPlayer(int squadId, int playerId);
        void DeleteSquadPlayer(int squadId, int playerId);

        IEnumerable<SquadPlayer> GetAllSquadPlayer();
        SquadPlayer GetSquadPlayer(int squadId, int playerId);

        IEnumerable<Player> GetMyPlayersBySquadId(int squadId);
    }
}
