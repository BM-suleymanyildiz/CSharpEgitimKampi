using CSharpEgitimKampi501.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi501
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Server=DESKTOP-9TE47SL\\SQLEXPRESS;initial Catalog=EgitimKampi501Db;integrated security=True");


        private async void btnList_Click(object sender, EventArgs e)
        {

            string query = "Select * from Tbl_Product";
            var values = await connection.QueryAsync<ResultProductDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into Tbl_Product(ProductName,ProductStock,ProductPrice,ProductCategory) values (@productName,@productStock,@productPrice,@productCategory) ";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", txtPrudoctName.Text);
            parameters.Add("@productStock", txtPrudoctStock.Text);
            parameters.Add("@productPrice", txtPrudoctPrice.Text);
            parameters.Add("@productCategory", txtPrudoctCategory.Text);

            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Yeni Kitap Ekleme İşlemi Başarılı");


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From Tbl_Product where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", txtPrudoctId.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Kitap Silme İşlemi Başarılı");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update Tbl_Product set ProductName=@productName,ProductPrice=@productPrice,ProductStock=@productStock,ProductCategory=@productCategory where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", txtPrudoctName.Text);
            parameters.Add("@productPrice", txtPrudoctPrice.Text);
            parameters.Add("@productStock", txtPrudoctStock.Text);
            parameters.Add("@productCategory", txtPrudoctCategory.Text);
            parameters.Add("@productId", txtPrudoctId.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Kitap Güncelleme İşlemi Başarılı", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query1 = "Select count(*) from Tbl_Product";
            var productTotalCount = await connection.QueryFirstOrDefaultAsync<int>(query1);
            lblTotalProductCount.Text = productTotalCount.ToString();

            string query2 = "Select ProductName from Tbl_Product where ProductPrice=(Select Max(ProductPrice) from Tbl_Product)";
            var maxPriceProductName = await connection.QueryFirstOrDefaultAsync<string>(query2);
            lblMaxPriceProductName.Text = maxPriceProductName.ToString();

            string query3 = "Select Count(Distinct(ProductCategory)) From Tbl_Product";
            var distinctProductCount = await connection.QueryFirstOrDefaultAsync<int>(query3);
            lblDistinctCategoryCount.Text = distinctProductCount.ToString();



        }
    }
}
