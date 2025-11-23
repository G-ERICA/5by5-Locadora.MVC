﻿namespace Locadora.Models
{
    public class Cliente
    {
        public static readonly string INSERTCLIENTE = @"INSERT INTO tblClientes 
                                                        VALUES(@Nome, @Email, @Telefone)" 
                                                        + "SELECT SCOPE_IDENTITY()";

        public static readonly string SELECTALLCLIENTES = @"SELECT c.Nome, c.Email, c.Telefone,
                                                            d.TipoDocumento, d.Numero, d.DataEmissao, d.DataValidade
                                                            FROM tblClientes c
                                                            JOIN tblDocumentos d
                                                            ON c.ClienteID = d.ClienteID";

        public static readonly string UPDATEFONECLIENTE = @"UPDATE tblClientes
                                                            SET Telefone = @Telefone
                                                            WHERE ClienteID = @IDCliente";

        public static readonly string SELECTCLIENTEPOREMAIL = @"SELECT c.ClienteID, c.Nome, c.Email, c.Telefone,
                                                            d.TipoDocumento, d.Numero, d.DataEmissao, d.DataValidade
                                                            FROM tblClientes c
                                                            JOIN tblDocumentos d
                                                            ON c.ClienteID = d.ClienteID
                                                            WHERE Email = @Email";

        public static readonly string SELECTCLIENTEPORID = @"SELECT Nome 
                                                            FROM tblClientes 
                                                            WHERE ClienteID = @ClienteID";

        public static readonly string DELETECLIENTE = @"DELETE FROM tblClientes
                                                       WHERE ClienteID = @IDCliente";

        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; } = String.Empty;
        public Documento Documento { get; private set; }

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

        public void setDocumento(Documento documento)
        {
            Documento = documento;
        }

        public override string? ToString()
        {
            return $"Nome: {Nome} \nEmail: {Email} \nTelefone: {(Telefone == string.Empty ? "Sem Telefone" : Telefone)}\n{Documento}";
        }
    }
}