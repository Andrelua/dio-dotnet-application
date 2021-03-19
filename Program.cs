using System;
using System.Collections.Generic;

namespace Dio.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida!");
                        break;
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
                Console.WriteLine();
            }

            Console.WriteLine("Obrigado por usar o nossos serviços!");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindos(as) ao DIO Bank!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            Console.Write("-> ");
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }

        private static void InserirConta()
        { 
            Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
        } 

        private static void ListarContas()
        {
            Console.WriteLine("Lista de contas: ");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Sistema de saque: ");

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que vai sacar: ");
            double valorSacado = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSacado);
        }

        private static void Transferir()
        {
            Console.WriteLine("Sistema de transferência: ");

            Console.WriteLine("Digite o número da seu conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta que vai transferir: ");
            int indiceContaT = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que vai transferir: ");
            double valorTransferir = double.Parse(Console.ReadLine());

            listContas[indiceConta].Transferir(valorTransferir, listContas[indiceContaT]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Sistema de deposito: ");

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor que vai depositar: ");
            double valorDepositar = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDepositar);
        }
    }
}