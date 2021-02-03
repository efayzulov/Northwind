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
using Northwind.Web.UI.ApiClients.Concrete;
using Northwind.WinForm.ApiClients.Abstract;
using Northwind.WinForm.ApiClients.Abstract.Concrete;

namespace Northwind.WinForm
{
    public partial class Employe : Form
    {
        private EmployeApiClient _employeApiClient = new EmployeApiClient();

        private static List<Northind.Entities.Concrete.Employe> employe = new List<Northind.Entities.Concrete.Employe>
        {
            new Northind.Entities.Concrete.Employe {Id = 1, LastName = "Fuller", FirstName = "Andrew", Title = "Vice President Sales", TitleOfCourtesy = "Dr"},
            
            new Northind.Entities.Concrete.Employe {Id = 1, LastName = "Buchanan", FirstName = "Steven", Title = "Sales Manager", TitleOfCourtesy = "Dr"}

        };

        public Employe()
        {
            InitializeComponent();
        }

        private DataTable table = new DataTable();
        private int indexRow;

        private void Employe_Load(object sender, EventArgs e)
        {
            EmployeReadAsync();
        }

        private async Task EmployeReadAsync()
        {
            ////var response = _employeApiClient.GetAllEmploye().Result;
            ////string result = response.Content.ReadAsStringAsync().Result;

            ////var employe = JsonConvert.DeserializeObject<List<Employe>>(result);
            //dgvEmploye.DataSource = employe;

            var response = await _employeApiClient.GetAllEmploye();
            string result = await response.Content.ReadAsStringAsync();
            switch ((int)response.StatusCode)
            {
                //case (int)HttpStatusCode.OK:
                //    var categories = JsonConvert.DeserializeObject<List<Employe>>(result);
                //    return Json(new { Success = true, data = employes }, JsonRequestBehavior.AllowGet);
                //case (int)HttpStatusCode.NotFound:
                //    return HttpNotFound();
                //default:
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        private void dgvEmploye_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dgvEmploye.Rows[indexRow];
            textBoxId.Text = row.Cells[0].Value.ToString();
            textBoxFirstName.Text = row.Cells[1].Value.ToString();
            textBoxFirstName.Text = row.Cells[2].Value.ToString();
            textBoxTitle.Text = row.Cells[3].Value.ToString();
            textBoxTitleOC.Text = row.Cells[4].Value.ToString();
            ////dateTimePickerBirthDate.Text = row.Cells[5].Value.ToString();
            ////dateTimePickerHireDate.Text = row.Cells[6].Value.ToString();
            //textBoxAddress.Text = row.Cells[7].Value.ToString();
            //textBoxNotes.Text = row.Cells[8].Value.ToString();
            //textBoxReports.Text = row.Cells[9].Value.ToString();
        }
      
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dgvEmploye.Rows[indexRow];
            newDataRow.Cells[0].Value = textBoxId.Text;
            newDataRow.Cells[1].Value = textBoxFirstName.Text;
            newDataRow.Cells[3].Value = textBoxFirstName.Text;
            newDataRow.Cells[4].Value = textBoxTitle.Text;
            newDataRow.Cells[5].Value = textBoxTitleOC.Text;
            newDataRow.Cells[6].Value = textBoxTitleOC.Text;
            newDataRow.Cells[7].Value = dateTimePickerBirthDate.Text;
            newDataRow.Cells[8].Value = dateTimePickerHireDate.Text;
            newDataRow.Cells[9].Value = textBoxAddress.Text;
            newDataRow.Cells[10].Value = textBoxNotes.Text;
            newDataRow.Cells[11].Value = textBoxName.Text;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmploye.SelectedRows)
            {
                try
                {
                    int id = Convert.ToInt32(row.Cells[0].Value.ToString());

                    //var response =await _categoryApiClient.DeleteAsync(id);
                    //string result =await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            EmployeReadAsync();
        }
    }
}

   