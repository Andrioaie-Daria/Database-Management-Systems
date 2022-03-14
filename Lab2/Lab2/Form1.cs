using Microsoft.Build.Framework.XamlTypes;
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


namespace Lab2
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-ERFTJDA; Initial Catalog = CatsDB; Integrated Security = True;");
        DataSet ds = new DataSet();
        SqlDataAdapter daCats = new SqlDataAdapter();
        SqlDataAdapter daSlaves = new SqlDataAdapter();

        BindingSource bs = new BindingSource();

        DataRelation drcatsHumans;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            daCats.SelectCommand = new SqlCommand("SELECT * FROM Cats", conn);

            daCats.Fill(ds, "Cats");

            dgvCats.DataSource = ds.Tables["Cats"];

            bs.DataSource = ds.Tables["Cats"];
            txtID.DataBindings.Add("text", bs, "CatID");
            txtName.DataBindings.Add("text", bs, "Name");
            txtBreed.DataBindings.Add("text", bs, "Breed");
            txtAge.DataBindings.Add("text", bs, "Age");
            txtColour.DataBindings.Add("text", bs, "Colour");
            txtCrazyLevel.DataBindings.Add("text", bs, "CrazyLevel");

            daSlaves.SelectCommand = new SqlCommand("SELECT * FROM HumanSlaves", conn);
            daSlaves.Fill(ds, "Slaves");
            dgvSlaves.DataSource = ds.Tables["Slaves"];

            DataColumn catsColumn = ds.Tables["Cats"].Columns["CatID"];
            DataColumn slavesColumn = ds.Tables["Slaves"].Columns["CatID"];
            drcatsHumans = new DataRelation("Cats_Humans", catsColumn, slavesColumn);

            ds.Relations.Add(drcatsHumans);

            //drcatsHumans.ParentTable.Columns....

        }

        private void updateDgvSelection()
        {
            dgvCats.ClearSelection();
            dgvCats.Rows[bs.Position].Selected = true;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
            updateDgvSelection();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
            updateDgvSelection();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
            updateDgvSelection();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
            updateDgvSelection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            daCats.InsertCommand = new SqlCommand("INSERT INTO Cats " +
                "VALUES ( @CatID, @Name, @Breed, @Age, @Colour, @Crazyness)", conn);

            daCats.InsertCommand.Parameters.Add("@CatID", SqlDbType.Int).Value = txtID.Text;
            daCats.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
            daCats.InsertCommand.Parameters.Add("@Breed", SqlDbType.VarChar).Value = txtBreed.Text;
            daCats.InsertCommand.Parameters.Add("@Age", SqlDbType.Int).Value = txtAge.Text;
            daCats.InsertCommand.Parameters.Add("@Colour", SqlDbType.VarChar).Value = txtColour.Text;
            daCats.InsertCommand.Parameters.Add("@Crazyness", SqlDbType.Int).Value = txtCrazyLevel.Text;
            conn.Open();
            daCats.InsertCommand.ExecuteNonQuery();
            conn.Close();

            ds.Clear();
            daCats.Fill(ds, "Cats");
        }
    }
}
