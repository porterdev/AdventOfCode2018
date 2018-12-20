using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GameSetupTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "10 players; last marble is worth 1618 points";

            var result = new GameSetup(input);

            Assert.AreEqual(10, result.Players);
            Assert.AreEqual(1618, result.Points);

            input = "13 players; last marble is worth 7999 points";

            result = new GameSetup(input);

            Assert.AreEqual(13, result.Players);
            Assert.AreEqual(7999, result.Points);

            input = "17 players; last marble is worth 1104 points";

            result = new GameSetup(input);

            Assert.AreEqual(17, result.Players);
            Assert.AreEqual(1104, result.Points);

            input = "21 players; last marble is worth 6111 points";

            result = new GameSetup(input);

            Assert.AreEqual(21, result.Players);
            Assert.AreEqual(6111, result.Points);

            input = "30 players; last marble is worth 5807 points";

            result = new GameSetup(input);

            Assert.AreEqual(30, result.Players);
            Assert.AreEqual(5807, result.Points);
        }
    }
}
