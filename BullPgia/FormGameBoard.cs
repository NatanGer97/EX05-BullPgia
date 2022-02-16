using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BoolPgia
{
    internal class FormGameBoard : Form
    {
        private const int k_NumberOfGuessesForEachRow = 4;
        private readonly TableLayoutPanel r_TableLayoutPanelMain;
        private readonly List<List<Button>> r_ButtonsGuesses;
        private readonly List<Button> r_ButtonsGeneratedSequence;
        private readonly List<Button> r_ButtonsSetGuess;
        private readonly List<List<Button>> r_ButtonsResult;
        private readonly List<TableLayoutPanel> r_TablePanelResults;
        private readonly BoolPgiaLogic r_BoolPgiaLogic;
        private readonly int r_NumberOfGuesses;
        private Color m_ColorPicked;

        public List<List<Button>> ButtonsGuesses
        {
            get
            {
                return r_ButtonsGuesses;
            }
        }

        public TableLayoutPanel TableLayoutPanelMain
        {
            get
            {
                return r_TableLayoutPanelMain;
            }
        }

        public List<Button> ButtonsGeneratedSequence
        {
            get
            {
                return r_ButtonsGeneratedSequence;
            }
        }

        public List<Button> ButtonsSetGuess
        {
            get
            {
                return r_ButtonsSetGuess;
            }
        }

        public List<List<Button>> ButtonsResult
        {
            get
            {
                return r_ButtonsResult;
            }
        }

        public List<TableLayoutPanel> TablePanelResults
        {
            get
            {
                return r_TablePanelResults;
            }
        }

        public BoolPgiaLogic BoolPgiaLogic
        {
            get
            {
                return r_BoolPgiaLogic;
            }
        }

        public Color ColorPicked
        {
            get
            {
                return m_ColorPicked;
            }

            set
            {
                m_ColorPicked = value;
            }
        }

        public int NumberOfGuesses
        {
            get
            {
                return r_NumberOfGuesses;
            }
        }

        public FormGameBoard(int i_NumberOfGuesses)
        {
            r_NumberOfGuesses = i_NumberOfGuesses;
            r_BoolPgiaLogic = new BoolPgiaLogic(i_NumberOfGuesses);
            r_TableLayoutPanelMain = new TableLayoutPanel();
            r_ButtonsGeneratedSequence = new List<Button>(k_NumberOfGuessesForEachRow);
            r_ButtonsGuesses = new List<List<Button>>(k_NumberOfGuessesForEachRow * r_NumberOfGuesses);
            r_ButtonsSetGuess = new List<Button>(r_NumberOfGuesses);
            r_ButtonsResult = new List<List<Button>>(r_NumberOfGuesses * k_NumberOfGuessesForEachRow);
            r_TablePanelResults = new List<TableLayoutPanel>(r_NumberOfGuesses);
            initializeComponent();
        }

        private void initializeComponent()
        {
            this.Size = new Size(270, 550);
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            initializeButtons();
            initializeGuessesTable();
        }

        // $G$ DSN-003 (-5) The code should be divided to methods. 
        private void initializeButtons()
        {
            // Initialize guess buttons
            for (int i = 0; i < r_NumberOfGuesses; i++)
            {
                r_ButtonsGuesses.Add(new List<Button>(k_NumberOfGuessesForEachRow));
                for(int j = 0; j < k_NumberOfGuessesForEachRow; j++)
                {
                    r_ButtonsGuesses[i].Add(new Button());
                    r_ButtonsGuesses[i][j].Size = new Size(50, 50);
                    this.Controls.Add(r_ButtonsGuesses[i][j]);
                    r_ButtonsGuesses[i][j].TabIndex = i;
                    r_ButtonsGuesses[i][j].Enabled = i == 0;
                    r_ButtonsGuesses[i][j].Click += buttonGuess_Click;
                }
            }

            // Initialize generated sequence buttons
            for(int i = 0; i < k_NumberOfGuessesForEachRow; i++)
            {
                r_ButtonsGeneratedSequence.Add(new Button());
                r_ButtonsGeneratedSequence[i].Size = new Size(50, 50);
                r_ButtonsGeneratedSequence[i].BackColor = Color.Black;
                r_ButtonsGeneratedSequence[i].Enabled = false;
                this.Controls.Add(r_ButtonsGeneratedSequence[i]);
            }

            string textForSetGuessButtons = "-->>";

            // Initialize set guess buttons
            for(int i = 0; i < r_NumberOfGuesses; i++)
            {
                r_ButtonsSetGuess.Add(new Button());
                r_ButtonsSetGuess[i].Size = new Size(50, 50);
                r_ButtonsSetGuess[i].TextAlign = ContentAlignment.MiddleCenter;
                r_ButtonsSetGuess[i].Margin = new Padding(0, 18, 0, 18);
                r_ButtonsSetGuess[i].Text = textForSetGuessButtons;
                r_ButtonsSetGuess[i].TabIndex = i;
                r_ButtonsSetGuess[i].Enabled = false;
                this.Controls.Add(r_ButtonsSetGuess[i]);
                r_ButtonsSetGuess[i].Click += buttonSetGuess_Click;
            }

            // Initialize result buttons
            for(int i = 0; i < r_NumberOfGuesses; i++)
            {
                r_ButtonsResult.Add(new List<Button>(k_NumberOfGuessesForEachRow));
                for(int j = 0; j < k_NumberOfGuessesForEachRow; j++)
                {
                    r_ButtonsResult[i].Add(new Button());
                    r_ButtonsResult[i][j].Enabled = false;
                    r_ButtonsResult[i][j].Size = new Size(15, 15);
                }
            }
        }

        private void buttonSetGuess_Click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;

            if(senderButton != null)
            {
                int rowIndex = senderButton.TabIndex;
                List<Color> guessResult = r_BoolPgiaLogic.AnalyzeAndGetGuessResult(r_ButtonsGuesses[rowIndex]);

                if (BoolPgiaLogic.IsGameEnded)
                {
                    revealCorrectSequence(rowIndex);
                }

                for (int i = 0; i < k_NumberOfGuessesForEachRow; i++)
                {
                    r_ButtonsResult[rowIndex][i].BackColor = guessResult[i];
                    r_ButtonsGuesses[rowIndex][i].Enabled = false;
                    if (rowIndex != r_NumberOfGuesses - 1)
                    {
                        if(!BoolPgiaLogic.IsGameEnded)
                        {
                            r_ButtonsGuesses[rowIndex + 1][i].Enabled = true;
                        }
                    }
                    
                }

                senderButton.Enabled = false;
            }
        }

        private void revealCorrectSequence(int i_RowIndex)
        {
            for(int i = 0; i < k_NumberOfGuessesForEachRow; i++)
            {
                r_ButtonsGeneratedSequence[i].BackColor = r_BoolPgiaLogic.RandomColorQuartet.ColorQuartet[i];
            }

            if(i_RowIndex == NumberOfGuesses - 1)
            {
                for (int i = 0; i < k_NumberOfGuessesForEachRow; i++)
                {
                    r_ButtonsGuesses[i_RowIndex][i].Enabled = false;
                }
            }
        }

        private void buttonGuess_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if(button != null)
            {
                int rowIndex = button.TabIndex;
                FormSelectColor formSelectColor = new FormSelectColor(this, r_BoolPgiaLogic.RandomColorQuartet.PossibleColors, rowIndex);
                bool isAllButtonsPainted = true;

                formSelectColor.ShowDialog();
                button.BackColor = ColorPicked;
                for(int i = 0; i < k_NumberOfGuessesForEachRow; i++)
                {
                    if(r_ButtonsGuesses[rowIndex][i].BackColor == DefaultBackColor)
                    {
                        isAllButtonsPainted = false;
                        break;
                    }
                }

                if(isAllButtonsPainted)
                {
                    r_ButtonsSetGuess[rowIndex].Enabled = true;
                }
            }
        }

        // $G$ DSN-003 (-5) The code should be divided to methods. 
        private void initializeGuessesTable()
        {
            int numberOfRows = r_NumberOfGuesses + 1;
            int numberOfCols = k_NumberOfGuessesForEachRow + 2;

            r_TableLayoutPanelMain.ColumnCount = numberOfCols;
            r_TableLayoutPanelMain.RowCount = numberOfRows;
            r_TableLayoutPanelMain.Dock = DockStyle.Fill;
            for (int i = 0; i < r_NumberOfGuesses; i++)
            {
                r_TablePanelResults.Add(new TableLayoutPanel());
                r_TablePanelResults[i].RowCount = 2;
                r_TablePanelResults[i].ColumnCount = 2;
                r_TablePanelResults[i].RowStyles.Add(new RowStyle(SizeType.AutoSize, 100 / (float)r_TablePanelResults[i].RowCount));
                r_TablePanelResults[i].ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, r_TablePanelResults[i].ColumnCount));
                this.Controls.Add(r_TablePanelResults[i]);
            }

            // Set ColumnStyles
            for (int i = 0; i < numberOfCols; i++)
            {
                r_TableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / (float)numberOfCols));
            }

            // Set RowStyles
            for(int i = 0; i < numberOfRows; i++)
            {
                r_TableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / (float)numberOfRows));
            }

            // Add generated sequence buttons to the table
            for(int i = 0; i < k_NumberOfGuessesForEachRow; i++)
            {
                r_TableLayoutPanelMain.Controls.Add(r_ButtonsGeneratedSequence[i]);
            }

            r_TableLayoutPanelMain.Controls.Add(new Label());
            r_TableLayoutPanelMain.Controls.Add(new Label());

            // Add guess buttons to the table
            for (int i = 0; i < r_ButtonsGuesses.Count; i++)
            {
                for(int j = 0; j < k_NumberOfGuessesForEachRow; j++)
                {
                    r_TablePanelResults[i].Controls.Add(r_ButtonsResult[i][j]);
                    r_TableLayoutPanelMain.Controls.Add(r_ButtonsGuesses[i][j]);
                }

                r_TableLayoutPanelMain.Controls.Add(r_ButtonsSetGuess[i]);
                r_TableLayoutPanelMain.Controls.Add(r_TablePanelResults[i]);
            }

            this.Controls.Add(r_TableLayoutPanelMain);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }
    }
}
