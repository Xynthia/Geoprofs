namespace GeoprofsXyn.Models
{
    public class Verlof
    {
        public int Id { get; set; }

        public ICollection<VerlofSoort> VerlofSoort { get; set; }

        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
