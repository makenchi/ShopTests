using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amzSuggestions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("F:\\Makenchi's Dungeon\\Projetos\\Visual Studio\\amzSuggestions\\files\\sugestions.txt", true);            

            int repositoryCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> repository = new List<string>();

            for (int i = 0; i < repositoryCount; i++)
            {
                string repositoryItem = Console.ReadLine();
                repository.Add(repositoryItem);
            }

            string customerQuery = Console.ReadLine();

            List<List<string>> result = Result.searchSuggestions(repository, customerQuery);

            textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

            textWriter.Flush();
            textWriter.Close();
        }

        public int Suggest(int repoCount, List<string> itens, string sugestion)
        {
            try
            {
                TextWriter textWriter = new StreamWriter("F:\\Makenchi's Dungeon\\Projetos\\Visual Studio\\amzSuggestions\\files\\sugestions.txt", true);

                int repositoryCount = repoCount;

                List<string> repository = new List<string>();

                for (int i = 0; i < repositoryCount; i++)
                {
                    string repositoryItem = itens[i];
                    repository.Add(repositoryItem);
                }

                string customerQuery = sugestion;

                List<List<string>> result = Result.searchSuggestions(repository, customerQuery);

                textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

                textWriter.Flush();
                textWriter.Close();

                return 0;
            }
            catch (Exception err)
            {

                return 1;
            }

        }
    }

    public class Result
    {

        /*
         * Complete the 'searchSuggestions' function below.
         *
         * The function is expected to return a 2D_STRING_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY repository
         *  2. STRING customerQuery
         */

        public static List<List<string>> searchSuggestions(List<string> repository, string customerQuery)
        {
            List<List<string>> suggestions = new List<List<string>>();
            int sugLine = 0;
            string query = customerQuery.Substring(0, 2);
            List<string> availableRepositories = repository
              .Where((string item) => item.Contains(query))
              .OrderBy((string item) => item)
              .ToList();

            for (int i = 1; i < customerQuery.Length; i++)
            {
                suggestions.Add(new List<string>());
                query = customerQuery.Substring(0, i + 1);

                availableRepositories.ForEach(delegate (string item) {
                    if (item.Contains(query) && suggestions[sugLine].Count <= 2)
                    {
                        suggestions[sugLine].Add(item.ToLower());
                    }
                });
                
                sugLine++;
            }

            return suggestions;
        }

    }
}
