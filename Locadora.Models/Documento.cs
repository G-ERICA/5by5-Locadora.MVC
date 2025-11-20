using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Documento
    {
        public static readonly string INSERTDOCUMENTO = @"INSERT INTO tblDocumentos (ClienteId, TipoDocumento, Numero, DataEmissao, DataValidade) 
                                                        VALUES(@ClienteId, @TipoDocumento, @Numero, @DataEmissao, @DataValidade) ";

        public static readonly string UPDATEDOCUMENTO = @"UPDATE tblDocumentos
                                                        SET TipoDocumento = @TipoDocumento,
                                                        Numero = @Numero,
                                                        DataEmissao = @DataEmissao,
                                                        DataValidade = @DataValidade
                                                        WHERE ClienteID = @IdCliente";
        
        public static readonly string SELECTDOCUMENTO = @"SELECT * FROM tblDocumentos
                                                        WHERE DocumentoId = @DocumentoId";

        public int DocumentoId { get; private set; }
        public int ClienteId { get; private set; }
        public string TipoDocumento { get; private set; }

        public string Numero { get; private set; }
        public DateOnly DataEmissao { get; private set; }
        public DateOnly DataValidade { get; private set; }

        public Documento(string tipoDocumento, string numero, DateOnly dataEmissao, DateOnly dataValidade)
        {
            TipoDocumento = tipoDocumento;
            Numero = numero;
            DataEmissao = dataEmissao;
            DataValidade = dataValidade;
        }

        public void SetClienteId(int clienteId)
        {
            ClienteId = clienteId;
        }

        public override string? ToString()
        {
            return $"Tipo Documento: {TipoDocumento} \nNumero: {Numero} \nData Emissão: {DataEmissao} \nData Validade: {DataValidade}\n";
        }
    }
}
