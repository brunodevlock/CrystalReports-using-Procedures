using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace CrystalReportsTutorial
{

    public partial class Form1 : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dAdapter;
        DataTable dtable;

        string conn_string = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //    ReportDocument rdc = new ReportDocument(); //criar o objeto Report
            //    rdc.Load(@"Reports\CrystalReport1.rpt"); //carregar o report
            //    crystalReportViewer1.ReportSource = rdc; //Executa o source para abrir o Report



        }

        private void Show_btn(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(conn_string))
            {

                dAdapter = new SqlDataAdapter("GETALLDATA", connection); // faz conexão com a Procedure indicada pelo nome
                dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure; //habilita o uso de procedures
                dtable = new DataTable();
                dAdapter.Fill(dtable);
                ReportDocument rdc = new ReportDocument(); //instancia o objeto
                rdc.Load(@"Reports\CrystalReport1.rpt"); // carrega o Report
                rdc.SetDataSource(dtable);

                crystalReportViewer1.ReportSource = rdc;
            }
        }
    }

}
