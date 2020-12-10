using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI_Practice
{
    public partial class frmEdit : Form
    {
        // Properties
        private Books myBook;
        private string cwid;
        private string mode;
        // Constructor
        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Books)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Edit Method - reads in book data and loads it
        private void frmEdit_Load(object sender, EventArgs e)
        {
            if (mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtLengthData.Text = myBook.length.ToString();
                txtCoverData.Text = myBook.cover;

                pbCover.Load(myBook.cover);
            }
        }

        // Exits the Edit screen
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Save Method - Saves the data and updates the book given the string input in the txt boxes
        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.cover = txtCoverData.Text;
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            MessageBox.Show("Content was successfully saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
