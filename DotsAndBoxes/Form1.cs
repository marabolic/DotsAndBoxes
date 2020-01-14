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

        int currX, currY;

        void setGrid(DataGridView dgv) { 
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = false;
            dgv.RowCount = numOfRows;
            dgv.ColumnCount = numOfColumns;

           
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

       //private void hideDimensionsChoice()
       // {
       //     columnsLabel.Visible = false;
       //     rowsLabel.Visible = false;
       //     columnsNumUPD.Visible = false;
       //     rowsNumUPD.Visible = false;
       //     StartBtn.Visible = false;
       // }

        //private void showDimensionsChoice()
        //{
        //    columnsLabel.Visible = true;
        //    rowsLabel.Visible = true;
        //    columnsNumUPD.Visible = true;
        //    rowsNumUPD.Visible = true;
        //    StartBtn.Visible = true;
        //}



        private void HumanHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showDimensionsChoice();
           
            

        }

        private void HumanComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showDimensionsChoice();
       }

        private void ComputerHumanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showDimensionsChoice();
        }

        private void ComputerComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showDimensionsChoice();
        }

        private void StartBtn_Click(object sender, EventArgs e) {
            dgv.Update();
            dgv.Refresh();
        }

        private int convertCoordX()
        {
            return currX / boxSize;
        }

        private int convertCoordY()
        {
            return currY / boxSize;
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int xLeft = e.CellBounds.X + move, yUp = e.CellBounds.Y + move,
                xRight = e.CellBounds.X + boxSize + move, yDown = e.CellBounds.Y + boxSize + move;

            
            using (
                Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                using (Pen gridLinePen = new Pen(gridBrush)) {

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

            Brush b = new SolidBrush(Color.Gray);

            if (e.ColumnIndex != 0)
            {
                GraphicsExtensions.FillCircle(e.Graphics, b, xLeft, yUp, 4);
                if (e.RowIndex == numOfRows - 1) {
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


            if (e.RowIndex == convertCoordX() && e.ColumnIndex == convertCoordY())
            {
               GraphicsExtensions.FillRectangle(e.Graphics, b, e.CellBounds.Location.X + 4, e.CellBounds.Location.Y + 4, e.CellBounds.Location.X + 4, e.CellBounds.Location.Y + 4);
            }

            

            e.Handled = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }

       

        public void Form1_Load(object sender, EventArgs e) {
            //showDimensionsChoice();
            numOfColumns = Form2.NumCols();
            numOfRows = Form2.NumRows(); 
            dgv = dataGridView1; 
            setGrid(dgv);

        }

        


    }
}
