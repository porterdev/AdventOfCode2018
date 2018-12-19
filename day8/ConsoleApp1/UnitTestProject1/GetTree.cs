using System.Collections.Generic;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetTree
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = new List<int> { 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2 };

            /*
                2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2
                A----------------------------------
                    B----------- C-----------
                                     D-----
                In this example, each node of the tree is also marked with an underline starting with a letter for easier identification. In it, there are four nodes:

                A, which has 2 child nodes (B, C) and 3 metadata entries (1, 1, 2).
                B, which has 0 child nodes and 3 metadata entries (10, 11, 12).
                C, which has 1 child node (D) and 1 metadata entry (2).
                D, which has 0 child nodes and 1 metadata entry (99).
             */

            var index = 0;
            var result = Functions.GetTree(input, ref index);

            Assert.IsNotNull(result);
            Assert.AreEqual(16, index);

            //Node A
            Assert.AreEqual(2, result.Children.Count);
            Assert.AreEqual(3, result.MetaData.Count);
            Assert.AreEqual(1, result.MetaData[0]);
            Assert.AreEqual(1, result.MetaData[1]);
            Assert.AreEqual(2, result.MetaData[2]);

            //Node B
            var b = result.Children[0];
            Assert.AreEqual(0, b.Children.Count);
            Assert.AreEqual(3, b.MetaData.Count);
            Assert.AreEqual(10, b.MetaData[0]);
            Assert.AreEqual(11, b.MetaData[1]);
            Assert.AreEqual(12, b.MetaData[2]);

            //Node C
            var c = result.Children[1];
            Assert.AreEqual(1, c.Children.Count);
            Assert.AreEqual(1, c.MetaData.Count);
            Assert.AreEqual(2, c.MetaData[0]);

            //Node D
            var d = c.Children[0];
            Assert.AreEqual(0, d.Children.Count);
            Assert.AreEqual(1, d.MetaData.Count);
            Assert.AreEqual(99, d.MetaData[0]);
        }
    }
}
