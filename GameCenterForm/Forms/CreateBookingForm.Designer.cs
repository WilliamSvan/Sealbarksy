namespace GameCenterForm.Forms
{
    partial class CreateBookingForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cBoxConsoleType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lBoxTimeSlot = new System.Windows.Forms.ListBox();
            this.mCalendarReservation = new System.Windows.Forms.MonthCalendar();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(65)))), ((int)(((byte)(111)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 117);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make a Reservation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxPaymentMethod);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cBoxConsoleType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cBoxCustomer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lBoxTimeSlot);
            this.groupBox1.Controls.Add(this.mCalendarReservation);
            this.groupBox1.Location = new System.Drawing.Point(198, 117);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(621, 524);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // cBoxPaymentMethod
            // 
            this.cBoxPaymentMethod.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cBoxPaymentMethod.FormattingEnabled = true;
            this.cBoxPaymentMethod.Items.AddRange(new object[] {
            "Credit Card",
            "Swish",
            "Klarna",
            "PayPal",
            "Cash "});
            this.cBoxPaymentMethod.Location = new System.Drawing.Point(211, 448);
            this.cBoxPaymentMethod.Name = "cBoxPaymentMethod";
            this.cBoxPaymentMethod.Size = new System.Drawing.Size(227, 31);
            this.cBoxPaymentMethod.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(40, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 28);
            this.label7.TabIndex = 28;
            this.label7.Text = "Payment Method:";
            // 
            // cBoxConsoleType
            // 
            this.cBoxConsoleType.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cBoxConsoleType.FormattingEnabled = true;
            this.cBoxConsoleType.Location = new System.Drawing.Point(211, 91);
            this.cBoxConsoleType.Name = "cBoxConsoleType";
            this.cBoxConsoleType.Size = new System.Drawing.Size(227, 31);
            this.cBoxConsoleType.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(79, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "Console Type:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(211, 392);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(27, 28);
            this.lblPrice.TabIndex = 25;
            this.lblPrice.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(136, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 28);
            this.label3.TabIndex = 24;
            this.label3.Text = "Price:";
            // 
            // cBoxCustomer
            // 
            this.cBoxCustomer.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cBoxCustomer.FormattingEnabled = true;
            this.cBoxCustomer.Location = new System.Drawing.Point(211, 44);
            this.cBoxCustomer.Name = "cBoxCustomer";
            this.cBoxCustomer.Size = new System.Drawing.Size(227, 31);
            this.cBoxCustomer.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(104, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Customer:";
            // 
            // lBoxTimeSlot
            // 
            this.lBoxTimeSlot.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lBoxTimeSlot.FormattingEnabled = true;
            this.lBoxTimeSlot.ItemHeight = 23;
            this.lBoxTimeSlot.Location = new System.Drawing.Point(493, 140);
            this.lBoxTimeSlot.Name = "lBoxTimeSlot";
            this.lBoxTimeSlot.Size = new System.Drawing.Size(86, 165);
            this.lBoxTimeSlot.TabIndex = 21;
            this.lBoxTimeSlot.SelectedIndexChanged += new System.EventHandler(this.lBoxTimeSlot_SelectedIndexChanged);
            // 
            // mCalendarReservation
            // 
            this.mCalendarReservation.Location = new System.Drawing.Point(199, 140);
            this.mCalendarReservation.MinDate = new System.DateTime(2023, 2, 22, 0, 0, 0, 0);
            this.mCalendarReservation.Name = "mCalendarReservation";
            this.mCalendarReservation.TabIndex = 20;
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoBack.Location = new System.Drawing.Point(357, 679);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(127, 60);
            this.btnGoBack.TabIndex = 20;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNext.Location = new System.Drawing.Point(519, 679);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(127, 60);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // CreateBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 828);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnNext);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Booking";
            this.Load += new System.EventHandler(this.CreateBookingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cBoxPaymentMethod;
        private Label label7;
        private ComboBox cBoxConsoleType;
        private Label label5;
        private Label lblPrice;
        private Label label3;
        private ComboBox cBoxCustomer;
        private Label label2;
        private ListBox lBoxTimeSlot;
        private MonthCalendar mCalendarReservation;
        private Button btnGoBack;
        private Button btnNext;
    }
}