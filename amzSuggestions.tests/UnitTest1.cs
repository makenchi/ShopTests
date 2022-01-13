using NUnit.Framework;
using System.Collections.Generic;

namespace amzSuggestions.tests
{
    [TestFixture]
    public class UnitTest1
    {
        Program _program;

        [SetUp]
        public void SetUp()
        {
            _program = new Program();
        }

        [Test]
        public void TestSuggestion()
        {            
            List<string> repo = new List<string>();
            repo.Add("mobile");
            repo.Add("mouse");
            repo.Add("moneypot");
            repo.Add("monitor");
            repo.Add("mousepad");

            string suggestion = "mouse";
            List<List<string>> expectedResult = new List<List<string>>()
            {
                new List<string>(){"mobile","moneypot", "monitor"},
                new List<string>(){"mouse","mousepad"},
                new List<string>(){"mouse","mousepad"},
                new List<string>(){"mouse","mousepad"},
            };

            List<List<string>> retorno = Result.searchSuggestions(repo, suggestion);

            NUnit.Framework.Assert.That(retorno, Is.EqualTo(expectedResult));

            Assert.IsTrue(true, "deu bom?");
        }
    }
}
