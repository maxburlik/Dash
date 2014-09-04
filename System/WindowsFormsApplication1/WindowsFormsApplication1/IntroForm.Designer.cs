namespace WindowsFormsApplication1
{
    partial class IntroForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ProgressIncrementButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.SaveToDBButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.LoadFromDBButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ProgressIncrementButton
            // 
            this.ProgressIncrementButton.Location = new System.Drawing.Point(196, 12);
            this.ProgressIncrementButton.Name = "ProgressIncrementButton";
            this.ProgressIncrementButton.Size = new System.Drawing.Size(103, 23);
            this.ProgressIncrementButton.TabIndex = 6;
            this.ProgressIncrementButton.Text = "ProgressIncrement";
            this.ProgressIncrementButton.UseVisualStyleBackColor = true;
            this.ProgressIncrementButton.Click += new System.EventHandler(this.ProgressIncrementButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(12, 12);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(111, 23);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "Load File";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(287, 136);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // SaveToDBButton
            // 
            this.SaveToDBButton.Location = new System.Drawing.Point(12, 183);
            this.SaveToDBButton.Name = "SaveToDBButton";
            this.SaveToDBButton.Size = new System.Drawing.Size(91, 23);
            this.SaveToDBButton.TabIndex = 3;
            this.SaveToDBButton.Text = "Save to DB";
            this.SaveToDBButton.UseVisualStyleBackColor = true;
            this.SaveToDBButton.Click += new System.EventHandler(this.SaveToDBButton_Click);
            // 
            // LoadFromDBButton
            // 
            this.LoadFromDBButton.Location = new System.Drawing.Point(109, 183);
            this.LoadFromDBButton.Name = "LoadFromDBButton";
            this.LoadFromDBButton.Size = new System.Drawing.Size(99, 23);
            this.LoadFromDBButton.TabIndex = 4;
            this.LoadFromDBButton.Text = "Load from DB";
            this.LoadFromDBButton.UseVisualStyleBackColor = true;
            this.LoadFromDBButton.Click += new System.EventHandler(this.LoadFromDBButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(214, 183);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(85, 23);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(311, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Status strip";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 236);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.LoadFromDBButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.SaveToDBButton);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.ProgressIncrementButton);
            this.Name = "IntroForm";
            this.Text = "Text DB Loader Application";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ProgressIncrementButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Button SaveToDBButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button LoadFromDBButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button ClearButton;


    }
}