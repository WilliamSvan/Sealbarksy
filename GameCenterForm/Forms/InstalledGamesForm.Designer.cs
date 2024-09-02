namespace GameCenterForm.Forms
{
    partial class InstalledGamesForm
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
            this.unInstallGame = new System.Windows.Forms.Button();
            this.installGame = new System.Windows.Forms.Button();
            this.dataGridViewInstalledGames = new System.Windows.Forms.DataGridView();
            this.cbConsole = new System.Windows.Forms.ComboBox();
            this.lblConsoleSearch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUnInstall = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstalledGames)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(65)))), ((int)(((byte)(111)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 117);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(768, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage and View Installed Games on Consoles\r\n";
            // 
            // unInstallGame
            // 
            this.unInstallGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.unInstallGame.FlatAppearance.BorderSize = 0;
            this.unInstallGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unInstallGame.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.unInstallGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.unInstallGame.Location = new System.Drawing.Point(712, 513);
            this.unInstallGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.unInstallGame.Name = "unInstallGame";
            this.unInstallGame.Size = new System.Drawing.Size(113, 39);
            this.unInstallGame.TabIndex = 34;
            this.unInstallGame.Text = "Uninstall";
            this.unInstallGame.UseVisualStyleBackColor = false;
            this.unInstallGame.Click += new System.EventHandler(this.unInstallGame_Click);
            // 
            // installGame
            // 
            this.installGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.installGame.FlatAppearance.BorderSize = 0;
            this.installGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installGame.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.installGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.installGame.Location = new System.Drawing.Point(712, 427);
            this.installGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.installGame.Name = "installGame";
            this.installGame.Size = new System.Drawing.Size(113, 39);
            this.installGame.TabIndex = 32;
            this.installGame.Text = "Install";
            this.installGame.UseVisualStyleBackColor = false;
            this.installGame.Click += new System.EventHandler(this.installGame_Click);
            // 
            // dataGridViewInstalledGames
            // 
            this.dataGridViewInstalledGames.AllowUserToAddRows = false;
            this.dataGridViewInstalledGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInstalledGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstalledGames.Location = new System.Drawing.Point(14, 203);
            this.dataGridViewInstalledGames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewInstalledGames.Name = "dataGridViewInstalledGames";
            this.dataGridViewInstalledGames.ReadOnly = true;
            this.dataGridViewInstalledGames.RowHeadersWidth = 51;
            this.dataGridViewInstalledGames.RowTemplate.Height = 25;
            this.dataGridViewInstalledGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInstalledGames.Size = new System.Drawing.Size(374, 551);
            this.dataGridViewInstalledGames.TabIndex = 30;
            this.dataGridViewInstalledGames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInstalledGames_CellClick);
            // 
            // cbConsole
            // 
            this.cbConsole.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbConsole.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbConsole.ForeColor = System.Drawing.Color.Black;
            this.cbConsole.FormattingEnabled = true;
            this.cbConsole.Location = new System.Drawing.Point(487, 216);
            this.cbConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbConsole.Name = "cbConsole";
            this.cbConsole.Size = new System.Drawing.Size(198, 36);
            this.cbConsole.TabIndex = 35;
            this.cbConsole.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbConsole_DrawItem);
            this.cbConsole.SelectedIndexChanged += new System.EventHandler(this.cbConsole_SelectedIndexChanged);
            // 
            // lblConsoleSearch
            // 
            this.lblConsoleSearch.AutoSize = true;
            this.lblConsoleSearch.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConsoleSearch.Location = new System.Drawing.Point(394, 219);
            this.lblConsoleSearch.Name = "lblConsoleSearch";
            this.lblConsoleSearch.Size = new System.Drawing.Size(91, 28);
            this.lblConsoleSearch.TabIndex = 36;
            this.lblConsoleSearch.Text = "Console:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(487, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 38;
            this.label2.Text = "Game:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbGame
            // 
            this.cbGame.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbGame.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbGame.ForeColor = System.Drawing.Color.Black;
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Location = new System.Drawing.Point(487, 428);
            this.cbGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(198, 36);
            this.cbGame.TabIndex = 37;
            this.cbGame.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbGame_DrawItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(474, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 28);
            this.label3.TabIndex = 39;
            this.label3.Text = "Search for Console or Game or both\r\n";
            // 
            // cbUnInstall
            // 
            this.cbUnInstall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbUnInstall.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbUnInstall.ForeColor = System.Drawing.Color.Black;
            this.cbUnInstall.FormattingEnabled = true;
            this.cbUnInstall.Location = new System.Drawing.Point(487, 515);
            this.cbUnInstall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUnInstall.Name = "cbUnInstall";
            this.cbUnInstall.Size = new System.Drawing.Size(198, 36);
            this.cbUnInstall.TabIndex = 40;
            this.cbUnInstall.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbUnInstall_DrawItem);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(712, 219);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 39);
            this.btnReset.TabIndex = 41;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // InstalledGamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(986, 769);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbUnInstall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGame);
            this.Controls.Add(this.lblConsoleSearch);
            this.Controls.Add(this.cbConsole);
            this.Controls.Add(this.unInstallGame);
            this.Controls.Add(this.installGame);
            this.Controls.Add(this.dataGridViewInstalledGames);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InstalledGamesForm";
            this.Text = "InstalledGamesForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstalledGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button unInstallGame;
        private Button installGame;
        private DataGridView dataGridViewInstalledGames;
        private ComboBox cbConsole;
        private Label lblConsoleSearch;
        private Label label2;
        private ComboBox cbGame;
        private Label label3;
        private ComboBox cbUnInstall;
        private Button btnReset;
    }
}