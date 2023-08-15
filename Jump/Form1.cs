using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jump
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score;

        void game_over()
        {
            if (player.Bounds.IntersectsWith(ground.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("Game-Over");
            }
        }

        void Game_logic() //функция для автопрыжка и посадки
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "base")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        player.Top = x.Top - player.Height;
                        if (player.Top > 200)
                        {
                            player.Top -= 10;
                        }
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds) == player.Top > 200)// для скроллинга платформы base
                    {
                        x.Top += 10;
                        if (x.Top > 500)
                        {
                            score += 1;
                            lbl_score.Text = "" + score;
                            x.Top = 0;
                        }
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //движение персонажа влево и право
        {
            switch (e.KeyCode)
            {
                case Keys.Right: //вправо
                    player.Image = Properties.Resources.WalkRight_MouthOpen_Purple2; //картинка персонажа вправо
                    if (player.Right < 380) // 380 - ширина формы
                        player.Left += 10; //скорость персонажа
                    if (player.Top > 200)
                        player.Top -= 10;
                    break;
                case Keys.Left:
                    player.Image = Properties.Resources.WalkLeft_MouthOpen_Purple2;
                    if (player.Left > 0)
                        player.Left -= 10;
                    if (player.Top > 200)
                        player.Top -= 10;
                    break;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game_logic();
            player.Top += 5;
            game_over();
        }
    }
}
