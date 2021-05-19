/*App name: Pareto Analysis App
  App purpose: Provides a database-driven approach to keep track of inventory and assist in pareto analysis.
  App developer: Xinyang Li on 4/22/2021. */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParetoAnalysis
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit?", this.Text,
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
                this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit?", this.Text,
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
                this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load data into the 'product_DatabaseDataSet.PRODUCT' table
            this.pRODUCTTableAdapter.FillBySort2(this.product_DatabaseDataSet.PRODUCT);
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pRODUCTTableAdapter.FillBySort2(this.product_DatabaseDataSet.PRODUCT);
            //Declare variables
            double quantity, inventoryValue = 0, totalValue = 0, inventoryPercentage = 0, cumulativePercentage = 0;
            string productName, productCost;

            //Clear the listview
            productListView.Items.Clear();

            //Load the listview by reading through each row of the Employee table
            foreach (DataRow dr in product_DatabaseDataSet.PRODUCT.Rows)
            {
                //get Inventory Value from database and calculate total product value               
                totalValue += double.Parse(dr["Inventory_Value"].ToString());
            }
            foreach (DataRow dr in product_DatabaseDataSet.PRODUCT.Rows)
            {
                //calcualate invntory percentage and cumulative percentage for all products
                inventoryPercentage = inventoryValue / totalValue;
                cumulativePercentage += inventoryPercentage;

                //get rest of the data from database
                quantity = double.Parse(dr["Quantity_On_Hand"].ToString());
                inventoryValue = double.Parse(dr["Inventory_Value"].ToString());            
                productName = dr["Product_Name"].ToString();
                productCost = dr["Purchase_Cost"].ToString();

                //Create a listview to show all data and display it in the list view
                string[] fieldsArray = new string[6];
                fieldsArray[0] = productName;
                fieldsArray[1] = productCost;
                fieldsArray[2] = quantity.ToString("N0");
                fieldsArray[3] = inventoryValue.ToString("C2");
                fieldsArray[4] = inventoryPercentage.ToString("P2");
                fieldsArray[5] = cumulativePercentage.ToString("P2");
                ListViewItem showsLVI = new ListViewItem(fieldsArray);
                productListView.Items.Add(showsLVI);
            }
            //Display total product value in a label
            totalInvValueLabel.Text = totalValue.ToString("C2");
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            this.pRODUCTTableAdapter.FillBySort2(this.product_DatabaseDataSet.PRODUCT);
            //Declare variables
            double quantity, inventoryValue = 0, totalValue = 0, inventoryPercentage = 0, cumulativePercentage = 0;
            string productName, productCost;

            //Clear the listview
            productListView.Items.Clear();

            //Load the listview by reading through each row of the Employee table
            foreach (DataRow dr in product_DatabaseDataSet.PRODUCT.Rows)
            {
                //get Inventory Value from database and calculate total product value               
                totalValue += double.Parse(dr["Inventory_Value"].ToString());
            }
            foreach (DataRow dr in product_DatabaseDataSet.PRODUCT.Rows)
            {
                //calcualate invntory percentage and cumulative percentage for all products
                inventoryPercentage = inventoryValue / totalValue;
                cumulativePercentage += inventoryPercentage;

                //get rest of the data from database
                quantity = double.Parse(dr["Quantity_On_Hand"].ToString());
                inventoryValue = double.Parse(dr["Inventory_Value"].ToString());
                productName = dr["Product_Name"].ToString();
                productCost = dr["Purchase_Cost"].ToString();

                //Create a listview to show all data and display it in the list view
                string[] fieldsArray = new string[6];
                fieldsArray[0] = productName;
                fieldsArray[1] = productCost;
                fieldsArray[2] = quantity.ToString("N0");
                fieldsArray[3] = inventoryValue.ToString("C2");
                fieldsArray[4] = inventoryPercentage.ToString("P2");
                fieldsArray[5] = cumulativePercentage.ToString("P2");
                ListViewItem showsLVI = new ListViewItem(fieldsArray);
                productListView.Items.Add(showsLVI);
            }
            //Display total product value in a label
            totalInvValueLabel.Text = totalValue.ToString("C2");
        }       
    }
}
