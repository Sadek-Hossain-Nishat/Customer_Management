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

namespace SalesProject
{
    public partial class Form1 : Form

    {
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PV0HM6T;Initial Catalog=Sales_DB;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        

        public Form1()
        {
            InitializeComponent();

        }




        private void item_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (item.Text == "ProductA")
            {
                price.Text = "30";
                quantity.Text = "1";
                total.Text = "30";


            }
            if (item.Text == "ProductB")
            {
                price.Text = "40";
                quantity.Text = "1";
                total.Text = "40";


            }
            if (item.Text == "ProductC")
            {
                price.Text = "50";
                quantity.Text = "1";
                total.Text = "50";


            }
            if (item.Text == "ProductD")
            {
                price.Text = "60";
                quantity.Text = "1";
                total.Text = "60";


            }
            if (item.Text == "ProductE")
            {
                price.Text = "70";
                quantity.Text = "1";
                total.Text = "70";


            }
            if (item.Text == "ProductF")
            {
                price.Text = "80";
                quantity.Text = "1";
                total.Text = "80";


            }
            if (item.Text == "ProductG")
            {
                price.Text = "90";
                quantity.Text = "1";
                total.Text = "90";


            }
            if (item.Text == "ProductH")
            {
                price.Text = "100";
                quantity.Text = "1";
                total.Text = "100";


            }
            if (item.Text == "ProductI")
            {
                price.Text = "110";
                quantity.Text = "1";
                total.Text = "110";


            }
            if (item.Text == "ProductJ")
            {
                price.Text = "120";
                quantity.Text = "1";
                total.Text = "120";


            }


        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {

            if (quantity.Text == "")
            {

            }
            else
            {
                total.Text = (int.Parse(quantity.Text) * int.Parse(price.Text)).ToString();
            }

        }

        private List<SelectionItemDescription> items = new List<SelectionItemDescription>();
        private List<int> totalpricstore = new List<int>();




        private void addbtn_Click(object sender, EventArgs e)
        {

            


            
            if (item.Text== "Select Item") {
            }
            else
            {
                try
                {
                    itemtable.DataSource = new List<SelectionItemDescription>();
                    items.Add(new SelectionItemDescription(item.Text, price.Text, quantity.Text, total.Text));
                    totalpricstore.Add(int.Parse(total.Text));


                    //selectionItemDescriptionBindingSource.Add(new SelectionItemDescription(item.Text, price.Text, quantity.Text, total.Text));



                }
                catch (Exception)
                {

                }

                itemtable.DataSource = items;
                item.Text = "Select Item";
                price.Text = "";
                quantity.Text = "";
                total.Text = "";


                int t = 0;
                for (int i = 0; i < totalpricstore.Count; i++)
                {
                    t = t + totalpricstore[i];
                }
                totalprice.Text = t.ToString();

            }

            




        }

        int rowindex;


        private void deletebtn_Click(object sender, EventArgs e)
        {

            try
            {
                rowindex = itemtable.CurrentCell.RowIndex;






                itemtable.DataSource = new List<SelectionItemDescription>();

                items.RemoveAt(rowindex);
                totalpricstore.RemoveAt(rowindex);

                itemtable.DataSource = items;

            }
            catch (NullReferenceException)
            {

            }
            int t = 0;
            for (int i = 0; i < totalpricstore.Count; i++)
            {
                t = t + totalpricstore[i];
            }
            totalprice.Text = t.ToString();

        }

