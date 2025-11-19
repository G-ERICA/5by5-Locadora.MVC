namespace Locadora.Models
{
    public class Cliente
    {
        public static readonly string INSERTCLIENTE = "INSERT INTO tblClientes VALUES(@Nome, @Email, @Telefone) " + "SELECT SCOPE_IDENTITY()";
        public static readonly string SELECTALLCLIENTES = "SELECT * FROM tblClientes";
        public static readonly string UPDATEFONECLIENTE = "UPDATE tblClientes SET Telefone = @Telefone WHERE ClienteID = @IDCliente";
        public static readonly string SELECTCLIENTEPOREMAIL = "SELECT * FROM tblClientes WHERE Email = @Email";

        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; } = String.Empty;

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Cliente(string nome, string email, string? telefone) : this(nome, email)
        {
            Telefone = telefone;
        }

        public void setClienteId(int ClientId) 
        {
            ClienteId = ClientId;
        }
        public void setTelefone(string telefone) 
        { 
            Telefone = telefone;
        }


        public override string? ToString()
        {
            return $"Nome:{Nome} \nEmail:{Email} \nTelefone:{(Telefone == string.Empty ? " Sem Telefone" : Telefone)}\n";
        }
    }
}
