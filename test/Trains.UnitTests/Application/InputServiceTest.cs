using System;
using System.Linq;
using Trains.Application;
using Trains.Domain;
using Trains.Infrastructure;
using Xunit;

namespace Trains.UnitTests.Application
{
    public class InputServiceTest
    {
        public ILogger Logger;
        public InputServiceTest()
        {
            Logger = new LoggerStandardOut();
        }
        [Fact]
        public void givenAValidInputShouldReturnAValidInputObject()
        {
            // Arrange
            IInputService inputService = new InputService(Logger);

            // Act
            var input = inputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            var splitedInput = input.getSplitedInput();
            var nodes = input.getFoundNodes();

            //Assert
            Assert.IsType<Input>(input);
            Assert.Equal("AB5", splitedInput[0]);
            Assert.Equal(char.Parse("A"), nodes.First());
        }
        [Fact]
        public void givenANullInputShouldRaiseArgumentNullException()
        {
            // Arrange
            IInputService inputService = new InputService(Logger);
            string @null = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => inputService.handle(@null));
        }

        [Theory]
        [InlineData("AB5-BC4")]
        [InlineData("AB5BC4")]
        public void givenAnInvalidInputShouldRaiseFormatException(string input)
        {
            // Arrange
            IInputService inputService = new InputService(Logger);

            //Assert
            Assert.Throws<FormatException>(() => inputService.handle(input));
        }
    }
}