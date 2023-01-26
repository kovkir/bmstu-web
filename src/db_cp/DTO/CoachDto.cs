namespace db_cp.DTO
{
    public class CoachBaseDto
    {
        public string Surname { get; set; }
        public string Country { get; set; }
        public uint? WorkExperience { get; set; }
    }

    public class CoachDto: CoachBaseDto
    {
        public int Id { get; set; }
    }
}
