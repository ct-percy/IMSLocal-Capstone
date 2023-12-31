﻿using IMSLocal.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMSLocal
{
    public partial class Log_In : Form
    {
        BindingList<Employees> employees;
        public async void loadData()
        {
            employees = new BindingList<Employees>(await Employees.getEmployees());
        }

        public Log_In()
        {
            loadData();
            InitializeComponent();
            exitButton.Hide();
           

        }

        private void Log_In_Load(object sender, EventArgs e)
        {

        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }

        private  void logInButton_Click(object sender, EventArgs e)
        {
            bool activeUser = false;

            for (int i = 0; i < employees.Count(); i++)
            {
                if (userNameTextbox.Text == employees[i].userName && passwordTextbox.Text == employees[i].password)
                {
                    MainScreen ms = new MainScreen(employees[i].userName);
                    ms.Show();
                    logInButton.Hide();
                    adminButton.Hide();
                    userNameTextbox.Hide();
                    passwordTextbox.Hide();
                    exitButton.Show();
                    label1.Visible = false;
                    label2.Visible = false;
                    activeUser = true;
                    return;

                }
                
                
            }
            if (activeUser == false)
            {
                MessageBox.Show("Username and Password did not match");
                return;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
