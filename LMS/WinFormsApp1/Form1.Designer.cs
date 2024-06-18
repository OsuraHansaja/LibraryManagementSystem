namespace WinFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            textBoxUserName = new TextBox();
            textBoxPassword = new TextBox();
            dataGridViewBooks = new DataGridView();
            buttonManageBooks = new Button();
            buttonTransactions = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(60, 124);
            label1.Name = "label1";
            label1.Size = new Size(73, 22);
            label1.TabIndex = 0;
            label1.Text = "User Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(60, 207);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 1;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUserName.Location = new Point(85, 162);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(242, 25);
            textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(85, 243);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(242, 25);
            textBoxPassword.TabIndex = 3;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(432, 37);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowTemplate.Height = 25;
            dataGridViewBooks.Size = new Size(545, 296);
            dataGridViewBooks.TabIndex = 5;
            dataGridViewBooks.CellContentClick += dataGridViewBooks_CellContentClick;
            // 
            // buttonManageBooks
            // 
            buttonManageBooks.Cursor = Cursors.Hand;
            buttonManageBooks.FlatStyle = FlatStyle.System;
            buttonManageBooks.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonManageBooks.Location = new Point(554, 383);
            buttonManageBooks.Name = "buttonManageBooks";
            buttonManageBooks.Size = new Size(109, 23);
            buttonManageBooks.TabIndex = 6;
            buttonManageBooks.Text = "Manage Books";
            buttonManageBooks.UseVisualStyleBackColor = true;
            buttonManageBooks.Click += buttonManageBooks_Click;
            // 
            // buttonTransactions
            // 
            buttonTransactions.Cursor = Cursors.Hand;
            buttonTransactions.FlatStyle = FlatStyle.System;
            buttonTransactions.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonTransactions.Location = new Point(749, 383);
            buttonTransactions.Name = "buttonTransactions";
            buttonTransactions.Size = new Size(109, 23);
            buttonTransactions.TabIndex = 7;
            buttonTransactions.Text = "Transactions";
            buttonTransactions.UseVisualStyleBackColor = true;
            buttonTransactions.Click += buttonTransactions_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(129, 297);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(146, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(153, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(83, 73);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 452);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(buttonTransactions);
            Controls.Add(buttonManageBooks);
            Controls.Add(dataGridViewBooks);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Main";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxUserName;
        private TextBox textBoxPassword;
        private DataGridView dataGridViewBooks;
        private Button buttonManageBooks;
        private Button buttonTransactions;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}