namespace Shop_Management_System
{
    partial class HistoryUC
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.eCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelInfo.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Black;
            this.labelInfo.Location = new System.Drawing.Point(193, 47);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(186, 50);
            this.labelInfo.TabIndex = 45;
            this.labelInfo.Text = "My History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eCode,
            this.eName,
            this.eOrder,
            this.eBill});
            this.dataGridView1.Location = new System.Drawing.Point(12, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(573, 281);
            this.dataGridView1.TabIndex = 46;
            // 
            // eCode
            // 
            this.eCode.DataPropertyName = "product_code";
            this.eCode.HeaderText = "Product Code";
            this.eCode.Name = "eCode";
            this.eCode.ReadOnly = true;
            // 
            // eName
            // 
            this.eName.DataPropertyName = "product_name";
            this.eName.HeaderText = "Product Name";
            this.eName.Name = "eName";
            this.eName.ReadOnly = true;
            // 
            // eOrder
            // 
            this.eOrder.DataPropertyName = "order_quantity";
            this.eOrder.HeaderText = "My order quantity";
            this.eOrder.Name = "eOrder";
            this.eOrder.ReadOnly = true;
            // 
            // eBill
            // 
            this.eBill.DataPropertyName = "total_bill";
            this.eBill.HeaderText = "Bill";
            this.eBill.Name = "eBill";
            this.eBill.ReadOnly = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(193, 140);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(84, 23);
            this.buttonRefresh.TabIndex = 49;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteAll.Location = new System.Drawing.Point(298, 140);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(113, 23);
            this.buttonDeleteAll.TabIndex = 50;
            this.buttonDeleteAll.Text = "Delete All";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // HistoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Shop_Management_System.Properties.Resources.con4;
            this.Controls.Add(this.buttonDeleteAll);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelInfo);
            this.Name = "HistoryUC";
            this.Size = new System.Drawing.Size(600, 500);
            this.Load += new System.EventHandler(this.HistoryUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn eName;
        private System.Windows.Forms.DataGridViewTextBoxColumn eOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn eBill;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDeleteAll;

    }
}
