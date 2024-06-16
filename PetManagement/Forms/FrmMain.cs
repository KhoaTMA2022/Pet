using PetManagement.Business.Interface;
using PetManagement.Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetManagement.Forms
{
    public partial class FrmMain : Form
    {

        private readonly IPetService _petService;

        public FrmMain(IPetService petService)
        {
            _petService = petService;
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BindingData();
        }

        private void BindingData()
        {
            DataTable dataTable = _petService.FindAll();
            petGV.DataSource = dataTable;
        }
    }
}
