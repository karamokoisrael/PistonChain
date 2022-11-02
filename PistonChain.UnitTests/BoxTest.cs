using Xunit;
using PistonChain.Models.Piston;

namespace PistonChain.UnitTests.BoxTest
{
    public class BoxTest
    {
        [Fact]
        public void GetPieces_ReturnsSuffledListOfPieces()
        {
            //Arrange
            var box = new Box();

            //Act
            var pieces = box.GetPieces();
            
            //Assert
            Assert.NotEmpty(pieces);
        }
    }
}
