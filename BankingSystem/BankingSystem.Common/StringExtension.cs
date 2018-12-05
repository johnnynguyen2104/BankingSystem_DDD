using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.Common
{
    public static class StringExtension
    {
        public static bool IsValid(this string s)
        {
            if (!string.IsNullOrEmpty(s)
                && s.Trim().Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}
