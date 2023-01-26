namespace db_cp.DTO
{
    public class ClubBaseDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public uint? FoundationDate { get; set; }
    }

    public class ClubDto: ClubBaseDto
    {
        public int Id { get; set; }
    }
}
