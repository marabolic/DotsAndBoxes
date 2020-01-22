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
        bool clicked = false;



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

       

        private void Timer1_Tick(object sender, EventArgs e) {
            Move move = game.getGameState().getCurrentPlayer().makeMove(game.getGameState());
            Color color = game.getGameState().getCurrentPlayer().getColor();
            if (move != null) {
                //todo
                currX = move.getRow();
                currY = move.getColumn();
                game.getGameState().addMove(move, color);
            } 
            dgv.Update();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int[] sides = new int[4];
            sides[0] = e.X;
            sides[1] = dgv[e.ColumnIndex, e.RowIndex].Size.Width - e.X;
            sides[2] = e.Y;
            sides[3] = dgv[e.ColumnIndex, e.RowIndex].Size.Height - e.Y;
            int minIndex = Array.IndexOf(sides, sides.Min());
            Move m;
            switch (minIndex)
            {
                case 0:
                    m = new Move(e.RowIndex, e.ColumnIndex, bm170614d.Move.SIDE.LEFT);
                    break;
                case 1:
                    m = new Move(e.RowIndex, e.ColumnIndex, bm170614d.Move.SIDE.RIGHT);
                    break;
                case 2:
                    m = new Move(e.RowIndex, e.ColumnIndex, bm170614d.Move.SIDE.UP);
                    break;
                case 3:
                    m = new Move(e.RowIndex, e.ColumnIndex, bm170614d.Move.SIDE.DOWN);
                    break;
                default:
                    m = null;
                    break;
            }
            Console.WriteLine(GameState.map(m));
            game.getGameState().getCurrentPlayer().setCurrentMove(m);
            clicked = true;
            timer1.Start();
           
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
                if (game != null)
                {


                    Color color;
                    //top line
                    if (game.getGameState().getUp(currX, currY , out color)) { 
                        e.Graphics.DrawLine(new Pen(color), xLeft, yUp, xRight, yUp);
                    }
                    
                    //left line
                    if (game.getGameState().getLeft(currX, currY, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xLeft, yUp, xLeft, yDown);
                    }
                    
                    //down
                    if (game.getGameState().getDown(currX, currY, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xLeft, yDown, xRight, yDown);
                    }
                    
                    //right
                    if (game.getGameState().getRight(currX, currY, out color))
                    {
                        e.Graphics.DrawLine(new Pen(color), xRight, yUp, xRight, yDown);
                    } 


                    if (game.getGameState().countEdges(currX, currY, color) == 4)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(color), xLeft, yUp, xRight-xLeft , yDown-yUp);
                    }

                }
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
