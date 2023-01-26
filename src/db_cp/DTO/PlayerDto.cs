namespace db_cp.DTO
{
    public class PlayerBaseDto
    {
        public int? ClubId { get; set; }
        public string Surname { get; set; }
        public uint? Rating { get; set; }
        public string Country { get; set; }
        public uint? Price { get; set; }
    }

    public class PlayerDto: PlayerBaseDto
    {
        public int Id { get; set; }
    }
}
