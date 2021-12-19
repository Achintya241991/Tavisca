using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowllingBallTavisca
{
    #region Comment
    /* 
      1. As stated following points in the requirement
       > Does not need to check for valid rolls.
       > Does not need to check for correct number of rolls and frames.
       > Does not need to not provide scores for intermediate frames.
       > The solution should assume valid inputs at all times and does not need to include unnecessary validations
         trying to prevent bad input data.
       2. Code can be segregated into different levels, client (Main), class (BL) and interface (Service), but 
    */
    #endregion

    #region Service
    public interface IBallingScore
    {
        int GetTotalScore(List<int> throwBalls);
    }
    #endregion

    #region BusinessLogic
    public class BowlingBallAlgo : IBallingScore
    {
        int currentRoll = 0;
        internal List<int> Throws { get; private set; }

        public int GetTotalScore(List<int> throwBall)
        {
            int frames = 0;
            List<int> currentTotal = new List<int>();
            Throws = throwBall;
            while (frames != 10)
            {
                var newFrame = CreateFrame(Throws);
                if (IsStrike(newFrame))
                {
                    currentTotal.Add(newFrame.Sum() + GetNextTwoRollPoints(currentRoll));
                }
                else if (IsSpare(newFrame))
                {
                    currentTotal.Add(newFrame.Sum() + GetNextOneRollPoints(currentRoll));
                }
                else
                {
                    currentTotal.Add(newFrame.Sum());
                }
                frames++;
            }
            return currentTotal.Sum();
        }

        private int GetNextTwoRollPoints(int currentRoll)
        {
            return Throws[currentRoll] + Throws[currentRoll + 1];
        }

        private int GetNextOneRollPoints(int currentRoll)
        {
            return Throws[currentRoll];
        }

        private bool IsSpare(List<int> throws)
        {
            return throws.Take(2).Sum() == 10;
        }

        private bool IsStrike(List<int> throws)
        {
            return throws.First() == 10;
        }

        private List<int> CreateFrame(List<int> throws)
        {
            List<int> newframe = new List<int>();
            if (throws[currentRoll] == 10) //Single value frame for strike
            {
                newframe.Add(throws[currentRoll]);
                currentRoll++;
            }
            else
            {
                for (int i = 0; i <= 1; i++) //Double value frame
                {
                    newframe.Add(throws[currentRoll]);
                    currentRoll++;
                }
                
            }
            return newframe;
        }

    }
    #endregion

    #region ClientCall
    class Program
    {
        static void Main(string[] args)
        {
            //Please find test values in Test project solution.
            BowlingBallAlgo newGame = new BowlingBallAlgo();
            int result = newGame.GetTotalScore(new List<int> { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 });
            Console.WriteLine("Total Score: " + result);
            Console.ReadKey();
        }
    }
    #endregion
}
