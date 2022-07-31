using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLiPhongMay.GUI
{
    public partial class FAdmin : Form
    {
        DataTable DT = new DataTable();
        BO.Account User;
        public delegate void FloginFormShow();
        FloginFormShow eventHandle;
        public FAdmin(BO.Account userInfo, FloginFormShow eventHandle)
        {
            this.User = userInfo;
            this.eventHandle = eventHandle;
            InitializeComponent();
            GetData();
        }
        private void GetData()
        {
            OLEAAdapter AD = new OLEAAdapter();
            DataTable TableNames = AD.GetTableNames();
            comboBoxTable.Items.Clear();
            foreach (DataRow Row in TableNames.Rows)
            {
                comboBoxTable.Items.Add(Row.Field<string>("Name"));
            }
            if (TableNames.Rows.Count > 0)
            {
                comboBoxTable.SelectedIndex = 0;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                OLEAAdapter AD = new OLEAAdapter();
                DT = AD.GetAlls(comboBoxTable.Text);
                DG.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OLEAAdapter AD = new OLEAAdapter();

                AD.Update(comboBoxTable.Text, DT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            eventHandle();
        }
    }
}
