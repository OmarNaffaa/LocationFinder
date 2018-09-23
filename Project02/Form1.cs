using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = 1500;
            Height = 840;

            Paint += new PaintEventHandler(DrawLinePoint);
            DefaultMap();
            Display();
        }

        // storage arrays for coordinates
        int[,] coordinates = new int[7, 2];
        Label[,] poolS = new Label[7, 2];

        // sets the default map
        private void DefaultMap()
        {
            // Draw Reference Label
            start.AutoSize = false;
            start.Size = new Size(80, 40);
            start.BackColor = Color.DarkRed;
            start.ForeColor = Color.White;
            start.Location = new Point(0, 0);
            start.Text = "Start: (0,0)";

            SetLabels();

            // generate default numbers for pool map
            coordinates[0, 0] = 280; coordinates[0, 1] = 620;
            coordinates[1, 0] = 40; coordinates[1, 1] = 220;
            coordinates[2, 0] = 280; coordinates[2, 1] = 140;
            coordinates[3, 0] = 1000; coordinates[3, 1] = 60;
            coordinates[4, 0] = 920; coordinates[4, 1] = 700;
            coordinates[5, 0] = 760; coordinates[5, 1] = 380;
            coordinates[6, 0] = 440; coordinates[6, 1] = 460;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    poolS[i, 0].Location = new Point(coordinates[i, j], coordinates[i, j + 1]);
                }
            }
        }

        public void DrawLinePoint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 3);

            // draw the grid lines
            for (int i = 0; i < 1200; i += 80)
            {
                e.Graphics.DrawLine(p, i, 0, i, 800);
            }

            for (int j = 0; j < 800; j += 80)
            {
                e.Graphics.DrawLine(p, 0, j, 1120, j);
            }
        }

        private void DrawPools()
        {
            // Draw Reference Label
            start.AutoSize = false;
            start.Size = new Size(80, 40);
            start.BackColor = Color.DarkRed;
            start.ForeColor = Color.White;
            start.Location = new Point(0, 0);
            start.Text = "Start: (0,0)";

            SetLabels();

            // generate random coordinates for the pools
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randX = 0, randY = 0;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    randX = rand.Next(1, 13) * 80 - 40;
                    randY = rand.Next(1, 9) * 80 - 20;

                    coordinates[i, j] = randX;
                    coordinates[i, j + 1] = randY;

                    poolS[i, 0].Location = new Point(coordinates[i, j], coordinates[i, j + 1]);
                }
            }
        }

        private void Display()
        {
            Location[,] loc = new Location[8, 2];
            loc[0,0] = new Location(coordinates[0, 0], coordinates[0, 1]);
            loc[1,0] = new Location(coordinates[1, 0], coordinates[1, 1]);
            loc[2,0] = new Location(coordinates[2, 0], coordinates[2, 1]);
            loc[3,0] = new Location(coordinates[3, 0], coordinates[3, 1]);
            loc[4,0] = new Location(coordinates[4, 0], coordinates[4, 1]);
            loc[5,0] = new Location(coordinates[5, 0], coordinates[5, 1]);
            loc[6,0] = new Location(coordinates[6, 0], coordinates[6, 1]);
            loc[7, 0] = new Location(0, 0);

            // create 7 pools
            Pool[] pools = new Pool[7];

            pools[0] = new Pool("A", loc[0,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";
            pools[1] = new Pool("B", loc[1,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";
            pools[2] = new Pool("C", loc[2,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";
            pools[3] = new Pool("D", loc[3,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";
            pools[4] = new Pool("E", loc[4,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";
            pools[5] = new Pool("F", loc[5,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";
            pools[6] = new Pool("G", loc[6,0]);
            DisplayPath.Text += Pool.poolCount + " pool(s) have been created\n";

            int x = 0, y = 0;

            for (int i = 0; i < 7; i++)
            {
                DisplayPath.Text += Pool.NearestDistance(pools, coordinates, ref x, ref y);
            }
        }

        private void SetLabels()
        {
            poolS[0, 0] = A;
            poolS[1, 0] = B;
            poolS[2, 0] = C;
            poolS[3, 0] = D;
            poolS[4, 0] = E;
            poolS[5, 0] = F;
            poolS[6, 0] = G;
        }

        private void rndPool_Click(object sender, EventArgs e)
        {
            DrawPools();
            Pool.poolCount = 0;
            DisplayPath.Text = "";
            Display();
        }
    }
}
