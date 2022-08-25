using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappybirdgame
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5 ;
        int gravity = 7;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gametimerevent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipebottom.Left -= pipeSpeed;
            pipetop.Left -= pipeSpeed;
            scoreText.Text = ("Score: ") + score;

            if (pipebottom.Left < -50)
            {
                pipebottom.Left = 550;
                score++;
            }

            if (pipetop.Left < -80)
            {
                pipetop.Left = 600;
                score++;
            }

            if (flappybird.Bounds.IntersectsWith(pipebottom.Bounds) ||
                flappybird.Bounds.IntersectsWith(pipetop.Bounds) || 
                flappybird.Bounds.IntersectsWith(ground.Bounds) || flappybird.Top < -25
                )
            {
                endGame();
            }  

            if (score > 5)
            {
                pipeSpeed = 10;
            }

            if (score > 10)
            {
                pipeSpeed = 15;
            }

            if (score > 15)
            {
                pipeSpeed = 20;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }
        }
        
        private void endGame()
        {
            timergame.Stop();
            scoreText.Text += " Game Over!!!";
        }
    }
}
