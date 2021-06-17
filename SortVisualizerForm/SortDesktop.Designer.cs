
namespace SortVisualizerForm
{
    partial class SortDesktop
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algName = new System.Windows.Forms.Label();
            this.selectAlg = new System.Windows.Forms.ComboBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.displayAlg = new System.Windows.Forms.Panel();
            this.startSort = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // algName
            // 
            this.algName.AutoSize = true;
            this.algName.Location = new System.Drawing.Point(13, 32);
            this.algName.Name = "algName";
            this.algName.Size = new System.Drawing.Size(67, 17);
            this.algName.TabIndex = 1;
            this.algName.Text = "Algorithm";
            // 
            // selectAlg
            // 
            this.selectAlg.FormattingEnabled = true;
            this.selectAlg.Location = new System.Drawing.Point(87, 34);
            this.selectAlg.Name = "selectAlg";
            this.selectAlg.Size = new System.Drawing.Size(152, 24);
            this.selectAlg.TabIndex = 2;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(292, 34);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 3;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // displayAlg
            // 
            this.displayAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayAlg.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.displayAlg.Location = new System.Drawing.Point(13, 64);
            this.displayAlg.Name = "displayAlg";
            this.displayAlg.Size = new System.Drawing.Size(808, 386);
            this.displayAlg.TabIndex = 4;
            // 
            // startSort
            // 
            this.startSort.Location = new System.Drawing.Point(387, 34);
            this.startSort.Name = "startSort";
            this.startSort.Size = new System.Drawing.Size(75, 23);
            this.startSort.TabIndex = 5;
            this.startSort.Text = "Start";
            this.startSort.UseVisualStyleBackColor = true;
            this.startSort.Click += new System.EventHandler(this.startSort_Click);
            // 
            // SortDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 462);
            this.Controls.Add(this.startSort);
            this.Controls.Add(this.displayAlg);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.selectAlg);
            this.Controls.Add(this.algName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SortDesktop";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label algName;
        private System.Windows.Forms.ComboBox selectAlg;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Panel displayAlg;
        private System.Windows.Forms.Button startSort;
    }
}

