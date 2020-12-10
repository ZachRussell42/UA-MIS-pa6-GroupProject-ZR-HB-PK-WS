using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI_Practice
{
    public partial class frmMain : Form
    {
        string cwid;
        List<Books> myBooks;
        
        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Delete Method - Deletes the selected book after asking user to verify if they want to proceed
        private void button1_Click(object sender, EventArgs e)
        {
            Books myBook = (Books)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }
        }

        // Exits the process
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // Load Method - loads the books from the database
        private void LoadList()
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        // Index changed method - updates data of selected book
        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Books myBook = (Books)lstBooks.SelectedItem;

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();
            txtIsbnData.Text = myBook.isbn;

            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }

        }

        // Rent method - subtracts one of the copies of the selected book
        private void btnRent_Click(object sender, EventArgs e)
        {
            Books myBook = (Books)lstBooks.SelectedItem;
            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        // Return Method - adds one to the copies of the selected book
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Books myBook = (Books)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        // Edit Method - allows user to click 'edit' button and sends user to frmEdit, given the "edit" parameter
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Books myBook = (Books)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        // New Method - allows user to click 'new' button and sends user to frmEdit, given the "new" parameter
        private void btnNew_Click(object sender, EventArgs e)
        {
            Books myBook = new Books();
            frmEdit myForm = new frmEdit(myBook, "new", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}
