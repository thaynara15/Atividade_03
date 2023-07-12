using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Atividade_03
{
     class Program
    {
        static void Main(string[] args)
        {
            Metodos m = new Metodos();

            m.Menu();
            char opcao;
            char.TryParse(Console.ReadLine().ToUpper(), out opcao);
            Console.Clear();

            while (opcao != 'S')
            {
                switch (opcao)
                {
                    case '1':

                        Console.WriteLine("Cadastro\n");
                        Console.WriteLine("Informe o CPF: ");

                        string cpf = Console.ReadLine();
                        if (Metodos.ValidarCPF(cpf)) 
                        {
                            if (!m.VerificaCPFUso(cpf))
                            {
                                Funcionario fun = new Funcionario();
                                fun.Cpf = cpf;

                                Console.WriteLine("Informe o Nome: ");
                                fun.Nome = Console.ReadLine();

                                Console.WriteLine("Informe o Telefone: ");
                                fun.Telefone = Console.ReadLine();

                                Console.WriteLine("Informe o cargo: ");
                                fun.Cargo = Console.ReadLine();

                                Console.WriteLine("Informe o E-mail: ");
                                fun.Email = Console.ReadLine();

                                Console.WriteLine("Informe a data de admissão (dd/mm/yyyy): ");
                                DateTime dt;
                                DateTime.TryParse(Console.ReadLine(), out dt);
                                fun.DataAdmissao = dt;

                                Console.WriteLine("Informe o salário: ");
                                double salario;

                                double.TryParse(Console.ReadLine(),out salario);
                                fun.Salario = salario;

                                Console.WriteLine("\nProsseguir com o cadastro? (s/n)");

                                if (Console.ReadLine().ToUpper() == "S")
                                {
                                    if (m.Cadastrar(fun))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Funcionário cadastrado com sucesso, Precione uma tecla para retornar ao menu principal");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor= ConsoleColor.Red;
                                        Console.WriteLine("Houve um erro ao tentar castrar");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Operação cancelada, precione uma tecla para retornar ao menu principal");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Operação cancelada, o CPF informado já esrá em uso. Precione uma tecla para retornar ao menu principal");
                            }
                        }
                        else
                        {
                            Console.WriteLine("CPF inválido, operação cancelada. Precione uma tecla para retornar ao menu principal");
                        }

                        Console.ReadKey();
                        break;

                    case '2':
                        Console.WriteLine("Consultar\n");
                        Console.WriteLine("Informe o CPF: ");

                        string cpfConsulta = Console.ReadLine();
                        if (Metodos.ValidarCPF(cpfConsulta))
                        {
                            Funcionario fun = m.Consultar(cpfConsulta);
                            if (fun != null)
                            {
                                Yellow();
                                Console.Write("\nNome: ");
                                Reset();
                                Console.Write(fun.Nome);

                                Yellow();
                                Console.Write("\nCPF: ");
                                Reset();
                                Console.Write(fun.Cpf);

                                Yellow();
                                Console.Write("\nE-mail: ");
                                Reset();
                                Console.Write(fun.Email);

                                Yellow();
                                Console.Write("\nCargo: ");
                                Reset();
                                Console.Write(fun.Cargo);

                                Yellow();
                                Console.Write("\nTelefone: ");
                                Reset();
                                Console.Write(fun.Telefone);

                                Yellow();
                                Console.Write("\nAdmissão: ");
                                Reset();
                                Console.Write(fun.DataAdmissao.ToShortDateString());

                                Yellow();
                                Console.Write("\nSalario: ");
                                Reset();
                                Console.Write(fun.Salario.ToString("n2"));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Não há registro de um funcionário com o CPF informado");
                            }
                        }
                        else
                        {
                            Console.WriteLine("CPF inválido, operaçaõ cancelada");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine((opcao == 'S' ? "" : "Operação inválida, pressione uma tecla para continuar"));
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
                m.Menu();
                char.TryParse(Console.ReadLine().ToUpper(), out opcao);
                Console.Clear();
            }
        }

        static void Yellow()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
        }

        static void Reset()
        {
            Console.ResetColor();
        }

    }
}
