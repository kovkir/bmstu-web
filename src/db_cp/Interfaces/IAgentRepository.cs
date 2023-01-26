using System;
using db_cp.Models;
using System.Collections.Generic;

namespace db_cp.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        IEnumerable<Agent> GetBySurname(string surname);
        IEnumerable<Agent> GetByCountry(string country);
    }
}
