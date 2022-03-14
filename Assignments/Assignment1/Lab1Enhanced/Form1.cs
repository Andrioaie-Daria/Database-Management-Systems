using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Enhanced
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ERFTJDA; Initial Catalog = RailwayCompany; Integrated Security = True;");
        DataSet dataSet = new DataSet();

        SqlDataAdapter dataAdapterRoutes = new SqlDataAdapter();
        SqlDataAdapter dataAdapterStations = new SqlDataAdapter();

        BindingSource bindingSourceRoutes = new BindingSource();
        BindingSource bindingSourceStations = new BindingSource();

      
        DataRelation routeStationRelation;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // populate tables
            dataAdapterRoutes.SelectCommand = new SqlCommand("SELECT * FROM Route", connection);
            dataAdapterRoutes.Fill(dataSet, "Routes");


            dataAdapterStations.SelectCommand = new SqlCommand("SELECT * FROM RailwayStation", connection);
            dataAdapterStations.Fill(dataSet, "Stations");

            // establish relation between tables
            bindingSourceStations.DataSource = dataSet;
            bindingSourceStations.DataMember = "Stations";
            dgvStations.DataSource = bindingSourceStations;

            DataColumn stationsColumn = dataSet.Tables["Stations"].Columns["Location"];
            DataColumn routesColumn = dataSet.Tables["Routes"].Columns["Source"];
            routeStationRelation = new DataRelation("FK_Stations_Routes", stationsColumn, routesColumn);
            dataSet.Relations.Add(routeStationRelation);

            bindingSourceRoutes.DataSource = bindingSourceStations;
            bindingSourceRoutes.DataMember = "FK_Stations_Routes";
            dgvRoutes.DataSource = bindingSourceRoutes;

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapterRoutes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapterRoutes.Update(dataSet, "Routes");
                MessageBox.Show("Update was successful!");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
