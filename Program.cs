using System.Text;
using DesafioProjetoHospedagem.Models;
using System;
using System.Collections.Generic;

Console.OutputEncoding = Encoding.UTF8;

            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
    class Program
    {
        static void Main(string[] args)
        {
            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();

            // Cria a suíte

            string opcao = string.Empty;
            bool exibirMenu = true;
            bool cadastrado = false;

            Reserva r = new Reserva();

            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar suíte");
                Console.WriteLine("2 - Fazer reserva");
                Console.WriteLine("3 - Obter quantidade de hóspedes");
                Console.WriteLine("4 - Calcular valor da diária");
                Console.WriteLine("5 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (cadastrado == false)
                        {
                            Console.WriteLine("Digite o tipo da suíte: ");
                            string tipo = Console.ReadLine();
                            int capacity;
                            Console.WriteLine("Digite a capacidade da suíte: ");
                            while (!int.TryParse(Console.ReadLine(), out capacity))
                            {
                                Console.WriteLine("Digite um número válido para a capacidade da suíte: ");
                            }
                            decimal diaria;
                            Console.WriteLine("Digite o valor da diária: ");
                            while (!decimal.TryParse(Console.ReadLine(), out diaria))
                            {
                                Console.WriteLine("Digite um número válido para o valor da diária: ");
                            }
                            Suite suite = new Suite(tipoSuite: tipo, capacidade: capacity, valorDiaria: diaria);

                            r.CadastrarSuite(suite);
                            cadastrado = true;
                            Console.WriteLine("Cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Cadastro já efetuado!");
                        }
                        break;

                    case "2":
                        if (cadastrado == true)
                        {
                            int qntdDiarias;
                            Console.WriteLine("Digite a quantidade de diárias para a reserva: ");
                            while (!int.TryParse(Console.ReadLine(), out qntdDiarias))
                            {
                                Console.WriteLine("Digite um número válido para a quantidade de diárias para a reserva: ");
                            }
                            r.DiasReservados = qntdDiarias;
                            r.CadastrarHospedes(hospedes);
                            Console.WriteLine("Reserva feita com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Efetuar primeiro o cadastro da suite!");
                        }
                        break;

                    case "3":
                        try
                        {
                            Console.WriteLine("Existem " + r.ObterQuantidadeHospedes() + " hóspedes cadastrados!");
                            break;
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Não existem hóspedes cadastrados!");
                            break;
                        }

                    case "4":
                        try
                        {
                            Console.WriteLine("O valor da diária é de: R$ " + r.CalcularValorDiaria());

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Não existem reservas!");
                        }
                        break;

                    case "5":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione uma tecla para continuar...");
                Console.ReadLine();
            }

        }
    }