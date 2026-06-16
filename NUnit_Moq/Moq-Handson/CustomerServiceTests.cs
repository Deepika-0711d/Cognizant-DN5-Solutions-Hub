using Moq;
using NUnit.Framework;

namespace MoqHandson
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void GetCustomer_Test()
        {
            // Arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo
                .Setup(r => r.GetCustomerName(1))
                .Returns("Deepika");

            var service = new CustomerService(mockRepo.Object);

            // Act
            string result = service.GetCustomer(1);

            // Assert
            Assert.That(result, Is.EqualTo("Deepika"));
        }
    }
}