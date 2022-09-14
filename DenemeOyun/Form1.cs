using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeOyun
{
    public partial class Form1 : Form
    {
        int boruHizi = 6;
        int gravity = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }
         
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            BoruAlt.Left -= boruHizi;
            BoruUst.Left -= boruHizi;
            ScoreText.Text = "Score: "  + score;
            if (BoruAlt.Left < -150)
            {
                BoruAlt.Left = 500;
                score += 50;
                boruHizi++;
            }

            if (BoruUst.Left < -180)
            {
                BoruUst.Left = 600;
                score += 50;
            }
            
            if (flappyBird.Bounds.IntersectsWith(BoruAlt.Bounds)
                || flappyBird.Bounds.IntersectsWith(BoruUst.Bounds)
                || flappyBird.Bounds.IntersectsWith(Zemin.Bounds))
                endGame();

            //if (score >= 200)
            //{
            //    boruHizi = 15;
            //}
            //if (score >= 600)
            //{
            //    boruHizi = 20;
            //}
            if (flappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text = "Score: " + score;
            SonYazi.Text = "Game Over!!";

        }
    }
}
