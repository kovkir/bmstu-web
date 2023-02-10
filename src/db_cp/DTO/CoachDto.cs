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

    public class CoachFilterDto
    {
        public string Surname { get; set; }
        public string Country { get; set; }
        public uint? MinWorkExperience { get; set; }
        public uint? MaxWorkExperience { get; set; }
    }

    public class CoachIdDto
    {
        public int Id { get; set; }
    }
}
