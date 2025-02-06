using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pazzl
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string fullImagePath = @"C:\Users\gold_\Downloads\singapore.jpg";
                pictureBoxFull.Image = Image.FromFile(fullImagePath);
            } catch (Exception ex)
            {
                MessageBox.Show("Error load full image: " + ex.Message);
            }
        }
    }
}
