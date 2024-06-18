namespace WinFormsApp1
{
    partial class Form3
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
            dataGridViewBooks = new DataGridView();
            textBoxAuthorName = new TextBox();
            textBoxBook = new TextBox();
            textBoxISBN = new TextBox();
            buttonAddBook = new Button();
            buttonRemoveBook = new Button();
            labelAuthorName = new Label();
            labelISBN = new Label();
            labelBookTitle = new Label();
            pictureBoxBackButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackButton).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(126, 12);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowTemplate.Height = 25;
            dataGridViewBooks.Size = new Size(545, 296);
            dataGridViewBooks.TabIndex = 6;
            dataGridViewBooks.CellContentClick += dataGridViewBooks_CellContentClick;
            // 
            // textBoxAuthorName
            // 
            textBoxAuthorName.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxAuthorName.Location = new Point(153, 350);
            textBoxAuthorName.Name = "textBoxAuthorName";
            textBoxAuthorName.Size = new Size(248, 25);
            textBoxAuthorName.TabIndex = 7;
            textBoxAuthorName.TextChanged += textBoxAuthorName_TextChanged;
            // 
            // textBoxBook
            // 
            textBoxBook.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxBook.Location = new Point(153, 411);
            textBoxBook.Name = "textBoxBook";
            textBoxBook.Size = new Size(484, 25);
            textBoxBook.TabIndex = 8;
            textBoxBook.TextChanged += textBoxBook_TextChanged;
            // 
            // textBoxISBN
            // 
            textBoxISBN.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxISBN.Location = new Point(429, 350);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.Size = new Size(208, 25);
            textBoxISBN.TabIndex = 9;
            textBoxISBN.TextChanged += textBoxISBN_TextChanged;
            // 
            // buttonAddBook
            // 
            buttonAddBook.Cursor = Cursors.Hand;
            buttonAddBook.FlatStyle = FlatStyle.System;
            buttonAddBook.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddBook.Location = new Point(256, 468);
            buttonAddBook.Name = "buttonAddBook";
            buttonAddBook.Size = new Size(91, 23);
            buttonAddBook.TabIndex = 10;
            buttonAddBook.Text = "Add Book";
            buttonAddBook.UseVisualStyleBackColor = true;
            buttonAddBook.Click += buttonAddBook_Click;
            // 
            // buttonRemoveBook
            // 
            buttonRemoveBook.Cursor = Cursors.Hand;
            buttonRemoveBook.FlatStyle = FlatStyle.System;
            buttonRemoveBook.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRemoveBook.Location = new Point(429, 468);
            buttonRemoveBook.Name = "buttonRemoveBook";
            buttonRemoveBook.Size = new Size(91, 23);
            buttonRemoveBook.TabIndex = 11;
            buttonRemoveBook.Text = "Remove Book";
            buttonRemoveBook.UseVisualStyleBackColor = true;
            buttonRemoveBook.Click += buttonRemoveBook_Click;
            // 
            // labelAuthorName
            // 
            labelAuthorName.AutoSize = true;
            labelAuthorName.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelAuthorName.Location = new Point(153, 325);
            labelAuthorName.Name = "labelAuthorName";
            labelAuthorName.Size = new Size(94, 22);
            labelAuthorName.TabIndex = 12;
            labelAuthorName.Text = "Author Name :";
            // 
            // labelISBN
            // 
            labelISBN.AutoSize = true;
            labelISBN.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelISBN.Location = new Point(429, 325);
            labelISBN.Name = "labelISBN";
            labelISBN.Size = new Size(41, 22);
            labelISBN.TabIndex = 13;
            labelISBN.Text = "ISBN :";
            // 
            // labelBookTitle
            // 
            labelBookTitle.AutoSize = true;
            labelBookTitle.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelBookTitle.Location = new Point(153, 386);
            labelBookTitle.Name = "labelBookTitle";
            labelBookTitle.Size = new Size(71, 22);
            labelBookTitle.TabIndex = 14;
            labelBookTitle.Text = "Book Title :";
            // 
            // pictureBoxBackButton
            // 
            pictureBoxBackButton.Cursor = Cursors.Hand;
            pictureBoxBackButton.Image = Properties.Resources.backbutton;
            pictureBoxBackButton.Location = new Point(12, 12);
            pictureBoxBackButton.Name = "pictureBoxBackButton";
            pictureBoxBackButton.Size = new Size(33, 36);
            pictureBoxBackButton.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBackButton.TabIndex = 17;
            pictureBoxBackButton.TabStop = false;
            pictureBoxBackButton.Click += pictureBoxBackButton_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 564);
            Controls.Add(pictureBoxBackButton);
            Controls.Add(labelBookTitle);
            Controls.Add(labelISBN);
            Controls.Add(labelAuthorName);
            Controls.Add(buttonRemoveBook);
            Controls.Add(buttonAddBook);
            Controls.Add(textBoxISBN);
            Controls.Add(textBoxBook);
            Controls.Add(textBoxAuthorName);
            Controls.Add(dataGridViewBooks);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            Text = "Manage Books";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBooks;
        private TextBox textBoxAuthorName;
        private TextBox textBoxBook;
        private TextBox textBoxISBN;
        private Button buttonAddBook;
        private Button buttonRemoveBook;
        private Label labelAuthorName;
        private Label labelISBN;
        private Label labelBookTitle;
        private PictureBox pictureBoxBackButton;
    }
}