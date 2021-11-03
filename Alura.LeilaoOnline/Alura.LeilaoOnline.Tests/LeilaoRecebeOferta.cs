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
        [Theory]
        [InlineData(4, new double[] { 800, 900, 1200, 777 })]
        [InlineData(2, new double[] { 800,900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            var leilao = new Leilao("Van Gogh");
            var mallu = new Interessada("Mallu", leilao);
           
            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(mallu, valor);
            }
            leilao.TerminaPregao();

            leilao.RecebeLance(mallu, 1000);

            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtida);
        }
    }
}
