using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Northind.Entities.Concrete;
using Northwind.WinForm.ApiClients.Abstract;
using Northwind.WinForm.ApiClients.Abstract.Concrete;


namespace Northwind.WinForm
{
    public partial class Category : Form
    {
        private ICategoryApiClient _categoryApiClient = new CategoryApiClient();
        private static List<Northind.Entities.Concrete.Category> categories = new List<Northind.Entities.Concrete.Category>{
            new Northind.Entities.Concrete.Category { Id = 1, Name="Category Id 1", Description = "Desc 1"},
            new Northind.Entities.Concrete.Category { Id = 2, Name="Category Id 2", Description = "Desc 2"}
        };

        public Category()
        {
            InitializeComponent();
        }

        private DataTable table = new DataTable();
        private int indexRow;
        private void Form1_Load(object sender, EventArgs e)
        {
             CetegoriesRead();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dgvEmploye.Rows[indexRow];
            textBoxId.Text = row.Cells[0].Value.ToString();
            textBoxDescription.Text = row.Cells[1].Value.ToString();
            textBoxName.Text = row.Cells[2].Value.ToString();
           

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dgvEmploye.Rows[indexRow];
            newDataRow.Cells[0].Value = textBoxId.Text;
            newDataRow.Cells[1].Value = textBoxDescription.Text;
            newDataRow.Cells[2].Value = textBoxName.Text;
           
        }

        private void CetegoriesRead()
        {
            var response =  _categoryApiClient.GetAllCAtegories().Content.ReadAsStringAsync().Result;

            var categories = JsonConvert.DeserializeObject<List<Northind.Entities.Concrete.Category>>(response);
            dgvEmploye.DataSource = categories;


        }
        private void btnRemove_ClickAsync(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvEmploye.SelectedRows)
            {
                try
                {
                    int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    _categoryApiClient.DeleteAsync(id);

                    CetegoriesRead();
                    //var response =await _categoryApiClient.DeleteAsync(id);
                    //string result =await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            CetegoriesRead();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _categoryApiClient.AddCategory(new Northind.Entities.Concrete.Category() { Name = textBoxDescription.Text, Description = textBoxDescription.Text });

            CetegoriesRead();
        }
    }
}
