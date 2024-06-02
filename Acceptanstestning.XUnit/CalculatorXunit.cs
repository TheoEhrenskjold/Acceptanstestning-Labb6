using Xunit;

namespace Acceptanstestning_Labb6.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(10, 20, 30)] 
        [InlineData(35, 10, 45)] 
        [InlineData(2, 3,5)] 
        [InlineData(10, 2, 12)] 
        public void Calculate_WorksCorrectly(decimal num1, decimal num2, decimal expected)
        {
            var calc = new Calculator();
            decimal result = calc.Addition(num1, num2);            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Save_Try_Saving_Null()//Try saving a null value as a result to the list
        {
            var calc = new Calculator();
            calc.save(8, 0, 8, null); // Attempt to save with a null operation
            var history = calc.GetHistory();
            Assert.NotEmpty(history); 
        }

        [Fact]
        public void Division_By_Zero_Test()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Division(6, 0);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Save_Operation_History_Test()
        {
            // Arrange
            var calculator = new Calculator();
            calculator.Addition(5, 3);

            // Act
            var history = calculator.GetHistory();

            // Assert
            Assert.Single(history);
            Assert.Equal("5 + 3 = 8", history[0]);
        }
        
        [Fact]
        public void Save_Operation_History_DivideByZero()
        {
            // Arrange
            var calculator = new Calculator();
            calculator.Division(5, 0);

            // Act
            var history = calculator.GetHistory();

            // Assert
            Assert.Single(history);
            Assert.Equal("5 * 0 = 0", history[0]);
        }

        




    }
}
