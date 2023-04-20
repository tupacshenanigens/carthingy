
namespace StupidCar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picCar = new System.Windows.Forms.PictureBox();
            this.picObstruction = new System.Windows.Forms.PictureBox();
            this.tmrMoveCar = new System.Windows.Forms.Timer(this.components);
            this.picObstruction2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picObstruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picObstruction2)).BeginInit();
            this.SuspendLayout();
            // 
            // picCar
            // 
            this.picCar.Image = ((System.Drawing.Image)(resources.GetObject("picCar.Image")));
            this.picCar.Location = new System.Drawing.Point(227, 165);
            this.picCar.Margin = new System.Windows.Forms.Padding(2);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(57, 28);
            this.picCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCar.TabIndex = 0;
            this.picCar.TabStop = false;
            this.picCar.Click += new System.EventHandler(this.picCar_Click);
            // 
            // picObstruction
            // 
            this.picObstruction.Image = ((System.Drawing.Image)(resources.GetObject("picObstruction.Image")));
            this.picObstruction.Location = new System.Drawing.Point(512, 139);
            this.picObstruction.Margin = new System.Windows.Forms.Padding(2);
            this.picObstruction.Name = "picObstruction";
            this.picObstruction.Size = new System.Drawing.Size(63, 54);
            this.picObstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picObstruction.TabIndex = 1;
            this.picObstruction.TabStop = false;
            this.picObstruction.Tag = "obstruction";
            // 
            // tmrMoveCar
            // 
            this.tmrMoveCar.Enabled = true;
            this.tmrMoveCar.Interval = 10;
            this.tmrMoveCar.Tick += new System.EventHandler(this.tmrMoveCar_Tick);
            // 
            // picObstruction2
            // 
            this.picObstruction2.Image = ((System.Drawing.Image)(resources.GetObject("picObstruction2.Image")));
            this.picObstruction2.Location = new System.Drawing.Point(320, 259);
            this.picObstruction2.Margin = new System.Windows.Forms.Padding(2);
            this.picObstruction2.Name = "picObstruction2";
            this.picObstruction2.Size = new System.Drawing.Size(63, 54);
            this.picObstruction2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picObstruction2.TabIndex = 2;
            this.picObstruction2.TabStop = false;
            this.picObstruction2.Tag = "obstruction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "P = random waypoint\r\nLeft Click = waypoint at cursor\r\nD = autodrive\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(751, 521);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picObstruction2);
            this.Controls.Add(this.picObstruction);
            this.Controls.Add(this.picCar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "This Car Is Probably Broken As Well";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picObstruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picObstruction2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.PictureBox picObstruction;
        private System.Windows.Forms.Timer tmrMoveCar;
        private System.Windows.Forms.PictureBox picObstruction2;
        private System.Windows.Forms.Label label1;
    }
}

