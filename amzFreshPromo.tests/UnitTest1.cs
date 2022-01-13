using amzFreshPromo;
using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace amzFreshPromo.tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestFreshPromoCase1()
        {
            string[] codeList = new string[2] {
                "apple,apple",
                "banana,anything,banana"
            };

            string[] shopCart = new string[]
            {
                "orange","apple", "apple", "banana", "orange", "banana"
            };

            int retorno = Result.foo(new List<string>(codeList), new List<string>(shopCart));

            Assert.AreEqual(1, retorno);
        }
    }
}
