using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using etf.dotsandboxes.bm170614d;


namespace etf.dotsandboxes.bm170614d
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
      
        int currX, currY;
        public static Game game;
        bool clicked = false, active = false;



        //LOADING FORM

        void setGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            dgv.RowCount = numOfRows;
            dgv.ColumnCount = numOfColumns;
            DoubleBuffered = true;

            boxSize = 35;
            int num = Math.Max(numOfColumns, numOfRows);

            dgv.Width = (num + 1) * boxSize;
            dgv.Height = (num + 1) * boxSize;



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

        public void Form1_Load(object sender, EventArgs e)
        {
            numOfColumns = Form2.NumCols();
            numOfRows = Form2.NumRows();
            dgv = dataGridView1;
            setGrid(dgv);
            timer1.Start();
        }



        //MOUSE EVENT

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currX = e.X; currY = e.Y;
            clicked = true;
            active = true;

            int side = findClosestEdge(e.X, e.Y, e.Location.X, e.Location.X + boxSize, e.Location.Y, e.Location.Y + boxSize);
            Move m;
            if (side == e.Location.X || side == e.Location.X + boxSize)
                m = new Move(convertCoordX(), convertCoordY(), bm170614d.Move.DIRECTION.VERTICAL);
            else
            {
                m = new Move(convertCoordX(), convertCoordY(), bm170614d.Move.DIRECTION.HORIZONTAL);
            }
            game.getGameState().getCurrentPlayer().setCurrentMove(m);
            dgv.Update();
        }


        private void Timer1_Tick(object sender, EventArgs e) {
            Move move = game.getGameState().getCurrentPlayer().getCurrentMove();
            Color color = game.getGameState().getCurrentPlayer().getColor();
            if (move != null) {
                //todo
                game.getGameState().addMove(move, color);
                game.getGameState().getCurrentPlayer().setCurrentMove(null);
            }
            dgv.Update();
        }

        //DRAWING

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int xLeft = e.CellBounds.X + move, yUp = e.CellBounds.Y + move,
                xRight = e.CellBounds.X + boxSize + move, yDown = e.CellBounds.Y + boxSize + move;

            if (!clicked)
            {
                drawDefaultLines(e, xLeft, xRight, yUp, yDown);
                Brush b = new SolidBrush(Color.Gray);
                drawDots(e, b, xLeft, xRight, yUp, yDown);
            }
            else
            {
                if (active && game != null)
                {
                    Color color;
                    //top line
                    if (game.getGameState().getUp(e.RowIndex, e.ColumnIndex, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xLeft, yUp, xRight, yUp);
                    }
                    else { e.Graphics.DrawLine(new Pen(Color.Gray), xLeft, yUp, xRight, yUp); }
                    //left line
                    if (game.getGameState().getLeft(e.RowIndex, e.ColumnIndex, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xLeft, yUp, xLeft, yDown);
                    }
                    else { e.Graphics.DrawLine(new Pen(Color.Gray), xLeft, yUp, xLeft, yDown); }
                    //down
                    if (game.getGameState().getDown(e.RowIndex, e.ColumnIndex, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xLeft, yDown, xRight, yDown);
                    }
                    else { e.Graphics.DrawLine(new Pen(Color.Gray), xLeft, yDown, xRight, yDown); }
                    //right
                    if (game.getGameState().getRight(e.RowIndex, e.ColumnIndex, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xRight, yUp, xRight, yDown);
                    }
                    else { e.Graphics.DrawLine(new Pen(Color.Gray), xRight, yUp, xRight, yDown); }
                }

                //    char side = findMin(currX, currY, xLeft, xRight, yUp, yDown);
                //    //richTextBox1.Text += side.ToString() + "\n"; 
                //    Pen p;
                //    if (game.getPlayer1().isMyMove())  {
                //        p = new Pen(Color.Blue);
                //        if (game.makesSquare(e.RowIndex, e.ColumnIndex))
                //        {
                //            game.getPlayer1().setMyTurn(true);
                //            game.getPlayer2().setMyTurn(false);
                //        }
                //        else
                //        {
                //            game.getPlayer1().setMyTurn(false);
                //            game.getPlayer2().setMyTurn(true);
                //        }
                //    }
                //    else {
                //        p = new Pen(Color.DarkRed);
                //        if (game.makesSquare(e.RowIndex, e.ColumnIndex))
                //        {
                //            game.getPlayer1().setMyTurn(false);
                //            game.getPlayer2().setMyTurn(true);
                //        }
                //        else
                //        {
                //            game.getPlayer1().setMyTurn(true);
                //            game.getPlayer2().setMyTurn(false);
                //        }

                //    }
                //    drawColouredLine(side, e, p, xLeft, xRight, yUp, yDown);
                //}
                //active = false;

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

        public void drawDefaultLines(DataGridViewCellPaintingEventArgs e, int xLeft, int xRight, int yUp, int yDown)
        {
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

        public void drawColouredLine(int side, DataGridViewCellPaintingEventArgs e, Pen p, int xLeft, int xRight, int yUp, int yDown)
        {
            switch (side)
            {
                case 'l':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY())
                    {
                        //if
                        e.Graphics.DrawLine(p, xLeft, yUp + move, xLeft, yDown);
                        drawMove(p, e, bm170614d.Move.DIRECTION.VERTICAL);
                    }
                    break;
                case 'r':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY())
                    {
                        e.Graphics.DrawLine(p, xRight, yUp + move, xRight, yDown);
                        drawMove(p, e, bm170614d.Move.DIRECTION.VERTICAL);
                    }
                    break;
                case 'u':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY())
                    {
                        e.Graphics.DrawLine(p, xLeft + move, yUp, xRight, yUp);
                        drawMove(p, e, bm170614d.Move.DIRECTION.HORIZONTAL);
                    }
                    break;
                case 'd':
                    if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY())
                    {
                        e.Graphics.DrawLine(p, xRight, yDown + move, xLeft, yDown);
                        drawMove(p, e, bm170614d.Move.DIRECTION.HORIZONTAL);
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
                game.getGameState().addMove(m,p.Color);
                richTextBox1.Text += game.map(m) + "\n";
            }
            else
            {
                Move m = new Move(e.RowIndex, e.ColumnIndex, direction);
                game.getGameState().addMove(m, p.Color);
                //game.getPlayer2().makeMove(m);
                richTextBox1.Text += game.map(m) + "\n";
            }
        }



        //MENU ITEMS

       

        //ADDITIONAL METHODS

        private int convertCoordX() { return currY / boxSize; }

        private int convertCoordY() { return currX / boxSize; }

        private int findClosestEdge(int x, int y, int l, int r, int u, int d)
        {
            int min;
            int side;
            if (r - x < y - u)
            {
                min = r - x;
                side = r;
            }
            else
            {
                min = y - u;
                side = u;
            }
            if (min > d - y)
            {
                min = d - y;
                side = d;
            }
            if (min > x - l)
            {
                min = x - l;
                side = l;
            }

            return side;
        }


    }
}
