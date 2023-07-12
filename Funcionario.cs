using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atividade_03
{
     public class Funcionario
    {
        //nome, e-mail, cpf. cargo, telefone, data de admissão e salário
        string nome;
        string email;
        string cpf;
        string cargo;
        string telefone;
        DateTime dataAdmissao;
        double salario;

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public DateTime DataAdmissao { get => dataAdmissao; set => dataAdmissao = value; }
        public double Salario { get => salario; set => salario = value; }
    }
}
