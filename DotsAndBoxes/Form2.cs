using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etf.dotsandboxes.bm170614d
{
    partial class Form2 : Form
    {
        private Label columnsLabel;
        private Label rowsLabel;
        private NumericUpDown columnsNumUPD;
        private NumericUpDown rowsNumUPD;

        static int numOfRows, numOfColumns;
        Computer.STRATEGY difficulty;
        Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }
        public static int NumRows()
        {
            return numOfRows;
        }

        public static int NumCols()
        {
            return numOfColumns;
        }



        //MENU ITEMS

        private void menuItemClick()
        {
            numOfColumns = Convert.ToInt32(columnsNumUPD.Value);
            numOfRows = Convert.ToInt32(rowsNumUPD.Value);
            form1 = new Form1();
            form1.ShowDialog();
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

        private void HumanHumanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1.game = new Game(new Human(), new Human());
            menuItemClick();
        }

        private void HumanComputerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1.game = new Game(new Human(), new Computer(difficulty));
            menuItemClick();
        }

        private void ComputerHumanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1.game = new Game(new Computer(difficulty), new Human());
            menuItemClick();
        }

        private void StepByStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.game = new Game(new Computer(difficulty), new Computer(difficulty));
            menuItemClick();
        }

        private void FInalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1.game = new Game(new Computer(difficulty), new Computer(difficulty));
            menuItemClick();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text | *.txt";
            openFileDialog1.ShowDialog();
        }


       

        private void Form2_Load(object sender, EventArgs e)
        {
            easyToolStripMenuItem.Checked = true;
        }
    }
}
