using Workshop;

namespace WorkshopTests
{
    public class StringCaluclatorTests
    {
        [Fact]
        public void EmptyStringsReturnZero()
        {
            int result = StringCaluclator.Calculate("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(2,"2")]
        [InlineData(303,"303")]
        [InlineData(20,"20")]
        public void CountExampleString(int expectedResult, string str)
        {
            int result = StringCaluclator.Calculate(str);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData( "40,5",45)]
        public void TwoNumbersWithCommaSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCaluclator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("40\n5", 45)]
        [InlineData("4\n5", 9)]
        [InlineData("1\n1", 2)]
        [InlineData("0\n5", 5)]
        public void TwoNumbersWithNewlineSeparatorReturnsSum(string str, int expected)
        {
            int result = StringCaluclator.Calculate(str);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("40\n5000", 40)]
        [InlineData("4\n1001,5", 9)]
        [InlineData("4\n1000,5", 1009)]
        [InlineData("1000", 1000)]
        [InlineData("5000", 0)]
        public void NumbersGreaterThanTousandAreIgnored(string str, int expected)
        {
            int result = StringCaluclator.Calculate(str);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-5000")]
        [InlineData("4\n-1001,5")]
        [InlineData("-4\n1000,5")]
        public void NegativeNumbersThrowException(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCaluclator.Calculate(str));
        }


        [Theory]
        [InlineData("//X\n40X5000", 40)]
        [InlineData("//A\n4\n1001A5", 9)]
        [InlineData("//$\n4$1000,5", 1009)]
        [InlineData("//$\n4", 4)]
        [InlineData("// \n4 7", 11)]
        public void CustomSerpartorOnTheBegginingOfTHeString(string str, int expected)
        {
            int result = StringCaluclator.Calculate(str);
            Assert.Equal(expected, result);
        }

    }
}