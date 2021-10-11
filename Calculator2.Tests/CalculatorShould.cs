using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorShould
    {
        Calculator sut = new Calculator();

        [Theory]
        [InlineData(4)]
        [InlineData(1)]
        [InlineData(-1)]
        public void AddCorrectlyWithSingleValue(double value)
        {
            double startValue = 4;
            sut.currentValue = startValue;
            sut.Addition(value);
            Assert.Equal(startValue + value, sut.currentValue);
        }

        [Theory]
        [InlineData(new double[] { 3, 1, 2 })]
        [InlineData(new double[] { 3, double.NaN, 2 })]
        public void AddCorrectlyWithManyValues(double[] values)
        {
            double addingValue = 0;
            double startValue = 23;
            sut.currentValue = startValue;

            foreach (double value in values)
            {
                if (!double.IsNaN(value))
                {
                    addingValue += value;
                }
            }

            sut.Addition(values);
            Assert.Equal(startValue + addingValue, sut.currentValue);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(139)]
        public void SubtractCorrectlyWithSingleValue(double value)
        {
            double startValue = 11;
            sut.currentValue = startValue;
            sut.Subtraction(value);
            Assert.Equal(startValue - value, sut.currentValue);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(139)]
        public void MultiplyCorrectly(double value)
        {
            double startValue = 32;
            sut.currentValue = startValue;
            sut.Multiplication(value);
            Assert.Equal(startValue * value, sut.currentValue);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void DivideCorrectly(double value)
        {
            double startValue = 12;
            sut.currentValue = startValue;
            sut.Division(value);
            Assert.Equal(startValue / value, sut.currentValue);
        }

        [Fact]
        public void DivideByZeroDoesNotEffectValue()
        {
            double startValue = 12;
            sut.currentValue = startValue;
            sut.Division(0);
            Assert.Equal(startValue, sut.currentValue);
        }

        [Fact]
        public void ValidInputReturnsValidResult()
        {
            double result = sut.ConvertUserInputSingle("4");
            Assert.Equal(4, result);
        }

        [Fact]
        public void InvalidInputReturnsNaN()
        {
            double result = sut.ConvertUserInputSingle("q2we");
            Assert.Equal(double.NaN, result);
        }

        [Fact]
        public void ResetCorrectly()
        {
            sut.currentValue = 123;
            sut.Reset();

            Assert.Equal(0, sut.currentValue);
        }

        [Fact]
        public void ConvertUserInputToArrayCorrectly()
        {
            double[] actual = sut.ConvertUserInputArray("1 2 3");
            double[] result = new double[] { 1, 2, 3 };

            Assert.Equal(result, actual);
        }

        [Fact]
        public void ConvertUserInputToArrayWithInvalidInput()
        {
            double[] actual = sut.ConvertUserInputArray("1 qw 3");
            double[] result = new double[] { 1, double.NaN, 3 };

            Assert.Equal(result, actual);
        }
    }
}