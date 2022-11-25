namespace GeoprofsXyn.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public int VerlofUren { get; set; }

        public ICollection<Verlof> Verlof { get; set; }
        public ICollection<Team> Team { get; set; }
        public ICollection<Rol> Rol { get; set; }
    }
}
