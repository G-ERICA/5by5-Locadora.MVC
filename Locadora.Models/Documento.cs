using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Documento
    {
        public int DocumentoId { get; private set; }
        public int ClientId { get; private set; }
        public string TipoDocumento { get; private set; }

        public string Numero { get; private set; }
        public DateOnly DataEmissao { get; private set; }
        public DateOnly DataValidade { get; private set; }

        public Documento(int clientId, string tipoDocumento, string numero, DateOnly dataEmissao, DateOnly dataValidade)
        {
            ClientId = clientId;
            TipoDocumento = tipoDocumento;
            Numero = numero;
            DataEmissao = dataEmissao;
            DataValidade = dataValidade;
        }

        public override string? ToString()
        {
            return $"Tipo Documento{TipoDocumento} \nNumero:{Numero} \nData Emissão:{DataEmissao} \nData Validade:{DataValidade}\n";
        }
    }
}
