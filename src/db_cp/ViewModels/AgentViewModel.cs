using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using db_cp.Models;

namespace db_cp.ViewModels
{
    public class AgentViewModel
    {
        public IEnumerable<Agent>  agents { get; set; }
        public IEnumerable<Player> players { get; set; }
    }
}
