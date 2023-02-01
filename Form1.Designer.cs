namespace SteamFormsAppV1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SteamIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(837, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wyślij do bazy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(837, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Pobierz JSON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(44, 73);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 20);
            this.infoLabel.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(837, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "Pobierz XML";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "SteamID:";
            // 
            // SteamIdTextBox
            // 
            this.SteamIdTextBox.Location = new System.Drawing.Point(128, 32);
            this.SteamIdTextBox.Name = "SteamIdTextBox";
            this.SteamIdTextBox.Size = new System.Drawing.Size(200, 27);
            this.SteamIdTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "API key:";
            // 
            // ApiKeyTextBox
            // 
            this.ApiKeyTextBox.Location = new System.Drawing.Point(466, 32);
            this.ApiKeyTextBox.Name = "ApiKeyTextBox";
            this.ApiKeyTextBox.Size = new System.Drawing.Size(320, 27);
            this.ApiKeyTextBox.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(837, 185);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 45);
            this.button4.TabIndex = 9;
            this.button4.Text = "Wyślij JSON";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(837, 236);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 45);
            this.button5.TabIndex = 10;
            this.button5.Text = "Wyślij XML";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Użytkownicy:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(702, 190);
            this.dataGridView1.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(837, 287);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 45);
            this.button6.TabIndex = 13;
            this.button6.Text = "Wyświetl dane";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Gry:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(49, 361);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(953, 219);
            this.dataGridView2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 615);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ApiKeyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SteamIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Steam APP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        public Label infoLabel;
        private Button button3;
        private Label label1;
        public TextBox SteamIdTextBox;
        private Label label2;
        public TextBox ApiKeyTextBox;
        private Button button4;
        private Button button5;
        private Label label3;
        private DataGridView dataGridView1;
        private Button button6;
        private Label label4;
        private DataGridView dataGridView2;
    }
}