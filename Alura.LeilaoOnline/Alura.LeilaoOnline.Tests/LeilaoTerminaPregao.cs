using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 900, 1150, 1300, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaonessaModalidade(
        double valorDestino,
        double valorEsperado,
        double[] ofertas)
        {
            //Arrange 
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            var leilao = new Leilao("Van Gogh", modalidade);
            var teddy = new Interessada("Teddy", leilao);
            var mallu = new Interessada("Mallu", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(teddy, valor);
                }
                else
                {
                    leilao.RecebeLance(mallu, valor);
                }
            }
            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert      
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Theory]
        [InlineData(1250, new double[] { 800, 920, 1000, 1250 })]
        [InlineData(1000, new double[] { 800, 920, 1000, 980 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorLeilaoComAoMenosUmLance(
            double valorEsperado,
            double[] ofertas)
        {
            //Arrange 
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var teddy = new Interessada("Teddy", leilao);
            var mallu = new Interessada("Mallu", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(teddy, valor);
                }
                else
                {
                    leilao.RecebeLance(mallu, valor);
                }
            }
            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert         
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            //Arrange 
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //Assert      
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act
                () => leilao.TerminaPregao()
             );
            var msgEsperada = "Não é possível terminar o pregão, sem que ele tem sido iniciado!";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }

        [Fact]
        public void RetornarZeroDadoLeilaoSemLances()
        {
            //Arrange 
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            leilao.IniciaPregao();

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert      
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
