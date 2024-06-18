namespace WinFormsApp1
{
    partial class Form4
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
            buttonRemoveBook = new Button();
            dataGridViewBooks = new DataGridView();
            labelISBN = new Label();
            textBoxBookID = new TextBox();
            pictureBoxBackButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackButton).BeginInit();
            SuspendLayout();
            // 
            // buttonRemoveBook
            // 
            buttonRemoveBook.Cursor = Cursors.Hand;
            buttonRemoveBook.FlatStyle = FlatStyle.System;
            buttonRemoveBook.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRemoveBook.Location = new Point(386, 341);
            buttonRemoveBook.Name = "buttonRemoveBook";
            buttonRemoveBook.Size = new Size(91, 23);
            buttonRemoveBook.TabIndex = 12;
            buttonRemoveBook.Text = "Remove Book";
            buttonRemoveBook.UseVisualStyleBackColor = true;
            buttonRemoveBook.Click += buttonRemoveBook_Click;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(60, 12);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowTemplate.Height = 25;
            dataGridViewBooks.Size = new Size(545, 296);
            dataGridViewBooks.TabIndex = 13;
            dataGridViewBooks.CellContentClick += dataGridViewBooks_CellContentClick;
            // 
            // labelISBN
            // 
            labelISBN.AutoSize = true;
            labelISBN.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelISBN.Location = new Point(119, 328);
            labelISBN.Name = "labelISBN";
            labelISBN.Size = new Size(59, 22);
            labelISBN.TabIndex = 15;
            labelISBN.Text = "Book ID :";
            labelISBN.Click += labelISBN_Click;
            // 
            // textBoxBookID
            // 
            textBoxBookID.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxBookID.Location = new Point(119, 353);
            textBoxBookID.Name = "textBoxBookID";
            textBoxBookID.Size = new Size(208, 25);
            textBoxBookID.TabIndex = 14;
            textBoxBookID.TextChanged += textBoxBookID_TextChanged;
            // 
            // pictureBoxBackButton
            // 
            pictureBoxBackButton.Cursor = Cursors.Hand;
            pictureBoxBackButton.Image = Properties.Resources.backbutton;
            pictureBoxBackButton.Location = new Point(12, 12);
            pictureBoxBackButton.Name = "pictureBoxBackButton";
            pictureBoxBackButton.Size = new Size(33, 36);
            pictureBoxBackButton.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBackButton.TabIndex = 16;
            pictureBoxBackButton.TabStop = false;
            pictureBoxBackButton.Click += pictureBoxBackButton_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 402);
            Controls.Add(pictureBoxBackButton);
            Controls.Add(labelISBN);
            Controls.Add(textBoxBookID);
            Controls.Add(dataGridViewBooks);
            Controls.Add(buttonRemoveBook);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form4";
            Text = "Remove Books";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonRemoveBook;
        private DataGridView dataGridViewBooks;
        private Label labelISBN;
        private TextBox textBoxBookID;
        private PictureBox pictureBoxBackButton;
    }
}