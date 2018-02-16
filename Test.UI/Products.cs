#region region

using System;
using System.Windows.Forms;
using Autofac;
using DataObject;
using TestProject.Dto;
using TestProject.Service;

#endregion

namespace TestProject.UI
{
    public partial class Products : Form
    {
        private ProductDto _productDto;
        public Products()
        {
            InitializeComponent();
            Load += Products_Load;
            dataGridViewProducts.CellClick += DataGridViewProducts_CellClick;
            _productDto = new ProductDto();
        }

        
        private void DataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
                _productDto = (ProductDto) dataGridViewProducts.CurrentRow.DataBoundItem;
        }

        private void Products_Load(object sender, EventArgs e)
        {

            using (var scope = Register.Container.BeginLifetimeScope())
            {
                var product = scope.Resolve<IProduct>();
                dataGridViewProducts.DataSource =new ProductService(product).GetAll();
            }
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            using (AddNewProduct addnew=new AddNewProduct())
            {
                addnew.Save += Addnew_Save;
                addnew.ShowDialog();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (AddNewProduct addnew = new AddNewProduct(_productDto.Id))
            {
                addnew.Save += Addnew_Save;
                addnew.ShowDialog();
            }
        }

        private void Addnew_Save(object sender, EventArgs e) => Products_Load(sender, e);

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"A feature request :D");
        }
    }
}
