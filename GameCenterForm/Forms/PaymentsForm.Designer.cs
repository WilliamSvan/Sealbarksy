namespace GameCenterForm.Forms
{
    partial class PaymentsForm
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
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.tBoxPaymentSearch = new System.Windows.Forms.TextBox();
            this.lblPaymentsSearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.AllowUserToAddRows = false;
            this.dataGridViewPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Location = new System.Drawing.Point(12, 153);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.ReadOnly = true;
            this.dataGridViewPayments.RowTemplate.Height = 25;
            this.dataGridViewPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPayments.Size = new System.Drawing.Size(701, 412);
            this.dataGridViewPayments.TabIndex = 28;
            this.dataGridViewPayments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPayments_CellClick);
            // 
            // tBoxPaymentSearch
            // 
            this.tBoxPaymentSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tBoxPaymentSearch.Location = new System.Drawing.Point(12, 118);
            this.tBoxPaymentSearch.Name = "tBoxPaymentSearch";
            this.tBoxPaymentSearch.Size = new System.Drawing.Size(701, 29);
            this.tBoxPaymentSearch.TabIndex = 27;
            this.tBoxPaymentSearch.TextChanged += new System.EventHandler(this.tBoxPaymentSearch_TextChanged);
            // 
            // lblPaymentsSearch
            // 
            this.lblPaymentsSearch.AutoSize = true;
            this.lblPaymentsSearch.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentsSearch.Location = new System.Drawing.Point(12, 96);
            this.lblPaymentsSearch.Name = "lblPaymentsSearch";
            this.lblPaymentsSearch.Size = new System.Drawing.Size(143, 21);
            this.lblPaymentsSearch.TabIndex = 26;
            this.lblPaymentsSearch.Text = "Search Payments:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(65)))), ((int)(((byte)(111)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 88);
            this.panel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payments";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(740, 534);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 29);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 577);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewPayments);
            this.Controls.Add(this.tBoxPaymentSearch);
            this.Controls.Add(this.lblPaymentsSearch);
            this.Controls.Add(this.panel1);
            this.Name = "PaymentsForm";
            this.Text = "Payments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataGridViewPayments;

        private TextBox tBoxPaymentSearch;

        private Label lblPaymentsSearch;
        private Panel panel1;
        private Label label1;
        private Button btnDelete;
    }
}