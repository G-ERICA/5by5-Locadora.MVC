using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class LocacaoFuncionario
    {
        public static readonly string INSERTRELACAO = @"INSERT INTO tblLocacaoFuncionarios(LocacaoID, FuncionarioID) VALUES(@LocacaoID, @FuncionarioID)";

    }
}
