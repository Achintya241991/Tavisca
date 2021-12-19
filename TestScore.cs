using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingScoreTest
{
    [TestClass]
    public class TestScore
    {

        // No test cases written for input validations. So only one method is exposed in the service interface to calculate score.
        // Assumptions that its 10 frames with 10th frame has 3 chance for the user to roll a ball.

        [TestMethod]
        public void Test_CalTotalScore_ValidInput_Expect_187()
        {
            BowllingBallTavisca.IBallingScore throwBalls = new BowllingBallTavisca.BowlingBallAlgo();
            var result = throwBalls.GetTotalScore(new System.Collections.Generic.List<int> { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 });
            Assert.IsTrue(result == 187);
        }

        [TestMethod]
        public void Test_CalTotalScore_FirstStrikeFrame_Expect_168()
        {
            BowllingBallTavisca.IBallingScore throwBalls = new BowllingBallTavisca.BowlingBallAlgo();
            var result = throwBalls.GetTotalScore(new System.Collections.Generic.List<int> { 10, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 7, 3, 3 });
            Assert.IsTrue(result == 168);
        }
        [TestMethod]
        public void Test_CalTotalScore_FirstSpareFrame_Expect_160()
        {
            BowllingBallTavisca.IBallingScore throwBalls = new BowllingBallTavisca.BowlingBallAlgo();
            var result = throwBalls.GetTotalScore(new System.Collections.Generic.List<int> { 3,7, 7, 3, 7, 2, 9, 1, 10, 10, 10, 2, 3, 6, 4, 6, 3, 4 });
            Assert.IsTrue(result == 160);
        }
        [TestMethod]
        public void Test_CalTotalScore_AllStrike_Expect_PerfectScore()
        {
            BowllingBallTavisca.IBallingScore throwBalls = new BowllingBallTavisca.BowlingBallAlgo();
            var result = throwBalls.GetTotalScore(new System.Collections.Generic.List<int> { 10,10,10,10,10,10,10,10,10,10, 10, 10});
            Assert.IsTrue(result == 300);
        }

        [TestMethod]
        public void Test_CalTotalScore_AllFalse_Expect_ZeroScore()
        {
            BowllingBallTavisca.IBallingScore throwBalls = new BowllingBallTavisca.BowlingBallAlgo();
            var result = throwBalls.GetTotalScore(new System.Collections.Generic.List<int> { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 });
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void Test_CalTotalScore_NoStrikeNoSpare_Expect_67()
        {
            BowllingBallTavisca.IBallingScore throwBalls = new BowllingBallTavisca.BowlingBallAlgo();
            var result = throwBalls.GetTotalScore(new System.Collections.Generic.List<int> { 1,3,2,6,5,3,8,1,5,4,0,0,2,6,1,3,8,0, 4,5,1});
            Assert.IsTrue(result == 67);
        }
    }
}
