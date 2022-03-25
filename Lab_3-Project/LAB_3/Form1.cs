using System.Data;
using System.Xml.Linq;

namespace LAB_3
{
    public partial class Form1 : Form
    {
        private const string V = "false";
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Hide();
            tabControl1.Hide();
            button1.Hide();
            richTextBox1.Enabled = false;
            dataGridView1.Enabled = false;
            informationAboutToolStripMenuItem.Enabled = false;
            informationToolStripMenuItem.Enabled = false;
            table.TableName = "table";
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Data name", typeof(string));
            table.Columns.Add("Cost", typeof(float));
            table.Columns.Add("Amount", typeof(int));
            table.Columns.Add("Avialability", typeof(bool));

            dataGridView1.DataSource = table;
        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                richTextBox1.Show();
                tabControl1.Show();
                tabPage2.Hide();
                button1.Hide();
                button1.Hide();
                richTextBox1.Enabled = false;
                dataGridView1.Enabled = false;
                richTextBox1.Text = "";
                table.Rows.Clear();
                Form2 f = new Form2();
                f.ShowDialog();
                informationAboutToolStripMenuItem.Enabled = true;
                informationToolStripMenuItem.Enabled = true;

            }

            if (toolStripComboBox1.SelectedIndex == 0)
            {
                richTextBox1.Enabled = false;
                dataGridView1.Enabled = false;

                richTextBox1.Text = "";
                table.Rows.Clear();
                string text = File.ReadAllText("C:/Users/sanarkk/source/repos/LAB_3/LAB_3/Items.txt");
                string[] lines = File.ReadAllLines(@"C:\Users\sanarkk\source\repos\LAB_3\LAB_3\Products.txt");
                string[] values;

                DataSet dataset = new DataSet();
                dataset.ReadXml(@"C:\Users\sanarkk\source\repos\LAB_3\LAB_3\Products.txt");
                dataGridView1.DataSource = dataset.Tables[0];

                richTextBox1.Text = text;
                richTextBox1.Show();
                tabControl1.Show();
                tabPage2.Hide();
                button1.Hide();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = File.ReadAllText("C:/Users/sanarkk/source/repos/LAB_3/LAB_3/Items.txt");
        }

        private void informationAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Hide();
            richTextBox1.Enabled = false;
            dataGridView1.Enabled = false;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(@"C:\Users\sanarkk\source\repos\LAB_3\LAB_3\Items.txt");

            DataSet dataset = new DataSet();
            dataset.ReadXml(filename);
            dataGridView1.DataSource = dataset.Tables[0];

            richTextBox1.Text = fileText;
            MessageBox.Show("Data loaded");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            button1.Show();

            MessageBox.Show("Data for update loaded");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;


            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable table = (DataTable)this.dataGridView1.DataSource;
                table.WriteXml(this.saveFileDialog1.FileName, XmlWriteMode.WriteSchema);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int data;
                data = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Amount"]?.Value);
                if (data > 0)
                    dataGridView1.Rows[e.RowIndex].Cells["Avialability"].Value = true;
                else
                    dataGridView1.Rows[e.RowIndex].Cells["Avialability"].Value = false;
            }
        }
    }
}