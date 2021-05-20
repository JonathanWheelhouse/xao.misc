namespace IndexSimulator
{
    partial class frmIndexSimulator
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
            this.dtpCloseMkt = new System.Windows.Forms.DateTimePicker();
            this.dtpMktOpen = new System.Windows.Forms.DateTimePicker();
            this.btnCloseMkt = new System.Windows.Forms.Button();
            this.btnMktOpen = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.txtIndexMove = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoopNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIndexValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoopCnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIndexCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpCloseMkt
            // 
            this.dtpCloseMkt.CustomFormat = "dd-MMM-yyyy HH:mm:ss ";
            this.dtpCloseMkt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCloseMkt.Location = new System.Drawing.Point(298, 138);
            this.dtpCloseMkt.Name = "dtpCloseMkt";
            this.dtpCloseMkt.Size = new System.Drawing.Size(151, 20);
            this.dtpCloseMkt.TabIndex = 41;
            // 
            // dtpMktOpen
            // 
            this.dtpMktOpen.CustomFormat = "dd-MMM-yyyy HH:mm:ss ";
            this.dtpMktOpen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMktOpen.Location = new System.Drawing.Point(298, 76);
            this.dtpMktOpen.Name = "dtpMktOpen";
            this.dtpMktOpen.Size = new System.Drawing.Size(151, 20);
            this.dtpMktOpen.TabIndex = 40;
            // 
            // btnCloseMkt
            // 
            this.btnCloseMkt.Location = new System.Drawing.Point(167, 131);
            this.btnCloseMkt.Name = "btnCloseMkt";
            this.btnCloseMkt.Size = new System.Drawing.Size(107, 34);
            this.btnCloseMkt.TabIndex = 39;
            this.btnCloseMkt.Text = "Close Market";
            this.btnCloseMkt.UseVisualStyleBackColor = true;
            this.btnCloseMkt.Click += new System.EventHandler(this.btnCloseMkt_Click);
            // 
            // btnMktOpen
            // 
            this.btnMktOpen.Location = new System.Drawing.Point(167, 69);
            this.btnMktOpen.Name = "btnMktOpen";
            this.btnMktOpen.Size = new System.Drawing.Size(107, 34);
            this.btnMktOpen.TabIndex = 38;
            this.btnMktOpen.Text = "Open Market";
            this.btnMktOpen.UseVisualStyleBackColor = true;
            this.btnMktOpen.Click += new System.EventHandler(this.btnMktOpen_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(421, 370);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(107, 34);
            this.btnResume.TabIndex = 37;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // txtIndexMove
            // 
            this.txtIndexMove.Location = new System.Drawing.Point(463, 289);
            this.txtIndexMove.Name = "txtIndexMove";
            this.txtIndexMove.ReadOnly = true;
            this.txtIndexMove.Size = new System.Drawing.Size(83, 20);
            this.txtIndexMove.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(329, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "Index Movement";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLoopNum
            // 
            this.txtLoopNum.Location = new System.Drawing.Point(463, 326);
            this.txtLoopNum.Name = "txtLoopNum";
            this.txtLoopNum.ReadOnly = true;
            this.txtLoopNum.Size = new System.Drawing.Size(83, 20);
            this.txtLoopNum.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(329, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Loop Count";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndexValue
            // 
            this.txtIndexValue.Location = new System.Drawing.Point(463, 251);
            this.txtIndexValue.Name = "txtIndexValue";
            this.txtIndexValue.ReadOnly = true;
            this.txtIndexValue.Size = new System.Drawing.Size(83, 20);
            this.txtIndexValue.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(329, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Index Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLoopCnt
            // 
            this.txtLoopCnt.Location = new System.Drawing.Point(222, 326);
            this.txtLoopCnt.Name = "txtLoopCnt";
            this.txtLoopCnt.Size = new System.Drawing.Size(83, 20);
            this.txtLoopCnt.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(88, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Number of Loops";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(490, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 34);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(291, 370);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(107, 34);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "Pause";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(150, 370);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 34);
            this.btnStart.TabIndex = 27;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(222, 289);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(83, 20);
            this.txtInterval.TabIndex = 24;
            this.txtInterval.Text = "0";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(88, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Time Interval";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndexCode
            // 
            this.txtIndexCode.Location = new System.Drawing.Point(222, 252);
            this.txtIndexCode.Name = "txtIndexCode";
            this.txtIndexCode.Size = new System.Drawing.Size(83, 20);
            this.txtIndexCode.TabIndex = 23;
            this.txtIndexCode.Text = "XAO";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(88, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Index Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmIndexSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 556);
            this.Controls.Add(this.dtpCloseMkt);
            this.Controls.Add(this.dtpMktOpen);
            this.Controls.Add(this.btnCloseMkt);
            this.Controls.Add(this.btnMktOpen);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.txtIndexMove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLoopNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIndexValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLoopCnt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIndexCode);
            this.Controls.Add(this.label1);
            this.Name = "frmIndexSimulator";
            this.Text = "Index Stimulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCloseMkt;
        private System.Windows.Forms.DateTimePicker dtpMktOpen;
        private System.Windows.Forms.Button btnCloseMkt;
        private System.Windows.Forms.Button btnMktOpen;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.TextBox txtIndexMove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoopNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIndexValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoopCnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIndexCode;
        private System.Windows.Forms.Label label1;
    }
}

