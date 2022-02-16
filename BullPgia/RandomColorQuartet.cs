using System;
using System.Collections.Generic;
using System.Drawing;

namespace BoolPgia
{
    internal class RandomColorQuartet
    {
        private const int k_NumberOfColors = 4;
        private readonly List<Color> r_ColorQuartet;
        private readonly List<Color> r_PossibleColors;
        private readonly Random r_Random;

        public RandomColorQuartet()
        {
            r_Random = new Random();
            r_PossibleColors = fillPossibleColors();
            r_ColorQuartet = fillRandomQuartet();
        }

        public List<Color> ColorQuartet
        {
            get
            {
                return r_ColorQuartet;
            }
        }

        public List<Color> PossibleColors
        {
            get
            {
                return r_PossibleColors;
            }
        }

        public Random Random
        {
            get
            {
                return r_Random;
            }
        }

        private List<Color> fillPossibleColors()
        {
            List<Color> colorsList = new List<Color>
                                         {
                                             Color.Purple,
                                             Color.Red,
                                             Color.Lime,
                                             Color.Aqua,
                                             Color.Blue,
                                             Color.Yellow,
                                             Color.SaddleBrown,
                                             Color.White,
                                         };

            return colorsList;
        }

        private List<Color> fillRandomQuartet()
        {
            List<Color> randColors = new List<Color>(k_NumberOfColors);

            for(int i = 0; i < k_NumberOfColors; i++)
            {
                int randIndex = Random.Next(PossibleColors.Count);

                if(randColors.Contains(PossibleColors[randIndex]))
                {
                    i--;
                    continue;
                }

                randColors.Add(PossibleColors[randIndex]);
            }

            return randColors;
        }

        internal bool IsColorContained(Color i_Color)
        {
            bool isContained = false;

            for(int i = 0; i < ColorQuartet.Count; i++)
            {
                if(ColorQuartet[i] == i_Color)
                {
                    isContained = true;
                }
            }

            return isContained;
        }
    }
}
