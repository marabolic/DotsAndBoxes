using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.columnsLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.columnsNumUPD = new System.Windows.Forms.NumericUpDown();
            this.rowsNumUPD = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanHumanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humanComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerHumanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepByStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fInalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.columnsNumUPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumUPD)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Location = new System.Drawing.Point(35, 146);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(146, 20);
            this.columnsLabel.TabIndex = 9;
            this.columnsLabel.Text = "Number of columns";
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(61, 93);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(120, 20);
            this.rowsLabel.TabIndex = 8;
            this.rowsLabel.Text = "Number of rows";
            // 
            // columnsNumUPD
            // 
            this.columnsNumUPD.Location = new System.Drawing.Point(207, 144);
            this.columnsNumUPD.Name = "columnsNumUPD";
            this.columnsNumUPD.Size = new System.Drawing.Size(120, 26);
            this.columnsNumUPD.TabIndex = 7;
            // 
            // rowsNumUPD
            // 
            this.rowsNumUPD.Location = new System.Drawing.Point(207, 91);
            this.rowsNumUPD.Name = "rowsNumUPD";
            this.rowsNumUPD.Size = new System.Drawing.Size(120, 26);
            this.rowsNumUPD.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 33);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.humanHumanToolStripMenuItem,
            this.humanComputerToolStripMenuItem,
            this.computerHumanToolStripMenuItem,
            this.computerComputerToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newToolStripMenuItem.Text = "New";
            // 
            // humanHumanToolStripMenuItem
            // 
            this.humanHumanToolStripMenuItem.Name = "humanHumanToolStripMenuItem";
            this.humanHumanToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.humanHumanToolStripMenuItem.Text = "Human-Human";
            this.humanHumanToolStripMenuItem.Click += new System.EventHandler(this.HumanHumanToolStripMenuItem_Click_1);
            // 
            // humanComputerToolStripMenuItem
            // 
            this.humanComputerToolStripMenuItem.Name = "humanComputerToolStripMenuItem";
            this.humanComputerToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.humanComputerToolStripMenuItem.Text = "Human-Computer";
            this.humanComputerToolStripMenuItem.Click += new System.EventHandler(this.HumanComputerToolStripMenuItem_Click_1);
            // 
            // computerHumanToolStripMenuItem
            // 
            this.computerHumanToolStripMenuItem.Name = "computerHumanToolStripMenuItem";
            this.computerHumanToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.computerHumanToolStripMenuItem.Text = "Computer-Human";
            this.computerHumanToolStripMenuItem.Click += new System.EventHandler(this.ComputerHumanToolStripMenuItem_Click_1);
            // 
            // computerComputerToolStripMenuItem
            // 
            this.computerComputerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepByStepToolStripMenuItem,
            this.fInalToolStripMenuItem});
            this.computerComputerToolStripMenuItem.Name = "computerComputerToolStripMenuItem";
            this.computerComputerToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.computerComputerToolStripMenuItem.Text = "Computer-Computer";
            // 
            // stepByStepToolStripMenuItem
            // 
            this.stepByStepToolStripMenuItem.Name = "stepByStepToolStripMenuItem";
            this.stepByStepToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.stepByStepToolStripMenuItem.Text = "Step by step";
            this.stepByStepToolStripMenuItem.Click += new System.EventHandler(this.StepByStepToolStripMenuItem_Click);
            // 
            // fInalToolStripMenuItem
            // 
            this.fInalToolStripMenuItem.Name = "fInalToolStripMenuItem";
            this.fInalToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.fInalToolStripMenuItem.Text = "Final";
            this.fInalToolStripMenuItem.Click += new System.EventHandler(this.FInalToolStripMenuItem_Click_1);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(184, 34);
            this.difficultyToolStripMenuItem.Text = "Difficulty";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.easyToolStripMenuItem.Text = "Easy";
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.mediumToolStripMenuItem.Text = "Medium";
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.hardToolStripMenuItem.Text = "Hard";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(207, 200);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Depth";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(426, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.columnsLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.columnsNumUPD);
            this.Controls.Add(this.rowsNumUPD);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.columnsNumUPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsNumUPD)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #region Windows Form Designer generated code


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanHumanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humanComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerHumanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepByStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fInalToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}
