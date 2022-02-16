using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BoolPgia
{
    internal partial class FormSelectColor : Form
    {
        private readonly FormGameBoard r_GameBoard;
        private readonly List<Color> r_Colors;
        private readonly int r_ButtonsIndexInTable;

        public FormGameBoard GameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        public List<Color> Colors
        {
            get
            {
                return r_Colors;
            }
        }

        public int ButtonsIndexInTable
        {
            get
            {
                return r_ButtonsIndexInTable;
            }
        }

        public FormSelectColor(FormGameBoard i_GameBoard, List<Color> i_Colors, int i_ButtonsIndex)
        {
            r_ButtonsIndexInTable = i_ButtonsIndex;
            r_GameBoard = i_GameBoard;
            r_Colors = i_Colors;
            InitializeComponent();
            initializeExtraPropertiesForButtons();
        }

        private void initializeExtraPropertiesForButtons()
        {
            for (int i = 0; i < colorsTableLayout.Controls.Count; i++)
            {
                if (colorsTableLayout.Controls[i] is Button)
                {
                    Button button = colorsTableLayout.Controls[i] as Button;

                    if(button != null)
                    {
                        button.BackColor = r_Colors[i];
                        button.Enabled = !isColorAlreadySelected(button);
                        button.Click += buttonSelectColor_Click;
                    }
                }
            }
        }

        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if(button != null)
            {
                r_GameBoard.ColorPicked = button.BackColor;
            }

            this.Close();
        }

        private bool isColorAlreadySelected(Button i_Button)
        {
            bool isSelected = false;

            for(int i = 0; i < r_GameBoard.ButtonsGuesses[r_ButtonsIndexInTable].Count; i++)
            {
                if(r_GameBoard.ButtonsGuesses[r_ButtonsIndexInTable][i].BackColor == i_Button.BackColor)
                {
                    isSelected = true;
                    break;
                }
            }

            return isSelected;
        }
    }
}
