namespace GeoprofsXyn.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public int userId { get; set; }
        public User User { get; set; }
    }
}
