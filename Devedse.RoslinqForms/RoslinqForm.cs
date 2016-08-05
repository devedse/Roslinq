using Devedse.Roslinq.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devedse.RoslinqForms
{
    public partial class RoslinqForm : Form
    {
        public RoslinqForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var solution = new DeveSolution(@"..\..\..\Devedse.Roslinq.sln");

            var solu = solution.Projects.ToList();

            foreach (var method in solution.AllMethods)
            {
                Console.WriteLine(method.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var solution = new DeveSolution(@"..\..\..\Devedse.Roslinq.sln");

            var hallo = solution.AllDocuments;

            foreach (var doc in hallo)
            {
                var usings = doc.Usings.Select(t => t.ToString()).OrderBy(t => t).ToList();
                var allusings = doc.UnusedUsings.Distinct().OrderBy(t => t).ToList();



                foreach (var us in doc.UnusedUsings)
                {
                    Console.WriteLine(us);
                }
            }

        }
    }
}
