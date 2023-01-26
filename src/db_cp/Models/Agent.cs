using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db_cp.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
