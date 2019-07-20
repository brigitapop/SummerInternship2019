using MathExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathExpressionTests
{
    [TestClass]
    public class MathExpressionUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "The numbers should be positive")]
        public void Calculate_WhenNegativeNumbers_ThrowsException()
        {
            //Arange
            var math = new MathExpression();
            var numbers = new Numbers
            {
                Number1 = -1,
                Number2 = 6,
                Number3 = 10,
                Number4 = 75,
                Number5 = 100,
                Number6 = 25
            };

            //Act
            var result = math.Calculate(numbers);
        }

        [TestMethod]
        public void Calculate_WhenTheFirstTwoNumbersAreZero_TheResultIsZero()
        {
            //Arange
            var math = new MathExpression();
            var numbers = new Numbers
            {
                Number1 = 0,
                Number2 = 0,
                Number3 = 10,
                Number4 = 75,
                Number5 = 100,
                Number6 = 25
            };

            //Act
            var result = math.Calculate(numbers);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calculate_WhenTheLastTwoNumbersAreZero_TheResultIs100()
        {
            //Arange
            var math = new MathExpression();
            var numbers = new Numbers
            {
                Number1 = 10,
                Number2 = 90,
                Number3 = 10,
                Number4 = 75,
                Number5 = 0,
                Number6 = 0
            };

            //Act
            var result = math.Calculate(numbers);

            //Assert
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Calculate_WithGivenNumbers_TheResultIs71()
        {
            //Arange
            var math = new MathExpression();
            var numbers = new Numbers
            {
                Number1 = 1,
                Number2 = 6,
                Number3 = 10,
                Number4 = 75,
                Number5 = 100,
                Number6 = 25
            };

            //Act
            var result = math.Calculate(numbers);

            //Assert
            Assert.AreEqual(75, result);
        }

        [TestMethod]
        public void Calculate_WithGivenNumbers_TheResult15()
        {
            //Arange
            var math = new MathExpression();
            var numbers = new Numbers
            {
                Number1 = 1,
                Number2 = 6,
                Number3 = 10,
                Number4 = 19,
                Number5 = 75,
                Number6 = 25
            };

            //Act
            var result = math.Calculate(numbers);

            //Assert
            Assert.AreEqual(18, result);
        }
    }
}
