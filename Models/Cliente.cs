namespace ClienteProjectDapper.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
    }
}
