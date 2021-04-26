using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LabOperationLibraryCore
{
    public class LabParam
    {
        public long Start { get; set; }
        public long End { get; set; }
        public string Value { get; set; }

        public bool IsPause()
        {
            return Value == "pau";
        }

        public bool IsVowel()
        {
            if (Value == "a" || Value == "A")
            {
                return true;
            }
            if (Value == "i" || Value == "I")
            {
                return true;
            }
            if (Value == "u" || Value == "U")
            {
                return true;
            }
            if (Value == "e" || Value == "E")
            {
                return true;
            }
            if (Value == "o" || Value == "O")
            {
                return true;
            }
            return false;
        }
    }
}
