using ExemplosOrientacaoObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExemplosOrientacaoTests
{
    public class ConverterTests
    {
        [Fact]
        public void TestConverter()
        {
            // Arrange
            var conversor = new ConverterParaCaracter();

            // Act
            var act = () => conversor.Converter(122);

            // Assert
            var exception = Assert.Throws<Exception>(act);

            Assert.Equal("O número inserido não pode ser maior que 122", exception.Message);
        }
    }
}
