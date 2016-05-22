using Roslinq.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoslinqForms
{
    public partial class RoslinqForm : Form
    {
        public RoslinqForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var solution = new DeveSolution(@"..\..\..\Roslinq.sln");

            var solu = solution.Projects.ToList();

            foreach (var method in solution.AllMethods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
