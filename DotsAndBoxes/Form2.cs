using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etf.dotsandboxes.bm170614d
{
    public partial class Form2 : Form
    {
        private Label columnsLabel;
        private Label rowsLabel;
        private NumericUpDown columnsNumUPD;
        private Button StartBtn;
        private NumericUpDown rowsNumUPD;

        static int numOfRows, numOfColumns;

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



        private void InitializeComponent()
        {
            this.columnsLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.columnsNumUPD = new System.Windows.Forms.NumericUpDown();
            this.rowsNumUPD = new System.Windows.Forms.NumericUpDown();
            this.StartBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNumUPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumUPD)).BeginInit();
            this.SuspendLayout();
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Location = new System.Drawing.Point(31, 107);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(146, 20);
            this.columnsLabel.TabIndex = 9;
            this.columnsLabel.Text = "Number of columns";
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(57, 54);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(120, 20);
            this.rowsLabel.TabIndex = 8;
            this.rowsLabel.Text = "Number of rows";
            // 
            // columnsNumUPD
            // 
            this.columnsNumUPD.Location = new System.Drawing.Point(203, 105);
            this.columnsNumUPD.Name = "columnsNumUPD";
            this.columnsNumUPD.Size = new System.Drawing.Size(120, 26);
            this.columnsNumUPD.TabIndex = 7;
            // 
            // rowsNumUPD
            // 
            this.rowsNumUPD.Location = new System.Drawing.Point(203, 52);
            this.rowsNumUPD.Name = "rowsNumUPD";
            this.rowsNumUPD.Size = new System.Drawing.Size(120, 26);
            this.rowsNumUPD.TabIndex = 6;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(224, 171);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(99, 32);
            this.StartBtn.TabIndex = 10;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(395, 318);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.columnsLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.columnsNumUPD);
            this.Controls.Add(this.rowsNumUPD);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.columnsNumUPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumUPD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            numOfColumns = Convert.ToInt32(columnsNumUPD.Value);
            numOfRows = Convert.ToInt32(rowsNumUPD.Value);
           
            Form1 form1 = new Form1();
            form1.ShowDialog();
            // form1.Form1_Load(sender, e);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
