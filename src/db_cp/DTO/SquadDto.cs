using db_cp.Models;

namespace db_cp.DTO
{
    public class SquadBaseDto
    {
        public int? CoachId { get; set; }
        public string Name { get; set; }
        public uint? Rating { get; set; }
    }

    public class SquadDto: SquadBaseDto
    {
        public int Id { get; set; }
    }
}
