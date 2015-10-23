using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASPNET.MachineKeyUtil.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtMachineKey1.Text = KeyCreator.GetASPNET11machinekey();
            txtMachineKey2.Text = KeyCreator.GetASPNET20machinekey();
        }
        
    }
}
