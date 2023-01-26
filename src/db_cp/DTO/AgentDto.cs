namespace db_cp.DTO
{
    public class AgentBaseDto
    {
        public int? PlayerId { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
    }

    public class AgentDto: AgentBaseDto
    {
        public int Id { get; set; }
    }
}
