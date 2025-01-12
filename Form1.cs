using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notlar
{
    public partial class Form1 : Form
    {
        DataTable table;//tablo oluşturma
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Başlık", typeof(String));//tablonun içine yazılacak başlık 1. sütun
            table.Columns.Add("Not", typeof(String)); // 2. sütun
            dataGridView1.DataSource = table; // oluşturulan tabloyu grind e attım

            dataGridView1.Columns["Not"].Visible = true; // açıldığında notlar görünmesin
            dataGridView1.Columns["Başlık"].Width = 100; // başlığı güzel yazma
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            basliktextBox1.Clear();
            nottextBox2.Clear();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(basliktextBox1.Text, nottextBox2.Text);//tabledaki satırlara textbox lardaki bilgileri yazma
            basliktextBox1.Clear();
            nottextBox2.Clear();
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex; // o anki index tıkladığın anda
            if (index > -1)//elbet seçilmiştir
            {
                basliktextBox1.Text = table.Rows[index].ItemArray[0].ToString();//itemArry, bir dizi aracılığıyla bu satırın değerlerini ayarlamak veya almak için kullanabilirsiniz. 
                nottextBox2.Text = table.Rows[index].ItemArray[1].ToString();//örneğin 2. satırdayız index=1 table ın 2. satırını itemarray yardımıyla note text box a yazma (bu sırada string e dödüştürdük)
            }
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;// tıkladığın andaki index
            table.Rows[index].Delete();
        }
    }
}