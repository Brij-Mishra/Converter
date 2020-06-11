using Converter;
using System;
using Xunit;

namespace ConverterUnitTests
{
  public class StringnDecimalShould
  {
    private StringnDecimal stringnDecimal = new StringnDecimal();

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    public void ThrowsAnExceptionIfStringIsNullOrEmpty(string input)
    {
      Assert.Throws<ArgumentNullException>(() => stringnDecimal.StringToIntParser(input));
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("456-23")]
    public void ThrowsAnExceptionIfStringIsIncorrectFormat(string input)
    {
      Assert.Throws<ArgumentException>(() => stringnDecimal.StringToIntParser(input));
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("6745", 6745)]
    [InlineData("-6745", -6745)]
    [InlineData("+8746", 8746)]
    [InlineData("+2147483647", int.MaxValue)]
    [InlineData("-2147483648", int.MinValue)]
    public void ReturnsCorrectInteger(string input, int expected)
    {
      long result = stringnDecimal.StringToIntParser(input);
      Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData(123, "123")]
    [InlineData(6745, "6745")]
    [InlineData(-6745, "-6745")]
    [InlineData(8746, "8746")]
    [InlineData(int.MaxValue, "2147483647")]
    [InlineData(int.MinValue, "-2147483648")]
    public void ReturnsCorrectString(int input, string expected)
    {
      string result = stringnDecimal.IntToStringParser(input);
      Assert.Equal(result, expected);
    }

  }
}
