namespace Note_Osiro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            btn_Task1 = new Button();
            btn_Task2 = new Button();
            buttonClose = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            textBoxCarrierFreq = new TextBox();
            label5 = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label4 = new Label();
            label6 = new Label();
            textBoxMabiki = new TextBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label7 = new Label();
            cbCh1Yrange = new ComboBox();
            panel1 = new Panel();
            label8 = new Label();
            cbCh2Yrange = new ComboBox();
            panel2 = new Panel();
            label9 = new Label();
            cbCh3Yrange = new ComboBox();
            panel3 = new Panel();
            label10 = new Label();
            cbCh4Yrange = new ComboBox();
            panel4 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(71, 90, 99);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(btn_Task1);
            flowLayoutPanel1.Controls.Add(btn_Task2);
            flowLayoutPanel1.Controls.Add(buttonClose);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8);
            flowLayoutPanel1.Size = new Size(1055, 52);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("ＭＳ ゴシック", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 8);
            label1.Name = "label1";
            label1.Size = new Size(636, 36);
            label1.TabIndex = 0;
            label1.Text = "グラフ表示デモ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_Task1
            // 
            btn_Task1.Enabled = false;
            btn_Task1.FlatStyle = FlatStyle.Flat;
            btn_Task1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btn_Task1.ForeColor = Color.White;
            btn_Task1.Location = new Point(650, 8);
            btn_Task1.Margin = new Padding(0);
            btn_Task1.Name = "btn_Task1";
            btn_Task1.Size = new Size(120, 36);
            btn_Task1.TabIndex = 1;
            btn_Task1.Text = "開始";
            btn_Task1.UseVisualStyleBackColor = true;
            btn_Task1.Click += btn_Task1_Click;
            // 
            // btn_Task2
            // 
            btn_Task2.FlatStyle = FlatStyle.Flat;
            btn_Task2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btn_Task2.ForeColor = Color.White;
            btn_Task2.Location = new Point(786, 8);
            btn_Task2.Margin = new Padding(16, 0, 0, 0);
            btn_Task2.Name = "btn_Task2";
            btn_Task2.Size = new Size(120, 36);
            btn_Task2.TabIndex = 2;
            btn_Task2.UseVisualStyleBackColor = true;
            btn_Task2.Click += btn_Task2_Click;
            // 
            // buttonClose
            // 
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(922, 8);
            buttonClose.Margin = new Padding(16, 0, 0, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(120, 36);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "終了";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Black;
            flowLayoutPanel3.Controls.Add(pictureBox1);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 52);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(16);
            flowLayoutPanel3.Size = new Size(1055, 601);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(16, 16);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1024, 400);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Black;
            flowLayoutPanel2.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel2.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel2.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel2.Location = new Point(16, 416);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1024, 163);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.FromArgb(71, 90, 99);
            flowLayoutPanel4.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel4.Controls.Add(label2);
            flowLayoutPanel4.Controls.Add(label3);
            flowLayoutPanel4.Controls.Add(textBoxCarrierFreq);
            flowLayoutPanel4.Controls.Add(label5);
            flowLayoutPanel4.Location = new Point(0, 8);
            flowLayoutPanel4.Margin = new Padding(0, 8, 8, 8);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(8);
            flowLayoutPanel4.Size = new Size(241, 148);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // label2
            // 
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.ForeColor = Color.White;
            label2.Location = new Point(8, 8);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(221, 21);
            label2.TabIndex = 0;
            label2.Text = "スレッド制御";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.ForeColor = Color.White;
            label3.Location = new Point(16, 37);
            label3.Margin = new Padding(8);
            label3.Name = "label3";
            label3.Size = new Size(53, 29);
            label3.TabIndex = 2;
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCarrierFreq
            // 
            textBoxCarrierFreq.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textBoxCarrierFreq.Location = new Point(77, 37);
            textBoxCarrierFreq.Margin = new Padding(0, 8, 0, 0);
            textBoxCarrierFreq.Name = "textBoxCarrierFreq";
            textBoxCarrierFreq.Size = new Size(75, 29);
            textBoxCarrierFreq.TabIndex = 1;
            textBoxCarrierFreq.Text = "1";
            textBoxCarrierFreq.TextAlign = HorizontalAlignment.Center;
            textBoxCarrierFreq.Validating += double_Validating;
            textBoxCarrierFreq.Validated += double_Validated;
            // 
            // label5
            // 
            label5.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.ForeColor = Color.White;
            label5.Location = new Point(160, 37);
            label5.Margin = new Padding(8);
            label5.Name = "label5";
            label5.Size = new Size(53, 29);
            label5.TabIndex = 4;
            label5.Text = "KHz";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.BackColor = Color.FromArgb(71, 90, 99);
            flowLayoutPanel5.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel5.Controls.Add(label4);
            flowLayoutPanel5.Controls.Add(label6);
            flowLayoutPanel5.Controls.Add(textBoxMabiki);
            flowLayoutPanel5.Location = new Point(257, 8);
            flowLayoutPanel5.Margin = new Padding(8);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Padding = new Padding(8);
            flowLayoutPanel5.Size = new Size(174, 148);
            flowLayoutPanel5.TabIndex = 5;
            // 
            // label4
            // 
            label4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.ForeColor = Color.White;
            label4.Location = new Point(8, 8);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(189, 21);
            label4.TabIndex = 0;
            label4.Text = "時間軸調整（間引き）";
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.ForeColor = Color.White;
            label6.Location = new Point(16, 37);
            label6.Margin = new Padding(8);
            label6.Name = "label6";
            label6.Size = new Size(14, 29);
            label6.TabIndex = 3;
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxMabiki
            // 
            textBoxMabiki.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textBoxMabiki.Location = new Point(42, 37);
            textBoxMabiki.Margin = new Padding(4, 8, 8, 8);
            textBoxMabiki.Name = "textBoxMabiki";
            textBoxMabiki.Size = new Size(74, 29);
            textBoxMabiki.TabIndex = 2;
            textBoxMabiki.Text = "1";
            textBoxMabiki.TextAlign = HorizontalAlignment.Center;
            textBoxMabiki.Validating += double_Validating;
            textBoxMabiki.Validated += double_Validated;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.BackColor = Color.FromArgb(71, 90, 99);
            flowLayoutPanel6.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel6.Controls.Add(label7);
            flowLayoutPanel6.Controls.Add(cbCh1Yrange);
            flowLayoutPanel6.Controls.Add(panel1);
            flowLayoutPanel6.Controls.Add(label8);
            flowLayoutPanel6.Controls.Add(cbCh2Yrange);
            flowLayoutPanel6.Controls.Add(panel2);
            flowLayoutPanel6.Controls.Add(label9);
            flowLayoutPanel6.Controls.Add(cbCh3Yrange);
            flowLayoutPanel6.Controls.Add(panel3);
            flowLayoutPanel6.Controls.Add(label10);
            flowLayoutPanel6.Controls.Add(cbCh4Yrange);
            flowLayoutPanel6.Controls.Add(panel4);
            flowLayoutPanel6.Location = new Point(447, 8);
            flowLayoutPanel6.Margin = new Padding(8);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Padding = new Padding(8);
            flowLayoutPanel6.Size = new Size(276, 148);
            flowLayoutPanel6.TabIndex = 6;
            // 
            // label7
            // 
            label7.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.ForeColor = Color.White;
            label7.Location = new Point(8, 8);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(127, 21);
            label7.TabIndex = 4;
            label7.Text = "CH1-Yrange";
            // 
            // cbCh1Yrange
            // 
            cbCh1Yrange.Font = new Font("Yu Gothic UI", 12F);
            cbCh1Yrange.FormattingEnabled = true;
            cbCh1Yrange.Items.AddRange(new object[] { "1", "10", "100", "200", "400" });
            cbCh1Yrange.Location = new Point(135, 8);
            cbCh1Yrange.Margin = new Padding(0);
            cbCh1Yrange.Name = "cbCh1Yrange";
            cbCh1Yrange.Size = new Size(80, 29);
            cbCh1Yrange.TabIndex = 0;
            cbCh1Yrange.Text = "1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lime;
            panel1.Location = new Point(215, 8);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(13, 29);
            panel1.TabIndex = 8;
            // 
            // label8
            // 
            label8.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label8.ForeColor = Color.White;
            label8.Location = new Point(8, 41);
            label8.Margin = new Padding(0, 4, 0, 0);
            label8.Name = "label8";
            label8.Size = new Size(127, 21);
            label8.TabIndex = 5;
            label8.Text = "CH2-Yrange";
            // 
            // cbCh2Yrange
            // 
            cbCh2Yrange.Font = new Font("Yu Gothic UI", 12F);
            cbCh2Yrange.FormattingEnabled = true;
            cbCh2Yrange.Items.AddRange(new object[] { "1", "10", "100", "200", "400" });
            cbCh2Yrange.Location = new Point(135, 41);
            cbCh2Yrange.Margin = new Padding(0, 4, 0, 0);
            cbCh2Yrange.Name = "cbCh2Yrange";
            cbCh2Yrange.Size = new Size(80, 29);
            cbCh2Yrange.TabIndex = 1;
            cbCh2Yrange.Text = "1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Location = new Point(215, 41);
            panel2.Margin = new Padding(0, 4, 0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(13, 29);
            panel2.TabIndex = 9;
            // 
            // label9
            // 
            label9.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label9.ForeColor = Color.White;
            label9.Location = new Point(8, 74);
            label9.Margin = new Padding(0, 4, 0, 0);
            label9.Name = "label9";
            label9.Size = new Size(127, 21);
            label9.TabIndex = 6;
            label9.Text = "CH3-Yrange";
            // 
            // cbCh3Yrange
            // 
            cbCh3Yrange.Font = new Font("Yu Gothic UI", 12F);
            cbCh3Yrange.FormattingEnabled = true;
            cbCh3Yrange.Items.AddRange(new object[] { "1", "10", "100", "200", "400" });
            cbCh3Yrange.Location = new Point(135, 74);
            cbCh3Yrange.Margin = new Padding(0, 4, 0, 0);
            cbCh3Yrange.Name = "cbCh3Yrange";
            cbCh3Yrange.Size = new Size(80, 29);
            cbCh3Yrange.TabIndex = 2;
            cbCh3Yrange.Text = "1";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 192, 192);
            panel3.Location = new Point(215, 74);
            panel3.Margin = new Padding(0, 4, 0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(13, 29);
            panel3.TabIndex = 10;
            // 
            // label10
            // 
            label10.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label10.ForeColor = Color.White;
            label10.Location = new Point(8, 107);
            label10.Margin = new Padding(0, 4, 0, 0);
            label10.Name = "label10";
            label10.Size = new Size(127, 21);
            label10.TabIndex = 7;
            label10.Text = "CH4-Yrange";
            // 
            // cbCh4Yrange
            // 
            cbCh4Yrange.Font = new Font("Yu Gothic UI", 12F);
            cbCh4Yrange.FormattingEnabled = true;
            cbCh4Yrange.Items.AddRange(new object[] { "1", "10", "100", "200", "400" });
            cbCh4Yrange.Location = new Point(135, 107);
            cbCh4Yrange.Margin = new Padding(0, 4, 0, 0);
            cbCh4Yrange.Name = "cbCh4Yrange";
            cbCh4Yrange.Size = new Size(80, 29);
            cbCh4Yrange.TabIndex = 3;
            cbCh4Yrange.Text = "1";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.Location = new Point(215, 107);
            panel4.Margin = new Padding(0, 4, 0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(13, 29);
            panel4.TabIndex = 11;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 653);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Button btn_Task1;
        private Button btn_Task2;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel3;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private FlowLayoutPanel flowLayoutPanel2;
        private ComboBox cbCh1Yrange;
        private ComboBox cbCh2Yrange;
        private ComboBox cbCh3Yrange;
        private ComboBox cbCh4Yrange;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label2;
        private TextBox textBoxCarrierFreq;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label4;
        private TextBox textBoxMabiki;
        private FlowLayoutPanel flowLayoutPanel6;
        private Button buttonClose;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel1;
        private Panel panel2;
        private Label label10;
        private Panel panel3;
        private Panel panel4;
    }
}
