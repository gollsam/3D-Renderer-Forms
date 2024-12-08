namespace _3D_Graphics_Engine_Forms
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PosX = new System.Windows.Forms.Label();
            this.PosY = new System.Windows.Forms.Label();
            this.PosZ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.Olive;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "3D-Graphics-Engine";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.Olive;
            this.label2.Location = new System.Drawing.Point(0, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "C#";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.dateLabel.ForeColor = System.Drawing.Color.Olive;
            this.dateLabel.Location = new System.Drawing.Point(0, 36);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(33, 16);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "CameraInfo";
            // 
            // PosX
            // 
            this.PosX.AutoSize = true;
            this.PosX.Location = new System.Drawing.Point(12, 196);
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(51, 13);
            this.PosX.TabIndex = 4;
            this.PosX.Text = "PositionX";
            // 
            // PosY
            // 
            this.PosY.AutoSize = true;
            this.PosY.Location = new System.Drawing.Point(12, 209);
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(51, 13);
            this.PosY.TabIndex = 5;
            this.PosY.Text = "PositionY";
            // 
            // PosZ
            // 
            this.PosZ.AutoSize = true;
            this.PosZ.Location = new System.Drawing.Point(12, 222);
            this.PosZ.Name = "PosZ";
            this.PosZ.Size = new System.Drawing.Size(51, 13);
            this.PosZ.TabIndex = 6;
            this.PosZ.Text = "PositionZ";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1064, 661);
            this.Controls.Add(this.PosZ);
            this.Controls.Add(this.PosY);
            this.Controls.Add(this.PosX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Linear Algebra - 3D Graphics Engine";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyLifted);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PosX;
        private System.Windows.Forms.Label PosY;
        private System.Windows.Forms.Label PosZ;
    }
}

