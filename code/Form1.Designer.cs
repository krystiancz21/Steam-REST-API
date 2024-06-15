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
            button1 = new Button();
            button2 = new Button();
            infoLabel = new Label();
            button3 = new Button();
            label1 = new Label();
            SteamIdTextBox = new TextBox();
            label2 = new Label();
            ApiKeyTextBox = new TextBox();
            button4 = new Button();
            button5 = new Button();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            label6 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(761, 28);
            button1.Name = "button1";
            button1.Size = new Size(160, 34);
            button1.TabIndex = 0;
            button1.Text = "Pobierz dane z API";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(806, 154);
            button2.Name = "button2";
            button2.Size = new Size(95, 34);
            button2.TabIndex = 2;
            button2.Text = "JSON";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(44, 73);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(0, 20);
            infoLabel.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(907, 154);
            button3.Name = "button3";
            button3.Size = new Size(95, 34);
            button3.TabIndex = 4;
            button3.Text = "XML";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 32);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 5;
            label1.Text = "SteamID:";
            // 
            // SteamIdTextBox
            // 
            SteamIdTextBox.Location = new Point(128, 32);
            SteamIdTextBox.Name = "SteamIdTextBox";
            SteamIdTextBox.Size = new Size(200, 27);
            SteamIdTextBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(363, 35);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 7;
            label2.Text = "API key:";
            // 
            // ApiKeyTextBox
            // 
            ApiKeyTextBox.Location = new Point(429, 32);
            ApiKeyTextBox.Name = "ApiKeyTextBox";
            ApiKeyTextBox.Size = new Size(320, 27);
            ApiKeyTextBox.TabIndex = 8;
            // 
            // button4
            // 
            button4.Location = new Point(806, 225);
            button4.Name = "button4";
            button4.Size = new Size(95, 34);
            button4.TabIndex = 9;
            button4.Text = "JSON";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(907, 225);
            button5.Name = "button5";
            button5.Size = new Size(95, 34);
            button5.TabIndex = 10;
            button5.Text = "XML";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 108);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 11;
            label3.Text = "Użytkownicy";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(49, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(702, 190);
            dataGridView1.TabIndex = 12;
            // 
            // button6
            // 
            button6.Location = new Point(806, 276);
            button6.Name = "button6";
            button6.Size = new Size(196, 45);
            button6.TabIndex = 13;
            button6.Text = "Wyświetl dane";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 338);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 14;
            label4.Text = "Gry";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(49, 361);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(953, 219);
            dataGridView2.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(816, 201);
            label6.Name = "label6";
            label6.Size = new Size(175, 20);
            label6.TabIndex = 17;
            label6.Text = "Wczytaj dane w formacie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(817, 129);
            label5.Name = "label5";
            label5.Size = new Size(173, 20);
            label5.TabIndex = 19;
            label5.Text = "Pobierz dane w formacie";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 615);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(dataGridView2);
            Controls.Add(label4);
            Controls.Add(button6);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(ApiKeyTextBox);
            Controls.Add(label2);
            Controls.Add(SteamIdTextBox);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(infoLabel);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Steam APP";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label6;
        private Label label5;
    }
}