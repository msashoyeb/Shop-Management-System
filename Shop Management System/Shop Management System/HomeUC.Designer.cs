namespace Shop_Management_System
{
    partial class HomeUC
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
            this.LabelLogout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelLogout
            // 
            this.LabelLogout.AutoSize = true;
            this.LabelLogout.BackColor = System.Drawing.Color.Transparent;
            this.LabelLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelLogout.Font = new System.Drawing.Font("Bahnschrift SemiBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLogout.ForeColor = System.Drawing.Color.Black;
            this.LabelLogout.Location = new System.Drawing.Point(110, 186);
            this.LabelLogout.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LabelLogout.Name = "LabelLogout";
            this.LabelLogout.Size = new System.Drawing.Size(378, 46);
            this.LabelLogout.TabIndex = 35;
            this.LabelLogout.Text = "Welcome to our shop";
            // 
            // HomeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Shop_Management_System.Properties.Resources.con4;
            this.Controls.Add(this.LabelLogout);
            this.Name = "HomeUC";
            this.Size = new System.Drawing.Size(640, 498);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelLogout;


    }
}
