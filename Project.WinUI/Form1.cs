using Project.BLL.DesignPatterns.GenericRepostory.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI
{
    public partial class Form1 : Form
    {
        CategoryRepository _cRep;
        ProductRepository _pRep;

        public Form1()
        {
            InitializeComponent();
            _cRep = new CategoryRepository();
            _pRep = new ProductRepository();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            BringCategories();

        }

        private void BringCategories()
        {
            listBox1.DataSource = _cRep.GetActives();
            listBox1.SelectedIndex = -1;
        }
        private void BringPassives()
        {
            listBox1.DataSource = _cRep.GetPassives();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _cRep.Add(new ENTITIES.Models.Category
            {
                CategoryName = textBox1.Text
            });
            BringCategories();
        }

        Category _selected;

        private void listBox1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem!=null)
            {
                _selected = listBox1.SelectedItem as Category;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(_selected!=null)
            {
                _cRep.Delete(_selected);
                _selected = null;
            }
            BringCategories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BringPassives();
        }
    }
}
