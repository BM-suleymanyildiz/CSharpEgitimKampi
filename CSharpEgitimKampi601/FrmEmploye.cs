﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class FrmEmploye : Form
    {
        public FrmEmploye()
        {
            InitializeComponent();
        }
        //**** yerine şifrenizi giriniz.
        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;userId=postgres;password=****";

        void EmployeeList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * from Employees";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        void DepartmentList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * from Departments";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbEmployeeDepartment.DisplayMember = "DepartmentName";
            cmbEmployeeDepartment.ValueMember = "DepartmentId";
            cmbEmployeeDepartment.DataSource = dataTable;
            connection.Close();

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void FrmEmploye_Load(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmentList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text;
            string employeeSurname = txtEmployeeSurname.Text;
            decimal employeeSalary = decimal.Parse(txtEmployeeSalary.Text);
            int departmentId = int.Parse(cmbEmployeeDepartment.SelectedValue.ToString());


            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "insert into Employees (EmployeeName,EmployeeSurname,EmployeeSalary,Departmentid) values (@employeeName,@employeeSurname,@employeeSalary,@departmentid)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("EmployeeName", employeeName);
            command.Parameters.AddWithValue("EmployeeSurname", employeeSurname);
            command.Parameters.AddWithValue("EmployeeSalary", employeeSalary);
            command.Parameters.AddWithValue("departmentid", departmentId);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme İşlemi Başarılı");
            connection.Close();
            EmployeeList();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtEmployeeId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Delete From Employees where EmployeeId=@employeeId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("employeeId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");
            connection.Close();
            EmployeeList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string EmployeeName = txtEmployeeName.Text;
            string EmployeeSurname = txtEmployeeSurname.Text;
            decimal EmployeeSalary = decimal.Parse(txtEmployeeSalary.Text);
            int departmentId = int.Parse(cmbEmployeeDepartment.SelectedValue.ToString());

            int id = int.Parse(txtEmployeeId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Update Employees set EmployeeName=@employeeName,EmployeeSurname=@employeeSurname,EmployeeSalary=@employeeSalary,DepartmentId=@departmentid where EmployeeId=@employeeId";
            var command = new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("employeeName", EmployeeName);
            command.Parameters.AddWithValue("employeeSurName", EmployeeSurname);
            command.Parameters.AddWithValue("employeeSalary", EmployeeSalary);
            command.Parameters.AddWithValue("departmentid", departmentId);
            command.Parameters.AddWithValue("employeeid", id);

            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            connection.Close();
            EmployeeList();

        }
    }
}
