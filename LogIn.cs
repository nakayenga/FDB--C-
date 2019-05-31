/*
========================================================================================================================================================
AUTHOR
Created By: Cathy Nakayenga
Created On: 4/9/2019
--------------------------------------------------------------------------------------------------------------------------------------------------------
HISTORY:
Date: Issue Resolved
---------------------------------------------------------------------------------------------------------------------------------------------------------
DESCRIPTION:
Show Quarterly Reports 
==========================================================================================================================================================
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using System.Data.SqlClient;

namespace BHHC_ACCOUNTING
{
    public partial class LogIn : Form
    {
        //Make sure that the password protection is * to hide the characters 
        //Also make sure that the lenth of the password cannot exceed 20 characters
        public LogIn()
        {
           
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 20;
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {
           
        }

        //Redirect us to the ExcelFilePreview when login button is clicked
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            PreviewExcelFile excelFile = new PreviewExcelFile();
            excelFile.ShowDialog();

            //remember to add:
            //1. Server Explorer > Data Connection > User Database
            //2. Add a connection string to the database in App.config
            //3. Ask IT to create for me a view with the login details of finance/accounting that i can query

            //SqlConnection con = new SqlConnection("put the connection string in here");
            //SqlDataAdapter sda = new SqlDataAdapter("Select Role from Login where Username ='" + textBoxUsername.Text + "' and Password='" + textBox2Password.Text + "'", con);
            //DataTable dt = new System.Data.DataTable();
            //sda.Fill(dt);


            
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        //close this page when the cancel button is clicked
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEnterCredentials_Click(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
