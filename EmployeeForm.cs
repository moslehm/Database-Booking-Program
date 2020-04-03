﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS291_Project
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
                                                                    "AttachDbFilename=|DataDirectory|Database1.mdf;" +
                                                                    "Integrated Security=True"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = "select * from customer ";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    customerComboBox.Items.Add(dataReader[0] +  ", " + dataReader[1] + ", " + dataReader[2]);
                }
                connection.Close();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm nU = new LoginForm();
            nU.ShowDialog();
            this.Close();
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            string selectedCustomer = customerComboBox.SelectedItem.ToString();
            int customerID = Int32.Parse(Regex.Match(selectedCustomer, @"\d+").Value);

            // Open booking form and pass in customerID
        }
    }
}
