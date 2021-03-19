using System;

namespace Dio.bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta("André Luan", 0, 0, TipoConta.PessoaFisica);
            Console.WriteLine(conta1.ToString());
        }
    }
}
