using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BoolPgia
{
    // $G$ CSS-999 (-3) The Class must have an access modifier.
    class BoolPgiaLogic
    {
        private const int k_NumberOfColorsToGuess = 4;
        private readonly RandomColorQuartet r_RandomColorQuartet;
        private readonly int r_NumberOfChances;
        public int NumberOfChances
        {
            get
            {
                return r_NumberOfChances;
            }
        }

        private bool m_IsGameEnded;

        public bool IsGameEnded
        {
            get
            {
                return m_IsGameEnded;
            }

            set
            {
                m_IsGameEnded = value;
            }
        }

        public RandomColorQuartet RandomColorQuartet
        {
            get
            {
                return r_RandomColorQuartet;
            }
        }

        public BoolPgiaLogic(int i_NumberOfChances)
        {
            r_NumberOfChances = i_NumberOfChances;
            r_RandomColorQuartet = new RandomColorQuartet();
            IsGameEnded = false;
        }

        public List<Color> AnalyzeAndGetGuessResult(List<Button> i_GuessToAnalyze)
        {
            List<Color> analyseResult = new List<Color>(k_NumberOfColorsToGuess);
            int correctPositionAndColorCounter = 0;
            int correctColorCounter = 0;

            for(int i = 0; i < k_NumberOfColorsToGuess; i++)
            {
                if(i_GuessToAnalyze[i].BackColor == r_RandomColorQuartet.ColorQuartet[i])
                {
                    correctPositionAndColorCounter++;
                }
                else
                {
                    if(r_RandomColorQuartet.IsColorContained(i_GuessToAnalyze[i].BackColor))
                    {
                        correctColorCounter++;
                    }
                }
            }

            if(correctPositionAndColorCounter == k_NumberOfColorsToGuess || i_GuessToAnalyze[0].TabIndex == NumberOfChances - 1)
            {
                IsGameEnded = true;
            }

            for(int i = 0; i < k_NumberOfColorsToGuess; i++)
            {
                if(correctPositionAndColorCounter > 0)
                {
                    analyseResult.Add(Color.Black);
                    correctPositionAndColorCounter--;
                }
                else
                {
                    if(correctColorCounter > 0)
                    {
                        analyseResult.Add(Color.Yellow);
                        correctColorCounter--;
                    }
                    else
                    {
                        analyseResult.Add(Control.DefaultBackColor);
                    }
                }
            }

            return analyseResult;
        }
    }
}
