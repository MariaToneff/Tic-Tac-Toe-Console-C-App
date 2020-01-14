using System;

namespace TicTacToe.Common
{
    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage = "")
        {
            if (obj == null)
            {
                throw new NullReferenceException(errorMessage);
            }
        }
    }
}
