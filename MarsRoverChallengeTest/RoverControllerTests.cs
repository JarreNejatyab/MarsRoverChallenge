using System;
using MarsRoverChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverChallengeTest
{
    [TestClass]
    public class RoverControllerTests
    {
        [TestMethod]
        public void TestHappyPathInstructions()
        {
            string instructions = "5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM";
            var roverController = new RoverController(instructions);
            string result = roverController.Action();
            Assert.AreEqual(
                "1 3 N\r\n5 1 E", result);
        }

        [TestMethod]
        public void TestWrongInstructions()
        {
            string instructions = "5 5\r\n1 2 N\r\nLMMMMMMMMM\r\n3 3 E\r\nMMRMMRMRRM";
            var roverController = new RoverController(instructions);
            string result = roverController.Action();
            Assert.IsTrue(result.Contains("invalid instructions"));
        }
    }
}
