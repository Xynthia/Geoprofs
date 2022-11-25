namespace GeoprofsXyn.Models
{
    public class VerlofSoort
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public int VerlofId { get; set; }
        public Verlof Verlof { get; set; }
    }
}
