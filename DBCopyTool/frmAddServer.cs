using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseCopier
{
    public partial class frmAddServer : Form
    {
        private string _sServername;
        
        public frmAddServer()
        {
            InitializeComponent();
        }

        public string Servername
        {
            get { return _sServername; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            if (txtServername.Text == "")
            {
                MessageBox.Show("Please specify a servername/Ip...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _sServername = txtServername.Text;
                DialogResult = DialogResult.OK;
            }
            
            
        }
    }
}
