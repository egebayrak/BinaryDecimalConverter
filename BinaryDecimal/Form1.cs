using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryDecimal
{
    public partial class BinaryDecimalConverter : Form
    {
        public BinaryDecimalConverter()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(new object[] { "Binary to Decimal", "Decimal to Binary" });
        }

        public int ConvertToDecimal(string binary)
        {
            int result = 0;
            int pow = 1;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(binary[i].ToString());
                result += pow * digit;
                pow *= 2;
            }

            return result;
        }

        public string ConvertToBinary(int decimalNumber)
        {
            string binary = "";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2;
                decimalNumber /= 2;
                binary = remainder.ToString() + binary;
            }

            return binary;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblResult.Text);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInput.Text, out int number))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
                txtInput.Clear();
                return;
            }

            string input = txtInput.Text.ToString();
            string selected = comboBox1.SelectedItem.ToString();

            if (selected == "Binary to Decimal")
            {
                int result = ConvertToDecimal(input);
                lblResult.Text = $"{result.ToString()}";
            }
            else if (selected == "Decimal to Binary")
            {
                string result = ConvertToBinary(number);
                lblResult.Text = $"{result}";
            }
        }
    }
}
