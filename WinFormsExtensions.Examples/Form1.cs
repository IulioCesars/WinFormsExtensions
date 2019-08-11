using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsExtensions.Examples.Models;
using WinFormsExtensions.Helpers;

namespace WinFormsExtensions.Examples
{
    public partial class Form1 : Form
    {
        private BindingEntity<Person> BindingEntity { get; set; }

        public Form1()
        { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                BindingEntity = new BindingEntity<Person>(() => 
                    new Person()
                    {
                        FirstName = "Test"
                    }
                );

                BindingEntity.BindingControl(txtFirstName, it => it.FirstName);
                BindingEntity.BindingControl(txtLastName, it => it.LastName);
                BindingEntity.BindingControl(txtAge, it => it.Age);
                BindingEntity.BindingControl(dtpBirthDate, it => it.BirthDate);
            }
            catch (Exception ex)
            {
                DialogMessages.Exception(ex);
                Close();
            }
        }

        private void BtnShowInfo_Click(object sender, EventArgs e)
        {
            DialogMessages.Information(BindingEntity.Value.ToString());
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BindingEntity.New();
        }
    }
}
