using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Atividade_03
{
     public class Metodos
    {
        private string dir;
        public Metodos() 
        {
            this.dir = "(0)";

            if (!Directory.Exists(this.dir))
            {
                Directory.CreateDirectory(this.dir);
            }
        }

        public void Menu()
        {
            Console.ResetColor();
            Console.WriteLine("....MENU....");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Consultar");
            Console.WriteLine(" s - Sair\n");
            Console.ResetColor();
            Console.WriteLine("Informe a operação: ");
        }

        public bool Cadastrar(Funcionario fun)
        {
            try
            {
                string str = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                    fun.Nome, fun.Email, fun.Cpf, fun.Cargo, fun.Telefone, fun.DataAdmissao, fun.Salario);

                StreamWriter sw = new StreamWriter(string.Format("(0)/{1}.txt", this.dir, this.FormatCPF(fun.Cpf)));
                sw.WriteLine(str);
                sw.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool VerificaCPFUso(string cpf)
        {
            string path = string.Format("{0}/{1}.txt", this.dir, this.FormatCPF(cpf));
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
    }
        public Funcionario Consultar(string cpf)
        {
            try
            {
                string path = string.Format("{0}/{1}.txt", this.dir, this.FormatCPF(cpf));

                StreamReader sr = new StreamReader(path);

                string data = sr.ReadLine();

                sr.Close();

                if (data != "")
                {
                    Funcionario fun = new Funcionario();

                    string[] split = data.Split('|');

                    fun.Nome = split[0];
                    fun.Email = split[1];
                    fun.Cpf = split[2];
                    fun.Cargo = split[3];
                    fun.Telefone = split[4];
                    fun.DataAdmissao = Convert.ToDateTime(split[5]);
                    fun.Salario = Convert.ToDouble(split[6]);

                    return fun;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string FormatCPF(string cpf)
        {
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            cpf.Trim();

            return cpf;

        }

        public static bool ValidarCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");
            if (valor.Length != 11)

                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "123456789")

                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(
                    valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)

                return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                     if (numeros[10] != 11 - resultado)

                return false;
            return true;
        }
    }
}
