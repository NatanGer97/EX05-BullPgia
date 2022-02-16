using System;
using System.Windows.Forms;

namespace BoolPgia
{
    internal partial class FormChances : Form
    {
        private int m_NumberOfChances = 4;

        public int NumberOfChances
        {
            get
            {
                return m_NumberOfChances;
            }

            set
            {
                m_NumberOfChances = value;
            }
        }

        public FormChances()
        {
            InitializeComponent();
        }

        // $G$ CSS-027 (-3) Spaces are not kept as required after defying variables.
        private void buttonStart_Click(object sender, EventArgs e)
        {
            FormGameBoard gameBoard = new FormGameBoard(NumberOfChances);
            gameBoard.Show();
            this.Hide();
        }

        private void buttonChances_Click(object sender, EventArgs e)
        {
            NumberOfChances = NumberOfChances == 10 ? 4 : NumberOfChances + 1;
            this.buttonChances.Text = string.Format("Number of Chances: {0}", NumberOfChances);
        }
    }
}
