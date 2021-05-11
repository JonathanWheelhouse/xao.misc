namespace TestMySQL
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
            this.btnGet = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvOracleUsers = new System.Windows.Forms.DataGridView();
            this.btnMigrate = new System.Windows.Forms.Button();
            this.btnPicks = new System.Windows.Forms.Button();
            this.btnMySqlPicks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOracleUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(12, 12);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(154, 35);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Get me Users from MySql";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 91);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Size = new System.Drawing.Size(521, 155);
            this.dgvUsers.TabIndex = 1;
            // 
            // dgvOracleUsers
            // 
            this.dgvOracleUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOracleUsers.Location = new System.Drawing.Point(12, 368);
            this.dgvOracleUsers.Name = "dgvOracleUsers";
            this.dgvOracleUsers.Size = new System.Drawing.Size(521, 170);
            this.dgvOracleUsers.TabIndex = 2;
            // 
            // btnMigrate
            // 
            this.btnMigrate.Location = new System.Drawing.Point(12, 301);
            this.btnMigrate.Name = "btnMigrate";
            this.btnMigrate.Size = new System.Drawing.Size(160, 46);
            this.btnMigrate.TabIndex = 3;
            this.btnMigrate.Text = "Migrate User Data";
            this.btnMigrate.UseVisualStyleBackColor = true;
            this.btnMigrate.Click += new System.EventHandler(this.btnMigrate_Click);
            // 
            // btnPicks
            // 
            this.btnPicks.Location = new System.Drawing.Point(217, 301);
            this.btnPicks.Name = "btnPicks";
            this.btnPicks.Size = new System.Drawing.Size(160, 46);
            this.btnPicks.TabIndex = 4;
            this.btnPicks.Text = "Migrate Picks Data";
            this.btnPicks.UseVisualStyleBackColor = true;
            this.btnPicks.Click += new System.EventHandler(this.btnPicks_Click);
            // 
            // btnMySqlPicks
            // 
            this.btnMySqlPicks.Location = new System.Drawing.Point(217, 12);
            this.btnMySqlPicks.Name = "btnMySqlPicks";
            this.btnMySqlPicks.Size = new System.Drawing.Size(154, 35);
            this.btnMySqlPicks.TabIndex = 5;
            this.btnMySqlPicks.Text = "Get me Picks from MySql";
            this.btnMySqlPicks.UseVisualStyleBackColor = true;
            this.btnMySqlPicks.Click += new System.EventHandler(this.btnMySqlPicks_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 580);
            this.Controls.Add(this.btnMySqlPicks);
            this.Controls.Add(this.btnPicks);
            this.Controls.Add(this.btnMigrate);
            this.Controls.Add(this.dgvOracleUsers);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnGet);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOracleUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvOracleUsers;
        private System.Windows.Forms.Button btnMigrate;
        private System.Windows.Forms.Button btnPicks;
        private System.Windows.Forms.Button btnMySqlPicks;
    }
}

