using Tokenypto.Api.Entities;

namespace Tokenypto.Api.UnitTests
{
    public class CurrencyTests
    {
        [Fact]
        public void GetFromCode_NotExistingCurrencyCode_Should_ThrowApplicationException()
        {
            // Arrange
            string code = "Wrong";
            // Act and Assert
            Assert.Throws<ApplicationException>(() => Currency.FromCode(code));
        }
    }
}
