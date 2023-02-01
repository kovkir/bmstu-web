namespace db_cp.DTO
{
    public class SquadPlayerBaseDto
    {
        public int? SquadId { get; set; }
        public int? PlayerId { get; set; }
    }

    public class SquadPlayerDto : SquadPlayerBaseDto
    {
        public int Id { get; set; }
    }
}
