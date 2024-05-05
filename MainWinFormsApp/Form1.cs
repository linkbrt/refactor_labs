using LR1;
using RLCExamples01;

namespace MainWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            fileTextBox.Text = openFileDialog1.FileName.Split("\\")[^1];

            string fileFormat = fileTextBox.Text.Split('.')[^1];
            switch (fileFormat)
            {
                case "csv":
                    buttonCSV.BackColor = Color.LightGreen;
                    buttonYAML.BackColor = SystemColors.Menu;
                    break;
                case "yaml":
                    buttonCSV.BackColor = SystemColors.Menu;
                    buttonYAML.BackColor = Color.LightGreen;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fileTextBox.Text == "")
            {
                MessageBox.Show("Âûבונטעו פאיכ!");
                return;
            }


            StreamReader sr = new StreamReader(openFileDialog1.OpenFile());

            BillFactory billFactory = new BillFactory(
                fileSource: FileSourceFactory.Create(fileTextBox.Text)
            );

            string bill = billFactory.CreateBill(sr);
            outputTextBox.Text = bill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = "";
        }
    }
}