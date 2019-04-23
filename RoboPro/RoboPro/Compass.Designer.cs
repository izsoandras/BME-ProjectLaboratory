namespace RoboPro
{
    partial class Compass
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNorth = new System.Windows.Forms.Label();
            this.labelEast = new System.Windows.Forms.Label();
            this.labelWest = new System.Windows.Forms.Label();
            this.labelSouth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNorth
            // 
            this.labelNorth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNorth.AutoSize = true;
            this.labelNorth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNorth.Location = new System.Drawing.Point(65, 7);
            this.labelNorth.Name = "labelNorth";
            this.labelNorth.Size = new System.Drawing.Size(19, 17);
            this.labelNorth.TabIndex = 0;
            this.labelNorth.Text = "N";
            // 
            // labelEast
            // 
            this.labelEast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEast.AutoSize = true;
            this.labelEast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEast.Location = new System.Drawing.Point(124, 66);
            this.labelEast.Name = "labelEast";
            this.labelEast.Size = new System.Drawing.Size(18, 17);
            this.labelEast.TabIndex = 1;
            this.labelEast.Text = "E";
            // 
            // labelWest
            // 
            this.labelWest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWest.AutoSize = true;
            this.labelWest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWest.Location = new System.Drawing.Point(8, 66);
            this.labelWest.Name = "labelWest";
            this.labelWest.Size = new System.Drawing.Size(22, 17);
            this.labelWest.TabIndex = 2;
            this.labelWest.Text = "W";
            // 
            // labelSouth
            // 
            this.labelSouth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSouth.AutoSize = true;
            this.labelSouth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSouth.Location = new System.Drawing.Point(66, 124);
            this.labelSouth.Name = "labelSouth";
            this.labelSouth.Size = new System.Drawing.Size(18, 17);
            this.labelSouth.TabIndex = 3;
            this.labelSouth.Text = "S";
            // 
            // Compass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelWest);
            this.Controls.Add(this.labelSouth);
            this.Controls.Add(this.labelEast);
            this.Controls.Add(this.labelNorth);
            this.Name = "Compass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNorth;
        private System.Windows.Forms.Label labelEast;
        private System.Windows.Forms.Label labelWest;
        private System.Windows.Forms.Label labelSouth;
    }
}
