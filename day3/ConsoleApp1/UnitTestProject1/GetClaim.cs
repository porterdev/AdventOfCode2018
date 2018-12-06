using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetClaim
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = Functions.GetClaim("#1 @ 1,3: 4x5");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.X);
            Assert.AreEqual(3, result.Y);
            Assert.AreEqual(4, result.Width);
            Assert.AreEqual(5, result.Height);

            result = Functions.GetClaim("#2 @ 3,1: 5x4");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(1, result.Y);
            Assert.AreEqual(5, result.Width);
            Assert.AreEqual(4, result.Height);
        }
    }
}
