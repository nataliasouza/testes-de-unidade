using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClintes()
        {
            var leilao = new Leilao("Van Gogh");
            var teddy = new Interessada("Teddy", leilao);
            var mike = new Interessada("Mike", leilao);
            var nat = new Interessada("Nat", leilao);

            leilao.RecebeLance(mike, 800);
            leilao.RecebeLance(teddy, 950);
            leilao.RecebeLance(nat, 975);
            leilao.RecebeLance(teddy, 1100);

            leilao.TerminaPregao();

            var valorEsperado = 1100;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        [Fact]
        public void LeilaoComLancesOrdenadosPorValor()
        {           
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Max", leilao);
            var mallu = new Interessada("Mallu", leilao);

            leilao.RecebeLance(mallu, 700);
            leilao.RecebeLance(max, 920);
            leilao.RecebeLance(max, 980);
            leilao.RecebeLance(mallu, 1000);       

            leilao.TerminaPregao();

            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        [Fact]
        public void LeilaoComMuitosLances()
        {
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Max", leilao);
            var mallu = new Interessada("Mallu", leilao);

            leilao.RecebeLance(mallu, 700);
            leilao.RecebeLance(max, 920);
            leilao.RecebeLance(mallu, 1000);
            leilao.RecebeLance(max, 980);

            leilao.TerminaPregao();

            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
       
        [Fact]
        public void LeilaoComUmLance()
        {
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Max", leilao);

            leilao.RecebeLance(max, 700);

            leilao.TerminaPregao();

            var valorEsperado = 700;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
