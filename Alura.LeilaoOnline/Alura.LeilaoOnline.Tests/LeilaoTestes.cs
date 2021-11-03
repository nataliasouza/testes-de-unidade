using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComMuitosLances()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Fulano", leilao);
            var mallu = new Interessada("Maria", leilao);

            leilao.RecebeLance(mallu, 700);
            leilao.RecebeLance(max, 920);
            leilao.RecebeLance(mallu, 1000);
            leilao.RecebeLance(max, 980);

            //ACT - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComUmLance()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var max = new Interessada("Fulano", leilao);

            leilao.RecebeLance(max, 700);

            //ACT - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 700;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
