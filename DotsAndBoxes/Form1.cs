using System;
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
        bool clicked = false, active = false;



        //LOADING FORM
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

        public void Form1_Load(object sender, EventArgs e)  {
            //showDimensionsChoice();
            numOfColumns = Form2.NumCols();
            numOfRows = Form2.NumRows();
            dgv = dataGridView1;
            easyToolStripMenuItem.Checked = true;
            setGrid(dgv);
        }

         

        //MOUSE EVENT

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e) {
            currX = e.X; currY = e. Y;
            clicked = true;
            active = true;
            dgv.Update(); 

        }



        //DRAWING

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int xLeft = e.CellBounds.X + move, yUp = e.CellBounds.Y + move,
                xRight = e.CellBounds.X + boxSize + move, yDown = e.CellBounds.Y + boxSize + move;

            if (!clicked) {
                drawDefaultLines(e, xLeft, xRight, yUp, yDown);
                Brush b = new SolidBrush(Color.Gray);
                drawDots(e, b, xLeft, xRight, yUp, yDown);
            }
            else {
                if (active && game != null) {
                    char side = findMin(currX, currY, xLeft, xRight, yUp, yDown);
                    //richTextBox1.Text += side.ToString() + "\n"; 
                    Pen p;
                    if (game.getPlayer1().isMyMove())  {
                        p = new Pen(Color.Blue);
                        if (game.makesSquare(e.RowIndex, e.ColumnIndex))
                        {
                            game.getPlayer1().setMyTurn(true);
                            game.getPlayer2().setMyTurn(false);
                        }
                        else
                        {
                            game.getPlayer1().setMyTurn(false);
                            game.getPlayer2().setMyTurn(true);
                        }
                    }
                    else {
                        p = new Pen(Color.DarkRed);
                        game.getPlayer1().setMyTurn(true);
                        game.getPlayer2().setMyTurn(false);
                    }
                    drawColouredLine(side, e, p, xLeft, xRight, yUp, yDown);
                }
                active = false;
            }
            e.Handled = true;
        }

        public void drawDots(DataGridViewCellPaintingEventArgs e, Brush b, int xLeft, int xRight, int yUp, int yDown)
        {
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
                        //if
                        e.Graphics.DrawLine(p, xLeft, yUp + move, xLeft, yDown);
                        drawMove(p, e, DotsAndBoxes.Move.DIRECTION.VERTICAL);
                    }
                    break;
                case 'r':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()) {
                        e.Graphics.DrawLine(p, xRight, yUp + move, xRight, yDown);
                        drawMove(p, e, DotsAndBoxes.Move.DIRECTION.VERTICAL);
                    } 
                    break;
                case 'u':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()) {
                        e.Graphics.DrawLine(p, xLeft + move, yUp, xRight, yUp);
                        drawMove(p, e, DotsAndBoxes.Move.DIRECTION.HORIZONTAL);
                    }
                    break;
                case 'd':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY()){
                        e.Graphics.DrawLine(p, xRight, yDown + move, xLeft, yDown);
                        drawMove(p, e, DotsAndBoxes.Move.DIRECTION.HORIZONTAL);
                    }
                    break;
            }
        }

        private void drawMove(Pen p, DataGridViewCellPaintingEventArgs e, Move.DIRECTION direction)
        {
            if (p.Color == Color.Blue)
            {
                Move m = new Move(e.RowIndex, e.ColumnIndex, direction);
                //game.getPlayer1().makeMove(m);
                game.addMove(m);
                richTextBox1.Text += game.map(m) + "\n";
            }
            else
            {
                Move m = new Move(e.RowIndex, e.ColumnIndex, direction);
                game.addMove(m);
                //game.getPlayer2().makeMove(m);
                richTextBox1.Text += game.map(m) + "\n";
            }
        }
        


        //MENI ITEMS

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




        //ADDITIONAL METHODS

        private int convertCoordX() { return currY / boxSize; }

        private int convertCoordY() { return currX / boxSize; }
     
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
                side = 'd';
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
