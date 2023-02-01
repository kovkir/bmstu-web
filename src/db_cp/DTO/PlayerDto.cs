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

    public class PlayerFilterDto
    {
        public string ClubName { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public uint? MinPrice { get; set; }
        public uint? MaxPrice { get; set; }
        public uint? MinRating { get; set; }
        public uint? MaxRating { get; set; }
    }
}
