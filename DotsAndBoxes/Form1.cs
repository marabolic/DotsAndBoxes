﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DotsAndBoxes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataGridView dgv;  
        int numOfRows, numOfColumns;
        public int boxSize;
        private const int move = 4;
        Game game;
        int currX, currY;
        Computer.STRATEGY difficulty;
        


        void setGrid(DataGridView dgv) { 
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            dgv.RowCount = numOfRows;
            dgv.ColumnCount = numOfColumns;
            DoubleBuffered = true;
           
            boxSize = 35;
            int num = Math.Max(numOfColumns, numOfRows);

            dgv.Width = (num +1) * boxSize;
            dgv.Height = (num +1) * boxSize;
            


            for (int i = 0; i < numOfRows; i++) 
            {
                dgv.Rows[i].Height = boxSize;
            }
            for (int j = 0; j < numOfColumns; j++)
            {
                dgv.Columns[j].Width = boxSize;
            }

            
            for (int i = 0; i < numOfRows; i++)
                for (int j = 0; j < numOfColumns; j++)
                {
                    dgv[j, i].Style.BackColor = Color.White;
                }
            dgv.SetBounds(20, 20, dgv.Width, dgv.Height);
        }

        private void HumanHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new Game(new Human(), new Human());
        }

        private void HumanComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new Game(new Human(), new Computer(difficulty));
        }

        private void ComputerHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new Game(new Computer(difficulty), new Human());
        }

        private void ComputerComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new Game(new Computer(difficulty), new Computer(difficulty));
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e) {
            currX = e.X; currY = e.Y;
            
            richTextBox1.Text += convertCoordX().ToString() + "; " + convertCoordY().ToString() + "\n";
            dgv.Update();

        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int xLeft = e.CellBounds.X + move, yUp = e.CellBounds.Y + move,
                xRight = e.CellBounds.X + boxSize + move, yDown = e.CellBounds.Y + boxSize + move;

            drawDefaultLines(e, xLeft, xRight, yUp, yDown);
            drawDots(e, xLeft, xRight, yUp, yDown);

            char side = findMin(currX, currY, xLeft, xRight, yUp, yDown);
            Pen p = new Pen(Color.DarkRed);
            drawColouredLine(side, e, p, xLeft, xRight, yUp, yDown);
            
            e.Handled = true;
        }


        public void drawDots(DataGridViewCellPaintingEventArgs e, int xLeft, int xRight, int yUp, int yDown)
        {
            Brush b = new SolidBrush(Color.Gray);

            if (e.ColumnIndex != 0)
            {
                GraphicsExtensions.FillCircle(e.Graphics, b, xLeft, yUp, 4);
                if (e.RowIndex == numOfRows - 1)
                {
                    GraphicsExtensions.FillCircle(e.Graphics, b, xLeft, yDown, 4);
                }
            }
            else
            {
                GraphicsExtensions.FillCircle(e.Graphics, b, xLeft, yUp, 4);
                if (e.RowIndex == numOfRows - 1)
                {
                    GraphicsExtensions.FillCircle(e.Graphics, b, xLeft, yDown, 4);
                }
            }
            if (e.ColumnIndex == numOfColumns - 1)
            {
                GraphicsExtensions.FillCircle(e.Graphics, b, xRight, yUp, 4);
                if (e.RowIndex == numOfRows - 1)
                {
                    GraphicsExtensions.FillCircle(e.Graphics, b, xRight, yDown, 4);
                }
            }
        }

        public void drawDefaultLines(DataGridViewCellPaintingEventArgs e, int xLeft, int xRight, int yUp, int yDown) {
            using (
                Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            using (Pen gridLinePen = new Pen(gridBrush))
            {

                //top line
                e.Graphics.DrawLine(gridLinePen, xLeft, yUp, xRight, yUp);

                //bottom line
                if (e.RowIndex == numOfRows - 1)
                {
                    e.Graphics.DrawLine(gridLinePen, xLeft, yDown, xRight, yDown);
                }
                //left line
                if (e.ColumnIndex == 0)
                {
                    e.Graphics.DrawLine(gridLinePen, xLeft, yUp, xLeft, yDown);
                }
                //right line
                e.Graphics.DrawLine(gridLinePen, xRight, yUp, xRight, yDown);

            }
        }

        public void drawColouredLine(int side, DataGridViewCellPaintingEventArgs e, Pen p, int xLeft, int xRight, int yUp, int yDown) {
            switch (side){
                case 'l':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()) {
                        e.Graphics.DrawLine(p, xLeft, yUp + move, xLeft, yDown);
                    }
                    break;
                case 'r':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()) {
                        e.Graphics.DrawLine(p, xRight, yUp + move, xRight, yDown);
                    }
                    break;
                case 'u':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()) {
                        e.Graphics.DrawLine(p, xLeft + move, yUp, xRight, yUp);
                    }
                    break;
                case 'd':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()){
                        e.Graphics.DrawLine(p, xRight, yDown + move, xLeft, yDown);
                    }
                    break;
            }
        }

        private void EasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = Computer.STRATEGY.EASY;
            easyToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = false;
        }

        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = Computer.STRATEGY.MEDIUM;
            easyToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            hardToolStripMenuItem.Checked = false;
        }

        private void HardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = Computer.STRATEGY.HARD;
            easyToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e) {
            dgv.ClearSelection();
        } 

        public void Form1_Load(object sender, EventArgs e) {
            //showDimensionsChoice();
            numOfColumns = Form2.NumCols();
            numOfRows = Form2.NumRows(); 
            dgv = dataGridView1;
            easyToolStripMenuItem.Checked = true;
            setGrid(dgv);
        }

        private int convertCoordX()
        {
            return currY / boxSize;
        }

        private int convertCoordY()
        {
            return currX / boxSize;
        }


        private char findMin(int x, int y, int l, int r, int u, int d)
        {
            int min;
            char side;
            if (r - x < y - u)
            {
                min = r - x;
                side = 'r';
            }
            else
            {
                min = y - u;
                side = 'u';
            }
            if (min > d - y)
            {
                min = d - y;
                side = 'y';
            }
            if (min > x - l)
            {
                min = x - l;
                side = 'l';
            }

            return side;
        }



    }
}
