using System;
using System.Linq;
using System.Windows.Forms;

namespace Crestiks___Noolix
{
    public partial class Form1 : Form
    {
        private Button[] gameButtons;  
        private char currentPlayer = 'X';
        private int moves = 0;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeGame();
        }

        private void InitializeGame()
        {
            
            gameButtons = this.Controls
                .OfType<Button>()
                .Where(b => b.Text != "Новая игра") 
                .ToArray();

            
            foreach (Button btn in gameButtons)
            {
                btn.Click += GameButton_Click;
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Text != "")
                return; 

            clickedButton.Text = currentPlayer.ToString();
            moves++;

            if (CheckWin())
            {
                MessageBox.Show($"Игрок {currentPlayer} победил!");
                DisableButtons();
                return;
            }

            if (moves == 9)
            {
                MessageBox.Show("Ничья!");
                return;
            }

            
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        private bool CheckWin()
        {
            int[,] winPositions = {
                {0,1,2},{3,4,5},{6,7,8},
                {0,3,6},{1,4,7},{2,5,8},
                {0,4,8},{2,4,6}
            };

            for (int i = 0; i < 8; i++)
            {
                if (gameButtons[winPositions[i, 0]].Text == currentPlayer.ToString() &&
                    gameButtons[winPositions[i, 1]].Text == currentPlayer.ToString() &&
                    gameButtons[winPositions[i, 2]].Text == currentPlayer.ToString())
                    return true;
            }

            return false;
        }

        private void DisableButtons()
        {
            foreach (Button btn in gameButtons)
                btn.Enabled = false;
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Button btn in gameButtons)
            {
                btn.Text = "";
                btn.Enabled = true;
            }

            currentPlayer = 'X';
            moves = 0;
        }
    }
}