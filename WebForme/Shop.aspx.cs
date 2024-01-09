using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebForme
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            string productDescription = txtProductDescription.Text.Trim();

            if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productDescription))
            {
                SaveProduct(productName, productDescription);

                LoadProducts();

                ClearInputs();
            }
            else
            {
                lblMessage.Text = "Unesite naziv i opis proizvoda.";
            }
        }

        private void LoadProducts()
        {
            string connectionString = "Data Source=RAZNO\\SQLEXPRESSPIN;Initial Catalog=WebFormsLabos;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Name, Description FROM Products";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gridProducts.DataSource = dt;
                    gridProducts.DataBind();
                }
            }
        }

        private void SaveProduct(string productName, string productDescription)
        {
            string connectionString = "Data Source=RAZNO\\SQLEXPRESSPIN;Initial Catalog=WebFormsLabos;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Products (Name, Description) VALUES (@Name, @Description)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);
                    command.Parameters.AddWithValue("@Description", productDescription);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void ClearInputs()
        {
            txtProductName.Text = string.Empty;
            txtProductDescription.Text = string.Empty;
        }

        protected void gridProducts_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Style["background-color"] = "#337ab7";
                e.Row.Style["color"] = "#ffffff";
            }
        }
    }
}
