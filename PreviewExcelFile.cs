/*
========================================================================================================================================================
AUTHOR
Created By: Cathy Nakayenga
Created On: 4/9/2019
--------------------------------------------------------------------------------------------------------------------------------------------------------
HISTORY:
4/16/2019 - Changes Recommended
1. Remove the ability of users having to chose where the file is located. Make a default location and a default name (update: the location is still on my desktop
but i need to figure out how to save the file on the directories of the app users and i know tha this may involve some networks logic)
2. Add a dropdown for selecting the company
3. Add a dropdown for selecting the year
4. Add a dropdown for selecting the quarter
5. Change name of application to "FDB Application"
6. Checklisted box to make sure that someone can select more than one company to view report on (i do not think this feature is needed) - like a multi select drop down - double 
functionality since we are already letting them export the excel file inorder to do this in excel. Will be reinventing the wheel. Otherwise if they are able to multi select
then what will be the purpose of having them download the excel file where there can be able to do this.
7. Format Excel File to align left, bottom align, remove wrap text feature, auto fit column width and auto fit row height

4/22/2019 - Changes made
1. Removed the login page in favour of using Active Directories
2. Added Clear button that enables users to clear filters
3. Label that counts the number of rows in the datagridview

4/24/2019 - Changes made
1. Default filename with date appended to prevent overwriting of excel files downloaded

Questions for Mark
1. Does he want to be able to display both the tables to the user? Or does he combine them into one table
2. Can i have a look at the table that he puts up for the accountants so that i can have an idea of what they have been working with and whether there are some improvements i can recommend or not.

5/3/2019 - Changes made
1. I displayed the states and the non states in two different datagridviews
2. Each datagridview exports to two different tabs
3. Each excel sheet is named "States" or "Non-States"

Improvements:
Make the first sheet the active one when the excel sheet first downloads


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
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Data.EntityClient;
using System.Reflection;
using System.Runtime.InteropServices;


namespace BHHC_ACCOUNTING
{
    public partial class PreviewExcelFile : Form
    {
        public PreviewExcelFile()
        {
            InitializeComponent();
        }

        //this method will connect to the database and run query
        public System.Data.DataTable GetQueryDataStates()
        {
            //datatable object that will hold our query results
            System.Data.DataTable dt = new System.Data.DataTable();

            //connection string to the database
            string connstring = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            //sql connection object to enable us run sql queries against the database
            using (SqlConnection con = new SqlConnection(connstring))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                StreamReader strmReader = new StreamReader(asm.GetManifestResourceStream("BHHC_ACCOUNTING.FDBFinalQueryStates.sql")); //need to separate the queries. Make this query for only states
                string fdbQuery = strmReader.ReadToEnd();
                //sql command object that will hold the sql query
                using (SqlCommand cmd = new SqlCommand(fdbQuery, con))
                {
                    //open the sql connection
                    con.Open();

                    //read the results of the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    //load the read results into the data table we created. 
                    //Its this data table that we will display in the DataGridView
                    dt.Load(reader);

                    //close the reader
                    reader.Close();
                }

                con.Close();
            }

            int countRows = dt.Rows.Count;
            labelRowCountStates.Text = string.Format("{0} Rows", countRows);

            return dt;
        }

        public System.Data.DataTable GetQueryDataNonStates()
        {
            //datatable object that will hold our query results
            System.Data.DataTable dtt = new System.Data.DataTable();

            //connection string to the database
            string connstringg = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            //sql connection object to enable us run sql queries against the database
            using (SqlConnection conn = new SqlConnection(connstringg))
            {
                Assembly asmm = Assembly.GetExecutingAssembly();
                StreamReader strmReaderr = new StreamReader(asmm.GetManifestResourceStream("BHHC_ACCOUNTING.FDBFinalQueryNonStates.sql"));
                string fdbQueryy = strmReaderr.ReadToEnd();
                //sql command object that will hold the sql query
                using (SqlCommand cmdd = new SqlCommand(fdbQueryy, conn))
                {
                    //open the sql connection
                    conn.Open();

                    //read the results of the command
                    SqlDataReader readerr = cmdd.ExecuteReader();

                    //load the read results into the data table we created. 
                    //Its this data table that we will display in the DataGridView
                    dtt.Load(readerr);

                    //offload and close the reader
                    readerr.Close();
                }

                //close database connection
                conn.Close();
            }
            int countRowss = dtt.Rows.Count;
            labelRowCountNonStates.Text = string.Format("{0} Rows", countRowss);

            return dtt;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        //this method will load and display the query data into the datagridviews and combo-boxes
        private void PreviewExcelFile_Load(object sender, EventArgs e)
        {
            //load all data into the datagridview

            //disable datagridview updates before adding rows or other operations using this call
            SendMessage(dataGridViewStates.Handle, WM_SETREDRAW, false, 0);
            dataGridViewStates.DataSource = GetQueryDataStates();
            //enable redrawing and redraw the contents of the control
            SendMessage(dataGridViewStates.Handle, WM_SETREDRAW, true, 0);
            dataGridViewStates.Refresh();

            //disable datagridview updates before adding rows or other operations using this call
            SendMessage(dataGridViewNonStates.Handle, WM_SETREDRAW, false, 0);
            dataGridViewNonStates.DataSource = GetQueryDataNonStates();
            //enable redrawing and redraw the contents of the control
            SendMessage(dataGridViewNonStates.Handle, WM_SETREDRAW, true, 0);
            dataGridViewNonStates.Refresh();

            //solution to slow datagridview scrolling and rendering
            //Set Double buffering on the grids using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewStates, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewNonStates, new object[] { true });

            //loads the company checkboxlist
            System.Data.DataTable cmpy = new System.Data.DataTable();

            string connstring_1 = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            using (SqlConnection con_1 = new SqlConnection(connstring_1))
            {
                using (SqlCommand cmd_1 = new SqlCommand("SELECT DISTINCT CASE WHEN COMPANY_CODE = 'CCC ' THEN 'BHHIC' ELSE COMPANY_CODE END AS COMPANY_CODE FROM [BHHCFinance].[fdb].[SunGard]", con_1))
                {
                    con_1.Open();

                    SqlDataAdapter da_1 = new SqlDataAdapter(cmd_1);
                    da_1.Fill(cmpy);

                    foreach (DataRow dr_1 in cmpy.Rows)
                    {
                        checkedListBoxSelectCompany.Items.Add(dr_1["COMPANY_CODE"]);
                    }

                }

                con_1.Close();
            }

            //loads the year checkboxlist
            System.Data.DataTable year = new System.Data.DataTable();

            string connstring_2 = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            using (SqlConnection con_2 = new SqlConnection(connstring_2))
            {
                using (SqlCommand cmd_2 = new SqlCommand("SELECT DISTINCT DATEPART(YEAR, RUN_DATE) AS YR FROM [BHHCFinance].[fdb].[SunGard] ORDER BY YR DESC", con_2))
                {
                    con_2.Open();

                    SqlDataAdapter da_2 = new SqlDataAdapter(cmd_2);
                    da_2.Fill(year);

                    foreach (DataRow dr_2 in year.Rows)
                    {
                        checkedListBoxSelectYear.Items.Add(dr_2["YR"]);
                    }

                    con_2.Close();
                }
            }

            //loads the quarter checkboxlist
            System.Data.DataTable qtr = new System.Data.DataTable();

            string connstring_3 = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            using (SqlConnection con_3 = new SqlConnection(connstring_3))
            {
                using (SqlCommand cmd_3 = new SqlCommand("SELECT DISTINCT DATEPART(QUARTER, RUN_DATE) AS QTR FROM [BHHCFinance].[fdb].[SunGard] ORDER BY QTR ASC", con_3))
                {
                    con_3.Open();

                    SqlDataAdapter da_3 = new SqlDataAdapter(cmd_3);
                    da_3.Fill(qtr);

                    foreach (DataRow dr_3 in qtr.Rows)
                    {
                        checkedListBoxSelectQuarter.Items.Add(dr_3["QTR"]);
                    }

                    con_3.Close();
                }
            }
        }


        private void dataGridViewExcelPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void copyAllStatestoClipboard()
        {
            dataGridViewStates.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            dataGridViewStates.SelectAll();

            DataObject dataObj1 = dataGridViewStates.GetClipboardContent();
            if (dataObj1 != null)
                Clipboard.SetDataObject(dataObj1);
        }

        private void copyAllNonStatestoClipboard()
        {
            dataGridViewNonStates.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            dataGridViewNonStates.SelectAll();

            DataObject dataObj2 = dataGridViewNonStates.GetClipboardContent();
            if (dataObj2 != null)
                Clipboard.SetDataObject(dataObj2);
        }

        //click button to name file and export the data
        public void buttonExportExcelFile_Click_1(object sender, EventArgs e)
        {
            //set cursor as hourglas
            Cursor.Current = Cursors.WaitCursor;
            System.Windows.Forms.Application.DoEvents();

            //disable the button for the duration of the download
            this.buttonExportExcelFile.Enabled = false;

            copyAllStatestoClipboard();


            string filename = "qtrreport";

            //creating excel application (workbook and worksheets)
            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Add(misValue);
            Microsoft.Office.Interop.Excel.Worksheet ws_1 = null;
            Microsoft.Office.Interop.Excel.Worksheet ws_2 = null;
            ws_1 = wb.Sheets[1];
            ws_1.Name = "States";


            //format the columns
            for (int i = 1; i < dataGridViewStates.Columns.Count + 1; i++)
            {
                Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, i];
                xlRange.Font.Bold = -1;
                xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                xlRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            }

            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)ws_1.Cells[1, 1];
            CR.Select();
            ws_1.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            ws_1.get_Range("A1").Select();

            // autofit the columns
            ws_1.Columns.AutoFit();

            //turn off excel wrap feature
            ws_1.Rows.WrapText = false;

            Clipboard.Clear();

            copyAllNonStatestoClipboard();

            //creating a second sheet in the workbook
            int count = wb.Worksheets.Count;

            //loading sheet 2
            ws_2 = wb.Worksheets.Add(Type.Missing, wb.Worksheets[count], Type.Missing, Type.Missing);
            ws_2.Name = "Non States";

            //format the columns fro worksheet 2 - Non States
            for (int i = 1; i < dataGridViewNonStates.Columns.Count + 1; i++)
            {
                Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)excel.Cells[1, i];
                xlRange.Font.Bold = -1;
                xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                xlRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            }

            Microsoft.Office.Interop.Excel.Range CR2 = (Microsoft.Office.Interop.Excel.Range)ws_2.Cells[1, 1];
            CR2.Select();
            ws_2.PasteSpecial(CR2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            ws_2.get_Range("A1").Select();

            // autofit the columns
            ws_2.Columns.AutoFit();

            //turn off excel wrap feature
            ws_2.Rows.WrapText = false;

            //Activate Sheet 1 (With States) in the Workbook
            ws_1.Activate();

            //Save File
            if (Directory.Exists("X:\\Public\\Accounting\\04 - FUNCTIONAL AREAS\\FDB\\CathyFDBReport\\"))
            {
                //get date string and append it to filename to prevent overwriting file
                DateTime localDate = DateTime.Now;
                string localDateString = localDate.ToString("yyyyMMddHHmmss");
                excel.ActiveWorkbook.SaveCopyAs("X:\\Public\\Accounting\\04 - FUNCTIONAL AREAS\\FDB\\CathyFDBReport\\" + filename + "_" + localDateString + ".xlsx");
            }
            else
            {
                Directory.CreateDirectory("X:\\Public\\Accounting\\04 - FUNCTIONAL AREAS\\FDB\\CathyFDBReport\\");
                //get date string and append it to filename to prevent overwriting file
                DateTime localDate_2 = DateTime.Now;
                string localDateString_2 = localDate_2.ToString("yyyyMMddHHmmss");
                excel.ActiveWorkbook.SaveCopyAs("X:\\Public\\Accounting\\04 - FUNCTIONAL AREAS\\FDB\\CathyFDBReport\\" + filename + "_" + localDateString_2 + ".xlsx");
            }

            excel.ActiveWorkbook.Saved = true;
            System.Windows.Forms.Application.DoEvents();
            //foreach (Process proc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            //{
            //    proc.Kill();
            //}

            //open the directory of the downloaded file
            string path = @"X:\Public\Accounting\04 - FUNCTIONAL AREAS\FDB\CathyFDBReport\";
            System.Diagnostics.Process.Start(path);

            this.buttonExportExcelFile.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        private void labelReportName_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            //set cursor as hourglas
            Cursor.Current = Cursors.WaitCursor;
            System.Windows.Forms.Application.DoEvents();

            this.buttonFilter.Enabled = false;

            // disable datagridview updates before adding rows or other operations using this call
            SendMessage(dataGridViewStates.Handle, WM_SETREDRAW, false, 0);
            dataGridViewStates.DataSource = GetFilterDataStates();
            //enable redrawing and redraw the contents of the control
            SendMessage(dataGridViewStates.Handle, WM_SETREDRAW, true, 0);
            dataGridViewStates.Refresh();

            //disable datagridview updates before adding rows or other operations using this call
            SendMessage(dataGridViewNonStates.Handle, WM_SETREDRAW, false, 0);
            dataGridViewNonStates.DataSource = GetFilterDataNonStates();
            //enable redrawing and redraw the contents of the control
            SendMessage(dataGridViewNonStates.Handle, WM_SETREDRAW, true, 0);
            dataGridViewNonStates.Refresh();

            //Set Double buffering on the first Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewStates, new object[] { true });

            //Set Double buffering on the second Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewNonStates, new object[] { true });

            this.buttonFilter.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        public System.Data.DataTable GetFilterDataStates()
        {

            //datatable object that will hold our filter results
            System.Data.DataTable dt_filter = new System.Data.DataTable();

            //datatable objects that will hold the table valued parameters
            System.Data.DataTable cmpy_list = new System.Data.DataTable();
            System.Data.DataTable yr_list = new System.Data.DataTable();
            System.Data.DataTable qtr_list = new System.Data.DataTable();

            //lists to store the checked items
            List<string> companyList = new List<string>();
            List<int> yearList = new List<int>();
            List<int> quarterList = new List<int>();

            foreach (object item in checkedListBoxSelectCompany.CheckedItems)
            {
                companyList.Add(item.ToString());
            }

            foreach (object item in checkedListBoxSelectYear.CheckedItems)
            {
                yearList.Add(Convert.ToInt32(item));
            }

            foreach (object item in checkedListBoxSelectQuarter.CheckedItems)
            {
                quarterList.Add(Convert.ToInt32(item));
            }

            //arrays to hold the checked items
            string[] cmpycodes = companyList.ToArray();
            int[] yrcodes = yearList.ToArray();
            int[] qtrcodes = quarterList.ToArray();

            //create one column in each data table
            cmpy_list.Columns.Add("cmpycode", typeof(String));
            yr_list.Columns.Add("yrcode", typeof(Int32));
            qtr_list.Columns.Add("qtrcode", typeof(Int32));

            //put the array items in the datatable
            foreach (string cmpycode in cmpycodes)
            {
                DataRow dr = cmpy_list.NewRow();
                dr["cmpycode"] = cmpycode;
                cmpy_list.Rows.Add(dr);
            }

            foreach (int yrcode in yrcodes)
            {
                DataRow dr = yr_list.NewRow();
                dr["yrcode"] = yrcode;
                yr_list.Rows.Add(dr);
            }

            foreach (int qtrcode in qtrcodes)
            {
                DataRow dr = qtr_list.NewRow();
                dr["qtrcode"] = qtrcode;
                qtr_list.Rows.Add(dr);
            }

            //connection string to the database
            string connstring_4 = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            //sql connection object to enable us run sql queries against the database
            using (SqlConnection con_4 = new SqlConnection(connstring_4))
            {
                //reading the states data
                Assembly aasm = Assembly.GetExecutingAssembly();
                StreamReader sstrmReader = new StreamReader(aasm.GetManifestResourceStream("BHHC_ACCOUNTING.FDBFilterQueryStates.sql"));
                string ffdbQuery = sstrmReader.ReadToEnd();

                //sql command object that will hold the sql query
                using (SqlCommand cmd_4 = new SqlCommand(ffdbQuery, con_4))
                {
                    cmd_4.Parameters.Add("@cmpycodes", SqlDbType.Structured);
                    cmd_4.Parameters["@cmpycodes"].Direction = ParameterDirection.Input;
                    cmd_4.Parameters["@cmpycodes"].TypeName = "cmpycode_list_tbltype";
                    cmd_4.Parameters["@cmpycodes"].Value = cmpy_list;

                    cmd_4.Parameters.Add("@yrcodes", SqlDbType.Structured);
                    cmd_4.Parameters["@yrcodes"].Direction = ParameterDirection.Input;
                    cmd_4.Parameters["@yrcodes"].TypeName = "yrcode_list_tbltype";
                    cmd_4.Parameters["@yrcodes"].Value = yr_list;

                    cmd_4.Parameters.Add("@qtrcodes", SqlDbType.Structured);
                    cmd_4.Parameters["@qtrcodes"].Direction = ParameterDirection.Input;
                    cmd_4.Parameters["@qtrcodes"].TypeName = "qtrcode_list_tbltype";
                    cmd_4.Parameters["@qtrcodes"].Value = qtr_list;

                    //open the sql connection
                    con_4.Open();

                    SqlDataReader da = cmd_4.ExecuteReader();

                    dt_filter.Load(da);

                    da.Close();

                }

                con_4.Close();
            }

            int countRows_4 = dt_filter.Rows.Count;
            labelRowCountStates.Text = string.Format("{0} Rows", countRows_4);

            return dt_filter;
        }

        public System.Data.DataTable GetFilterDataNonStates()
        {

            //datatable object that will hold our filter results
            System.Data.DataTable dt_filter2 = new System.Data.DataTable();

            //datatable objects that will hold the table valued parameters
            System.Data.DataTable cmpy_list2 = new System.Data.DataTable();
            System.Data.DataTable yr_list2 = new System.Data.DataTable();
            System.Data.DataTable qtr_list2 = new System.Data.DataTable();

            //lists to store the checked items
            List<string> companyList2 = new List<string>();
            List<int> yearList2 = new List<int>();
            List<int> quarterList2 = new List<int>();


            foreach (object item in checkedListBoxSelectCompany.CheckedItems)
            {
                companyList2.Add(item.ToString());
            }

            foreach (object item in checkedListBoxSelectYear.CheckedItems)
            {
                yearList2.Add(Convert.ToInt32(item));
            }

            foreach (object item in checkedListBoxSelectQuarter.CheckedItems)
            {
                quarterList2.Add(Convert.ToInt32(item));
            }

            //arrays to hold the checked items
            string[] cmpycodes2 = companyList2.ToArray();
            int[] yrcodes2 = yearList2.ToArray();
            int[] qtrcodes2 = quarterList2.ToArray();

            //create one column in each data table
            cmpy_list2.Columns.Add("cmpycode2", typeof(String));
            yr_list2.Columns.Add("yrcode2", typeof(Int32));
            qtr_list2.Columns.Add("qtrcode2", typeof(Int32));

            //put the array items in the datatable
            foreach (string cmpycode2 in cmpycodes2)
            {
                DataRow dr = cmpy_list2.NewRow();
                dr["cmpycode2"] = cmpycode2;
                cmpy_list2.Rows.Add(dr);
            }

            foreach (int yrcode2 in yrcodes2)
            {
                DataRow dr = yr_list2.NewRow();
                dr["yrcode2"] = yrcode2;
                yr_list2.Rows.Add(dr);
            }

            foreach (int qtrcode2 in qtrcodes2)
            {
                DataRow dr = qtr_list2.NewRow();
                dr["qtrcode2"] = qtrcode2;
                qtr_list2.Rows.Add(dr);
            }

            //connection string to the database
            string connstring_4 = ConfigurationManager.ConnectionStrings["qrydata2"].ConnectionString;

            //sql connection object to enable us run sql queries against the database
            using (SqlConnection con_4 = new SqlConnection(connstring_4))
            {
                //reading the states data
                Assembly aasm = Assembly.GetExecutingAssembly();
                StreamReader sstrmReader = new StreamReader(aasm.GetManifestResourceStream("BHHC_ACCOUNTING.FDBFilterQueryNonStates.sql"));
                string ffdbQuery = sstrmReader.ReadToEnd();

                //sql command object that will hold the sql query
                using (SqlCommand cmd_4 = new SqlCommand(ffdbQuery, con_4))
                {
                    cmd_4.Parameters.Add("@cmpycodes2", SqlDbType.Structured);
                    cmd_4.Parameters["@cmpycodes2"].Direction = ParameterDirection.Input;
                    cmd_4.Parameters["@cmpycodes2"].TypeName = "cmpycode_list_tbltype2";
                    cmd_4.Parameters["@cmpycodes2"].Value = cmpy_list2;

                    cmd_4.Parameters.Add("@yrcodes2", SqlDbType.Structured);
                    cmd_4.Parameters["@yrcodes2"].Direction = ParameterDirection.Input;
                    cmd_4.Parameters["@yrcodes2"].TypeName = "yrcode_list_tbltype2";
                    cmd_4.Parameters["@yrcodes2"].Value = yr_list2;

                    cmd_4.Parameters.Add("@qtrcodes2", SqlDbType.Structured);
                    cmd_4.Parameters["@qtrcodes2"].Direction = ParameterDirection.Input;
                    cmd_4.Parameters["@qtrcodes2"].TypeName = "qtrcode_list_tbltype2";
                    cmd_4.Parameters["@qtrcodes2"].Value = qtr_list2;

                    //open the sql connection
                    con_4.Open();

                    SqlDataReader da = cmd_4.ExecuteReader();

                    dt_filter2.Load(da);

                    da.Close();

                }

                con_4.Close();
            }

            int countRows_4 = dt_filter2.Rows.Count;
            labelRowCountNonStates.Text = string.Format("{0} Rows", countRows_4);

            return dt_filter2;
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            System.Windows.Forms.Application.DoEvents();

            this.buttonClearFilter.Enabled = false;

            //reloads all data into the datagridviews

            //disable datagridview updates before adding rows or other operations using this call
            SendMessage(dataGridViewStates.Handle, WM_SETREDRAW, false, 0);
            dataGridViewStates.DataSource = GetQueryDataStates();
            //enable redrawing and redraw the contents of the control
            SendMessage(dataGridViewStates.Handle, WM_SETREDRAW, true, 0);
            dataGridViewStates.Refresh();

            //disable datagridview updates before adding rows or other operations using this call
            SendMessage(dataGridViewNonStates.Handle, WM_SETREDRAW, false, 0);
            dataGridViewNonStates.DataSource = GetQueryDataNonStates();
            //enable redrawing and redraw the contents of the control
            SendMessage(dataGridViewNonStates.Handle, WM_SETREDRAW, true, 0);
            dataGridViewNonStates.Refresh();

            //solution to slow datagridview scrolling and rendering
            //Set Double buffering on the grids using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewStates, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewNonStates, new object[] { true });

            checkBoxSelectAllCompany.Checked = false;
            checkBoxSelectAllYear.Checked = false;
            checkBoxSelectAllQuarter.Checked = false;

            foreach (int i in checkedListBoxSelectCompany.CheckedIndices)
            {
                checkedListBoxSelectCompany.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in checkedListBoxSelectYear.CheckedIndices)
            {
                checkedListBoxSelectYear.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in checkedListBoxSelectQuarter.CheckedIndices)
            {
                checkedListBoxSelectQuarter.SetItemCheckState(i, CheckState.Unchecked);
            }

            this.buttonClearFilter.Enabled = false;

            Cursor.Current = Cursors.Default;
        }

        private void labelRowCount_Click(object sender, EventArgs e)
        {

        }

        private void labelProcessing_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewNonStates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelNonStates_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void labelQuarter_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelSelectInstructions_Click(object sender, EventArgs e)
        {

        }

        private void labelStates_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAllQuarter.Checked)
                for (int i = 0; i < checkedListBoxSelectQuarter.Items.Count; i++)
                    checkedListBoxSelectQuarter.SetItemChecked(i, true);
            else
                for (int i = 0; i < checkedListBoxSelectQuarter.Items.Count; i++)
                    checkedListBoxSelectQuarter.SetItemChecked(i, false);
        }

        private void checkBoxSelectAllCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAllCompany.Checked)
                for (int i = 0; i < checkedListBoxSelectCompany.Items.Count; i++)
                    checkedListBoxSelectCompany.SetItemChecked(i, true);
            else
                for (int i = 0; i < checkedListBoxSelectCompany.Items.Count; i++)
                    checkedListBoxSelectCompany.SetItemChecked(i, false);
        }

        private void checkedListBoxSelectYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSelectAllYear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAllYear.Checked)
                for (int i = 0; i < checkedListBoxSelectYear.Items.Count; i++)
                    checkedListBoxSelectYear.SetItemChecked(i, true);
            else
                for (int i = 0; i < checkedListBoxSelectYear.Items.Count; i++)
                    checkedListBoxSelectYear.SetItemChecked(i, false);
        }

        private void checkedListBoxSelectQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //datatable object that will hold our query results
            System.Data.DataTable dtt = new System.Data.DataTable();

            //connection string to the database
            string connstringg = ConfigurationManager.ConnectionStrings["qrydata3"].ConnectionString;

            //sql connection object to enable us run sql queries against the database
            using (SqlConnection conn = new SqlConnection(connstringg))
            {
                //sql command object that will hold the sql query
                using (SqlCommand cmdd = new SqlCommand("SELECT * FROM dbo.work_bstrn_detail", conn))
                {
                    //open the sql connection
                    conn.Open();

                    //read the results of the command
                    SqlDataReader readerr = cmdd.ExecuteReader();

                    //load the read results into the data table we created. 
                    //Its this data table that we will display in the DataGridView
                    dtt.Load(readerr);

                    //offload and close the reader
                    readerr.Close();
                }

                //close database connection
                conn.Close();
            }
            int countRowss = dtt.Rows.Count;
            labelRowCountNonStates.Text = string.Format("{0} Rows", countRowss);

            return dtt;
        }
    }
}