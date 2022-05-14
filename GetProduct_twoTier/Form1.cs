using GetProduct_twoTier.Entities;
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

namespace GetProduct_twoTier
{
    public partial class Form1 : Form
    {
        Product product = new Product();


        string connectionString = "Server=DESKTOP-29SJ1T7; database=GetProduct; Integrated Security=true";

        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void btnIsert_Click(object sender, EventArgs e)
        {
            string commandText = $"Insert into GProduct values('{product.ProductName}', '{product.Design}'," +
              $" {product.Color}, {product.ProductID} )";

            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string command = "Select * from GProduct";

            SqlCommand sqlCommand = new SqlCommand(command, connection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string commandText = $"Update GProduct Set " +
                $"ProductName = '{product.ProductName}', " +
                $"Design = '{product.Design}', " +
                $"Color = '{product.Color}', " +
                $"ProductID = {product.ProductID} " +
                $"where ProductID = {product.ProductID}";

            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string commandText = $"Delete from GProduct where ProdectID = {product.ProductID}";

            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblItemName_Click(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }

        private void txtDesign_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDesign_Click(object sender, EventArgs e)
        {

        }

        private void lblProdectID_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];

            product.StudentId = int.Parse(row.Cells[0].Value.ToString());
            product.StudentFirstName = row.Cells[1].Value.ToString();
            product.StudentLastName = row.Cells[2].Value.ToString();

            txtStudentFirstName.Text = product.StudentFirstName;
            txtStudentLastName.Text = product.StudentLastName;
        }
    }
}

