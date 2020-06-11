using System;
using System.Text;

namespace Converter
{
  public class StringnDecimal
  {
    public long StringToIntParser(string input)
    {
      if(string.IsNullOrWhiteSpace(input))
      {
        throw new ArgumentNullException("Input string is null or empty.");
      }

      int signMultiplier = +1;

      long result = 0;

      char[] inputArray = input.ToCharArray();

      for (int i = 0; i < inputArray.Length; i++)
      {
        int asciiVal = (int)inputArray[i];

        if(i == 0 && asciiVal == 45)
        {
          signMultiplier = -1;
          continue;
        }

        if (i == 0 && asciiVal == 43)
        {
          continue;
        }

        if (asciiVal < 48 || asciiVal > 57)
        {
          throw new ArgumentException("Input string is not in correct format.");
        }

        result = result * 10 + (asciiVal - '0');
      }

      return signMultiplier * result;
    }

    public string IntToStringParser(int input)
    {
      StringBuilder sb = new StringBuilder();

      long temp = input;
      if (input < 0)
      {
        temp = (-1) * temp;
      }

      while(temp > 0)
      {
        long num = temp % 10;
        temp = temp / 10;
        sb.Insert(0, num);
      }

      return input < 0? "-" + sb.ToString() : sb.ToString();
    }
  }
}
