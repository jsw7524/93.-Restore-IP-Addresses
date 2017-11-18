using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93.Restore_IP_Addresses
{
    public class Solution
    {
        bool IsValid(string v)
        {
            int value = -1;
            if (v.StartsWith("0")&&v.Length>1)
            {
                return false;
            }
            if (int.TryParse(v, out value))
            {
                if (value >= 0 && value <= 255)
                {
                    return true;
                }
            }
            return false;
        }
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> allIpAddresseses= new List<string>(){};
            if (s.Length < 4 || s.Length > 12)
            {
                return allIpAddresseses;
            }
            for (int i = 1; i < 4; i++)
            {
                for (int j = i + 1; j < s.Length && j-i<=3; j++)
                {
                    for (int k = j + 1; k < s.Length && j-k<=3; k++)
                    {
                        if (IsValid(s.Substring(0, i)) && IsValid(s.Substring(i, j - i)) &&
                            IsValid(s.Substring(j, k-j)) && IsValid(s.Substring(k)))
                        {
                            allIpAddresseses.Add(s.Substring(0, i)+"."+ s.Substring(i, j - i) + "." + s.Substring(j , k-j)+"."+ s.Substring(k));
                        }
                    }
                }
            }
            return allIpAddresseses;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            (new Solution()).RestoreIpAddresses("010010");
        }
    }
}
