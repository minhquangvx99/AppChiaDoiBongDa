using System.Windows.Forms;
using System;
using System.Reflection;

namespace AppChiaDoiBongDa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                ChiaDoi();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập các cặp để chia đội");
                return;
            }
        }
        private void ChiaDoi()
        {
            Random rnd = new Random();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.GetItemText(listBox1.Items[i]);
                string[] list = item.Split('-');
                if (list.Length == 2)
                {
                    int num = rnd.Next();
                    if (num % 2 == 1)
                    {
                        listBox2.Items.Add(list[0]);
                        listBox3.Items.Add(list[1]);
                    }
                    else
                    {
                        listBox2.Items.Add(list[1]);
                        listBox3.Items.Add(list[0]);
                    }
                }
                else
                {
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    MessageBox.Show("Vui lòng nhập đúng định dạng như Ví dụ");
                    return;
                }
            }
            MessageBox.Show("Chia đội thành công");
        }
    }
}