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
		Product currentproduct = new Product();
		SqlCommand command = new SqlCommand();
		string connectionString = "server=DESKTOP-29SJ1T7; database=GetPro; Integrated Security=true";

		SqlConnection connection;

		public Form1()
		{
			InitializeComponent();
			connection = new SqlConnection(connectionString);
		}

		private void btnIsert_Click(object sender, EventArgs e)
		{
			currentproduct.ProductName = txtItem.Text;
			currentproduct.Design = txtDesign.Text;
			currentproduct.Color = txtColor.Text;

			string commandText = String.Format("Insert into Gproducts(ProductName,Design,Color)" +
				"values('{0}','{1}','{2}')", currentproduct.ProductName, currentproduct.Design, currentproduct.Color);
			  
			command = new SqlCommand(commandText, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
			RefreshGridviewproduct();
			clearform();
		}

		private void txtProductID_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtItem_TextChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RefreshGridviewproduct();
			txtProductID.ReadOnly = true;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			currentproduct.ProductName = txtItem.Text;
			currentproduct.Design = txtDesign.Text;
			currentproduct.Color = txtColor.Text;

			string commandText = string.Format("Update Gproducts set ProductName='{1}',Design='{2}',Color='{3}'" + "where ProductID ={0}"
				, currentproduct.ProductID, currentproduct.ProductName, currentproduct.Design, currentproduct.Color);

			command = new SqlCommand(commandText, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

			RefreshGridviewproduct();
			clearform();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			currentproduct.ProductName = txtItem.Text;
			currentproduct.Design = txtDesign.Text;
			currentproduct.Color = txtColor.Text;

			string commandText = String.Format("Delete from Gproducts where ProductID = {0}", currentproduct.ProductID);
				
			SqlCommand command = new SqlCommand(commandText, connection);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
			RefreshGridviewproduct();
			clearform();
		}
		private void clearform()
        {
			txtColor.Text = "";
			txtDesign.Text = "";
			txtItem.Text = "";
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
			currentproduct = new Product();

			DataGridViewRow row = new DataGridViewRow();
			row = dataGridView1.Rows[e.RowIndex];

			currentproduct.ProductID = int.Parse(row.Cells[0].Value.ToString());
			currentproduct.ProductName = row.Cells[1].Value.ToString();
			currentproduct.Design = row.Cells[2].Value.ToString();
			currentproduct.Color = row.Cells[3].Value.ToString();

			txtItem.Text = currentproduct.ProductName;
			txtDesign.Text = currentproduct.Design;
			txtColor.Text = currentproduct.Color;
		}
		public DataTable gettcomannd()
		{
			string command =String.Format("Select * from Gproducts");

			SqlCommand sqlCommand = new SqlCommand(command, connection);

			SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

			DataTable dt = new DataTable();

			da.Fill(dt);

			return dt;
		}
		private void RefreshGridviewproduct()
		{
			dataGridView1.DataSource = gettcomannd();
		}
	}
}

