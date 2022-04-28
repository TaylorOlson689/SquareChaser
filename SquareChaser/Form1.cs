using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace SquareChaser
{
    public partial class Form1 : Form
    {

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        Rectangle player1 = new Rectangle(10, 210, 10, 10);
        Rectangle player2 = new Rectangle(10, 130, 10, 10);
        Rectangle ball1 = new Rectangle(295, 195, 10, 10);
        Rectangle ball2 = new Rectangle(315, 195, 10, 10);

        int player1Score = 0;
        int player2Score = 0;
        int player1Speed = 6;
        int player2Speed = 6;


        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    wDown = false;
                    break;
                case Keys.D:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    wDown = false;
                    break;
                case Keys.Right:
                    sDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    wDown = true;
                    break;
                case Keys.D:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    wDown = true;
                    break;
                case Keys.Right:
                    sDown = true;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += player1Speed;
            }

            //move player2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }

            // create code that checks if player 1 collides with ball1 and if it does
            // move ball1 to a different location.
            if (player1.IntersectsWith(ball1))
            {
                SoundPlayer CollisionSound = new SoundPlayer(Properties.Resources.CollisionSound);
                player1Speed *= +1;
                //ball1.X = ;
                //ball1.Y = ; 
            }
            if (player1.IntersectsWith(ball2))
            {
                SoundPlayer CollisionSound = new SoundPlayer(Properties.Resources.CollisionSound);
                player1Speed *= -1;
                //ball2.X = ;
                //ball2.Y = ;
            }
            if (player2.IntersectsWith(ball1))
            {
                SoundPlayer CollisionSound = new SoundPlayer(Properties.Resources.CollisionSound);
                player2Speed *= +1;
                //ball1.X = ;
                //ball1.Y = ;
            }
            if (player2.IntersectsWith(ball2))
            {
                SoundPlayer CollisionSound = new SoundPlayer(Properties.Resources.CollisionSound);
                player2Speed *= -1;
                //ball2.X = ;
                //ball2.Y = ;
            }

            //    //check for game over
            //    if (player1Score == 3)
            //    {
            //        gameTimer.Enabled = false;
            //        winLabel.Visible = true;
            //        winLabel.Text = "Player 1 Wins!!";
            //    }
            //    else if (player2Score == 3)
            //    {
            //        gameTimer.Enabled = false;
            //        winLabel.Visible = true;
            //        winLabel.Text = "Player 2 Wins!!";
            //    }
            //}
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball1);
            e.Graphics.FillRectangle(yellowBrush, ball2);
        }
    }
}