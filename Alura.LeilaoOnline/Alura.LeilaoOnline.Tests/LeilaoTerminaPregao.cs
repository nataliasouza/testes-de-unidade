using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {               
        [Theory]
        [InlineData(1250, new double[] { 800, 920, 1000, 1250})]
        [InlineData(1000, new double[] { 800, 920, 1000, 980 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorLeilaoComAoMenosUmLance(
            double valorEsperado,
            double[]ofertas)
        {
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Max", leilao);

            leilao.IniciaPregao();           
            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(max, valor);
            }

            leilao.TerminaPregao();
         
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornarZeroDadoLeilaoSemLances()
        {
            var leilao = new Leilao("Van Gogh");                

            leilao.TerminaPregao();

            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
