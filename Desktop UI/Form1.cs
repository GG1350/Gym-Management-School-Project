using Gym_Management__Project_.APP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_UI
{
    public partial class Form1 : Form
    {
        private readonly GymService service;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var members = service.GetMembers();

            dataGridView1.DataSource = members
            .Select(m => new
            {
                m.Id,
                m.FirstName,
                m.LastName,
                m.CardStatus
            }).ToList();

        }
    }
}
