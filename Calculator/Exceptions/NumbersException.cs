﻿using Calculator.Constants;

namespace Calculator.Exceptions
{
    public class NumbersException : Exception
    {
        public NumbersException(string errorType, List<int> invalidNumbers)
            : base(GetErrorMessage(errorType, invalidNumbers))
        {

        }

        private static string GetErrorMessage(string errorType, List<int> invalidNumbers)
        {
            switch (errorType)
            {
                case ErrorTypes.NegativeNumbers:
                    return string.Format($"Negatives Are Not Allowed : {string.Join(", ", invalidNumbers)}");

                case ErrorTypes.NumbersGreaterThan1000:
                    return string.Format($"The following numbers were greater than 1000 : {string.Join(", ", invalidNumbers)}");

                default:
                    return "An unknown error occurred.";
            }
        }
    }
}
