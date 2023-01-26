namespace db_cp.ModelsBL
{
    public class PlayerBL
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Surname { get; set; }
        public uint Rating { get; set; }
        public string Country { get; set; }
        public uint Price { get; set; }
    }
}
