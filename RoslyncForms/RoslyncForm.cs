using Roslync.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoslyncForms
{
    public partial class RoslyncForm : Form
    {
        public RoslyncForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var solution = new DeveSolution(@"..\..\..\Roslync.sln");

            var solu = solution.Projects.ToList();

            foreach (var method in solution.AllMethods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
