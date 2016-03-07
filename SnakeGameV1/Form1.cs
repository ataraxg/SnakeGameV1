using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameV1
{
    public partial class Form1 : Form
    {
        private int time = 0;
        private bool running = false;
        private int direction = 0;
        int snakeX;
        int snakeY;
        PictureBox snake = new PictureBox();
        PictureBox[,] pictureBox1 = new PictureBox[38, 20];
        class Coordinate { int x; int y;
            public Coordinate(int x, int y) { this.x = x; this.y = y; } }
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(MainForm_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetFeatureToAllControls(this.Controls);
            //
            // PictureBox
            //
            
            int x = 0;
            int y = 0;
            for (int i = 0; i < 38; i++)
            {
                y = 0;
                for (int j = 0; j < 20; j++) {

                    pictureBox1[i,j] = new PictureBox();
                    pictureBox1[i,j].Location = new System.Drawing.Point(x, y);
                    pictureBox1[i,j].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\grass-background-5 - Copie.jpg";
                    pictureBox1[i,j].Size = new System.Drawing.Size(20, 20);
                    pictureBox1[i, j].Name = "field";

                    y = y + 20;

                    panel1.Controls.Add(pictureBox1[i,j]);
                }

                x = x + 20;
            }
            
            pictureBox1[17, 10].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\snake.jpg";
            snakeX = 17;
            snakeY = 10;

            // Fruit / Wall


            List<Coordinate> listFruit = new List<Coordinate>();
            List<Coordinate> listWall = new List<Coordinate>();
            Random rnd = new Random();

            int fruitX = rnd.Next(0, 37);
            int fruitY = rnd.Next(0, 19);

            pictureBox1[fruitX, fruitY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\cherry.png";

            listFruit.Add(new Coordinate(fruitX, fruitY));

            int wallX = rnd.Next(0, 37);
            int wallY = rnd.Next(0, 19);

            if (listFruit.Contains(new Coordinate(wallX, wallY)))
            {
                wallX = rnd.Next(0, 37);
                wallY = rnd.Next(0, 19);
            }
            else
            {
                pictureBox1[wallX, wallY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\wall.png";

                listWall.Add(new Coordinate(wallX, wallY));
            }

        }
        private void SetFeatureToAllControls(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Control control in cc)
                {
                    control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    SetFeatureToAllControls(control.Controls);
                }
            }
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                direction = 0;
                label2.Text = "Left";
            }
            else if (e.KeyCode == Keys.Right)
            {
                direction = 1;
                label2.Text = "Right";
            }
            else if (e.KeyCode == Keys.Up)
            {
                direction = 2;
                label2.Text = "Up";
            }
            else if (e.KeyCode == Keys.Down)
            {
                direction = 3;
                label2.Text = "Down";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (running == false)
            {
                button.Text = "Stop";
                timer1.Enabled = true;
                timer1.Interval = 100;
                timer1.Start();
                running = true;
            }
            else {
                button.Text = "Start";
                timer1.Stop();
                running = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (direction == 0)
            {
                time++;
                label1.Text = time.ToString();
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\grass-background-5 - Copie.jpg";
                if (snakeX == 0) { snakeX = 38; }
                snakeX = snakeX - 1;
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\snake.jpg";
            }
            else if (direction == 1)
            {
                time++;
                label1.Text = time.ToString();
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\grass-background-5 - Copie.jpg";
                if (snakeX == 37) { snakeX = -1; }
                snakeX = snakeX + 1;
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\snake.jpg";
                
            }
            else if (direction == 2)
            {
                time++;
                label1.Text = time.ToString();
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\grass-background-5 - Copie.jpg";
                if (snakeY == 0) { snakeY = 20; }
                snakeY = snakeY - 1;
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\snake.jpg";
            }
            else if (direction == 3)
            {
                time++;
                label1.Text = time.ToString();
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\grass-background-5 - Copie.jpg";
                if (snakeY == 19) { snakeY = -1; }
                snakeY = snakeY + 1;
                pictureBox1[snakeX, snakeY].ImageLocation = @"C:\Users\antoine\Documents\Visual Studio 2015\Projects\snake.jpg";
            }
        }
    }
}
