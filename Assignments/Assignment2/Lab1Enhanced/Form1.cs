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
using System.Configuration;
using System.Collections.Specialized;

namespace Lab1Enhanced
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ERFTJDA; Initial Catalog = RailwayCompany; Integrated Security = True;");
        DataSet dataSet = new DataSet();

        SqlDataAdapter dataAdapterChild = new SqlDataAdapter();
        SqlDataAdapter dataAdapterParent = new SqlDataAdapter();

        BindingSource bindingSourceChild = new BindingSource();
        BindingSource bindingSourceParent = new BindingSource();

      
        DataRelation childParentRelation;

        public Form1()
        {
            InitializeComponent();
        }

        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString.ToString();
        }

        private string getParentQuery()
        {
            return ConfigurationManager.AppSettings["parent_query"];
        }

        private string getChildQuery()
        {
            return ConfigurationManager.AppSettings["child_query"];
        }

        private string getParentTable()
        {
            return ConfigurationManager.AppSettings["parent_table"];
        }

        private string getChildTable()
        {
            return ConfigurationManager.AppSettings["child_table"];
        }

        private string getParentPKName()
        {
            return ConfigurationManager.AppSettings["parent_pk_column"];
        }

        private string getChildFKName()
        {
            return ConfigurationManager.AppSettings["child_fk_column"];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // populate tables
            dataAdapterChild.SelectCommand = new SqlCommand(getChildQuery(), connection);
            dataAdapterChild.Fill(dataSet, getChildTable());


            dataAdapterParent.SelectCommand = new SqlCommand(getParentQuery(), connection);
            dataAdapterParent.Fill(dataSet, getParentTable());

            // establish relation between tables
            bindingSourceParent.DataSource = dataSet;
            bindingSourceParent.DataMember = getParentTable();
            dgvParent.DataSource = bindingSourceParent;

            DataColumn parentPKColumn = dataSet.Tables[getParentTable()].Columns[getParentPKName()];
            DataColumn childFKColumn = dataSet.Tables[getChildTable()].Columns[getChildFKName()];
            childParentRelation = new DataRelation("FK_child_parent", parentPKColumn, childFKColumn);
            dataSet.Relations.Add(childParentRelation);

            bindingSourceChild.DataSource = bindingSourceParent;
            bindingSourceChild.DataMember = "FK_child_parent";
            dgvChild.DataSource = bindingSourceChild;

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapterChild);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapterChild.Update(dataSet, getChildTable());
                MessageBox.Show("Update was successful!");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
