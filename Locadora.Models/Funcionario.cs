using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public decimal Salario { get; private set; }
        public Funcionario(string nome, string cpf, string email, decimal salario)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Salario = salario;
        }
        public void SetFuncionarioID(int funcionarioID)
        {
            FuncionarioID = funcionarioID;
        }
        public override string? ToString()
        {
            return $"Nome: {Nome}\nCPF: {CPF}\nEmail: {Email}\nSalario: {Salario}";
        }
    }
}
