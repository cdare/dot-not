using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Web;

namespace dot_not.Helpers
{
    public class ChallengeHelper
    {
        public static string XORHexStrings(string hex1, string hex2)
        {
            BigInteger hexFlag = BigInteger.Parse(hex1, NumberStyles.HexNumber);
            BigInteger hexKey = BigInteger.Parse(hex2, NumberStyles.HexNumber);

            BigInteger pw = hexKey ^ hexFlag;

            return pw.ToString("X");
        }
    }
}