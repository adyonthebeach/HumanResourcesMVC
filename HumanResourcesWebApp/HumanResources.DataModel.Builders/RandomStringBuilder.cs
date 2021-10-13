using System;
using System.Text;

namespace HumanResources.DataModel.Builders
{
    public class RandomStringBuilder
    {
        private int _stringLength;

        public RandomStringBuilder SetMaxLength(int maxLength)
        {
            Random random = new Random();

            _stringLength = random.Next(1, maxLength);

            return this;
        }

        public string Build()
        {
            StringBuilder strbuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < _stringLength; i++)
            {
                double randomDouble = random.NextDouble();
                char myChar = ConvertDoubleToChar(randomDouble);
                strbuilder.Append(myChar);
            }

            return strbuilder.ToString();
        }

        /// <summary>
        /// Character creation from a double code example sourced from
        /// https://www.techieclues.com/blogs
        /// </summary>
        /// <param name="randomDouble"></param>
        /// <returns>A single character</returns>
        private char ConvertDoubleToChar(double randomDouble)
        {
            return Convert.ToChar(Convert.ToInt32(Math.Floor(25 * randomDouble) + 65));
        }
    }
}
