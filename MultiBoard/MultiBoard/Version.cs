using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoard
{
    public static class Version
    {
        /// <summary>
        /// Is version older than
        /// </summary>
        /// <param name="ver1"></param>
        /// <param name="ver2"></param>
        /// <returns>returns True if ver1 is older</returns>
        public static bool IsVersionOlder(string ver1, string ver2)
        {
            int[] version1 = DecodeVersion(ver1);
            int[] version2 = DecodeVersion(ver2);
            if (version1.Length == version2.Length)
            {
                for (int i = 0; i < version1.Length; i++)
                {
                    if (version2[i] > version1[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static int[] DecodeVersion(string ver)
        {
            ver = ver.Replace("v", "");
            string versionNumbers = ver.Split('-')[0];
            string[] split = versionNumbers.Split('.');

            List<int> numbers = new List<int>();
            foreach (string s in split)
            { 
                int n;
                if (Int32.TryParse(s, out n))
                {
                    numbers.Add(n);
                }
                else
                {
                    throw new ArgumentException("Version number not valid");
                }
            }

            return numbers.ToArray();
        }

        public static bool IsBetaVersion(string ver)
        {
            return ver.Contains("beta");
        }
    }
}
