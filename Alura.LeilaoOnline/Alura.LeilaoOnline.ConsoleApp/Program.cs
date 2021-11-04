using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou! Esperado:{esperado}, obtido: {obtido}");
            }
            Console.ForegroundColor = cor;
        }
        private static void LeilaoComMuitosLances()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Max", leilao);
            var mallu = new Interessada("Mallu", leilao);

            leilao.RecebeLance(mallu, 700);
            leilao.RecebeLance(max, 920);
            leilao.RecebeLance(mallu, 1000);
            leilao.RecebeLance(max, 980);

            //ACT - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }

        private static void LeilaoComUmLance()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Max", leilao);
      
            leilao.RecebeLance(max, 700);

            //ACT - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);
        }
        static void Main(string[] args)
        {
            LeilaoComMuitosLances();
            LeilaoComUmLance();
        }
    }
}