        private void paid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                    if (int.Parse(totalprice.Text) == 0)
                    {
                        due.Text = "0";

                    }
                    else
                    {
                        due.Text = (int.Parse(totalprice.Text) - int.Parse(paid.Text)).ToString();

                    }
                    

                



            }
            catch (Exception)
            {

                

            }


        }

        private void totalprice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(totalprice.Text) == 0)
                {
                    due.Text = "0";

                }
                else
                {
                    due.Text = (int.Parse(totalprice.Text) - int.Parse(paid.Text)).ToString();

                }

            }
            catch (Exception)
            {

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customerData.Customer_Details' table. You can move, or remove it, as needed.
            this.customer_DetailsTableAdapter.Fill(this.customerData.Customer_Details);
            

            showData();
            updatebtn.Visible = false;


        }

        private void showData()
        {
            try {

                dataAdapter = new SqlDataAdapter("select * from Customer_Details", conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                customerlist.DataSource = dataTable;
            }
            catch (Exception) {

            }

            
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            try {

                conn.Open();
                cmd = new SqlCommand("insert into Customer_Details values('" + name.Text+ "','" + phone.Text + "','" + address.Text + "','" + int.Parse(totalprice.Text) + "','" + int.Parse(paid.Text) + "','" + int.Parse(due.Text) + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The Customer has been added into Database Successfully");
                conn.Close();
                showData();
                name.Text = "";
                phone.Text = "";
                address.Text = "";
                item.Text = "Selected Item";
                price.Text = "";
                quantity.Text = "";
                total.Text = "";
                itemtable.DataSource = null;
                items = new List<SelectionItemDescription>(); 
                totalprice.Text = "";
                paid.Text = "";
                due.Text = "";
            }
            catch (Exception)
            {
               


            }
            


        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            updatebtn.Visible = false;

            customerid.ReadOnly = true;

            name2.ReadOnly = true;

            phone2.ReadOnly = true;

            address2.ReadOnly = true;

            total2.ReadOnly = true;

            paid2.ReadOnly = true;

            due2.ReadOnly = true;
            try
            {

                
                int selectedrowindex = customerlist.CurrentCell.RowIndex;
                DataGridViewRow selectedrow = customerlist.Rows[selectedrowindex];

                customerid.Text= selectedrow.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                name2.Text = selectedrow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();

                phone2.Text = selectedrow.Cells["phoneDataGridViewTextBoxColumn"].Value.ToString();

                address2.Text = selectedrow.Cells["addressDataGridViewTextBoxColumn"].Value.ToString();

                total2.Text = selectedrow.Cells["dataGridViewTextBoxColumn5"].Value.ToString();

                paid2.Text = selectedrow.Cells["paidDataGridViewTextBoxColumn"].Value.ToString();

                due2.Text = selectedrow.Cells["dueDataGridViewTextBoxColumn"].Value.ToString();

                


            }
            catch (Exception)
            {
                

            }
           



        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            updatebtn.Visible = true;
            customerid.ReadOnly = true;
            name2.ReadOnly = false;

            phone2.ReadOnly = false;

            address2.ReadOnly = false;

            total2.ReadOnly = false;

            paid2.ReadOnly = false;

            due2.ReadOnly = false;

            try {


                int selectedrowindex = customerlist.CurrentCell.RowIndex;
                DataGridViewRow selectedrow = customerlist.Rows[selectedrowindex];
                customerid.Text = selectedrow.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                name2.Text = selectedrow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();

                phone2.Text = selectedrow.Cells["phoneDataGridViewTextBoxColumn"].Value.ToString();

                address2.Text = selectedrow.Cells["addressDataGridViewTextBoxColumn"].Value.ToString();

                total2.Text = selectedrow.Cells["dataGridViewTextBoxColumn5"].Value.ToString();

                paid2.Text = selectedrow.Cells["paidDataGridViewTextBoxColumn"].Value.ToString();

                due2.Text = selectedrow.Cells["dueDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                cmd = new SqlCommand("UPDATE Customer_Details SET Name=@a1,Phone=@a2,Address=@a3,Total=@a4,Paid=@a5,Due=@a6 WHERE Id=@a7", conn);
                cmd.Parameters.AddWithValue("a1", name2.Text);
                cmd.Parameters.AddWithValue("a2", phone2.Text);
                cmd.Parameters.AddWithValue("a3", address2.Text);
                cmd.Parameters.AddWithValue("a4", int.Parse(total2.Text));
                cmd.Parameters.AddWithValue("a5", int.Parse(paid2.Text));
                cmd.Parameters.AddWithValue("a6", int.Parse(due2.Text));
                cmd.Parameters.AddWithValue("a7", int.Parse(customerid.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("The Selected Record has been Successfully Updated");
                conn.Close();
                showData();
                updatebtn.Visible = false;

                customerid.ReadOnly = true;

                name2.ReadOnly = true;

                phone2.ReadOnly = true;

                address2.ReadOnly = true;

                total2.ReadOnly = true;

                paid2.ReadOnly = true;

                due2.ReadOnly = true;

                customerid.Text = "";
                name2.Text = "";
                phone2.Text = "";
                address2.Text = "";
                total2.Text = "";
                paid2.Text = "";
                due2.Text = "";
            }
            catch (Exception)
            {
                

            }
            
        }

        

        private void deletebtn2_Click(object sender, EventArgs e)
        {
            

            try
            {
                int selectedrowindex = customerlist.CurrentCell.RowIndex;
                DataGridViewRow selectedrow = customerlist.Rows[selectedrowindex];
                customerid.Text = selectedrow.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                conn.Open();
                cmd = new SqlCommand("delete Customer_Details where Id=@id", conn);
                cmd.Parameters.AddWithValue("id", int.Parse(customerid.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("The Selected Customer has been Deleted from Database Successfully");
                conn.Close();
                showData();
                customerid.Text = "";
                name2.Text = "";
                phone2.Text = "";
                address2.Text = "";
                total2.Text = "";
                paid2.Text = "";
                due2.Text = "";
            }
            catch (Exception)
            {
                

            }

        }
    }
}











   

