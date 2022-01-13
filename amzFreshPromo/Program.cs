using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace amzFreshPromo
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("F:\\Makenchi's Dungeon\\Projetos\\Visual Studio\\amzSuggestions\\amzFreshPromo\\files\\fresh.txt", true);

            int codeListCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> codeList = new List<string>();

            for (int i = 0; i < codeListCount; i++)
            {
                string codeListItem = Console.ReadLine();
                codeList.Add(codeListItem);
            }

            int shoppingCartCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> shoppingCart = new List<string>();

            for (int i = 0; i < shoppingCartCount; i++)
            {
                string shoppingCartItem = Console.ReadLine();
                shoppingCart.Add(shoppingCartItem);
            }

            int result = Result.foo(codeList, shoppingCart);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

    public class Result
    {

        /*
         * Complete the 'foo' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING_ARRAY codeList
         *  2. STRING_ARRAY shoppingCart
         */

        public static int foo(List<string> codeList, List<string> shoppingCart)
        {
            List<string> mappedCodeList = codeList.Select((item) => item.Replace("anything", "(.*)")).ToList();
            string cartHash = String.Join(",", shoppingCart.ToArray());

            int lastIndex = -1;
            foreach (string code in mappedCodeList)
            {
                Match m = Regex.Match(cartHash, code);

                if (!m.Success || (lastIndex != -1 && m.Index < lastIndex))
                {
                    return 0;
                }

                lastIndex = m.Index;
            }

            return 1;
        }

    }    
}
