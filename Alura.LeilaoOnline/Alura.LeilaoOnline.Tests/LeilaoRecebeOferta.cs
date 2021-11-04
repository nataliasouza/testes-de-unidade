using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arrange 
            var leilao = new Leilao("Van Gogh");
            var teddy = new Interessada("Teddy", leilao);            

            leilao.IniciaPregao();
            leilao.RecebeLance(teddy, 800);         

            //Act - método sob teste
            leilao.RecebeLance(teddy, 1000);

            //Assert
            var qtdeEsperada = 1;
            var qtdeObtida = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtida);
        }
        
        [Theory]
        [InlineData(4, new double[] { 1000, 900, 1200, 777 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            var leilao = new Leilao("Van Gogh");
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
            leilao.TerminaPregao();
            
            //Act
            leilao.RecebeLance(teddy, 1000);

            //Assert
            var qtdeObtida = leilao.Lances.Count();
            Assert.Equal(qtdeEsperada, qtdeObtida);
        }
    }
}
