using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CountDuplicateClaims
    {
        [TestMethod]
        public void Test1()
        {
            /*
                #1 @ 1,3: 4x4
                #2 @ 3,1: 4x4
                #3 @ 5,5: 2x2

                ........
                ...2222.
                ...2222.
                .11XX22.
                .11XX22.
                .111133.
                .111133.
                ........

                i.e. 4 duplicate claims
            */

            var claims = new List<Claim>
            {
                new Claim
                {
                    Id = 1,
                    X = 1,
                    Y = 3,
                    Height = 4,
                    Width = 4
                },
                new Claim
                {
                    Id = 2,
                    X = 3,
                    Y = 1,
                    Height = 4,
                    Width = 4
                },
                new Claim
                {
                    Id = 3,
                    X = 5,
                    Y = 5,
                    Height = 2,
                    Width = 2
                }
            };
            var result = Functions.CountDuplicateClaims(claims);

            Assert.AreEqual(4, result);
        }
    }
}
