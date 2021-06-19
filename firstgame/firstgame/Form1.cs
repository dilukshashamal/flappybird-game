using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstgame
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5,gravity=15,score=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flapyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score : " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;

            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;

            }

            if(flapyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || flapyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flapyBird.Bounds.IntersectsWith(ground.Bounds) || flapyBird.Top < -25)
            {
                endGame();
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                gravity = -15;

            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;

            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Game Over";
            
            if((MessageBox.Show("Would you like to play this game again?","message",MessageBoxButtons.YesNo)) == DialogResult.Yes){
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
