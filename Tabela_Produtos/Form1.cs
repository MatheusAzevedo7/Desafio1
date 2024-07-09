using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabela_Produtos
{
    public partial class Form1 : Form
    {
        double quantidade = 0;
        double totalCompra = 0;
        public Form1()
        {
            InitializeComponent();
            // Adiciona o evento Click para todas as TextBoxes
            txtTijolo.Click += LimparListBox;
            txtPrego.Click += LimparListBox;
            txtCimento.Click += LimparListBox;
            txtTinta.Click += LimparListBox;

            // Adiciona o evento Click para o TextBox lbNotaFiscal
            lbNotaFiscal.Click += LimparListBox;
        }

        private void LimparListBox(object sender, EventArgs e)
        {
            lbNotaFiscal.Items.Clear();
        }
        private void QuantidadeProdutos(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            lbNotaFiscal.Items.Clear();

            if (string.IsNullOrWhiteSpace(txtTijolo.Text) &&
            string.IsNullOrWhiteSpace(txtPrego.Text) &&
            string.IsNullOrWhiteSpace(txtCimento.Text) &&
            string.IsNullOrWhiteSpace(txtTinta.Text))
            {
                MessageBox.Show("Preencha pelo menos um dos campos de quantidade antes de realizar a compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem fazer mais nada
            }
            totalCompra = 0;

            if (double.TryParse(txtTijolo.Text, out quantidade))
            {
                double precoUnitario = 1.59;
                double resultado = quantidade * precoUnitario;
                lbNotaFiscal.Items.Add($"Valor total do(s) Tijolo(s): R$ {resultado.ToString("F2")}");
                totalCompra += resultado;
                txtTijolo.ResetText();
            }

            if (double.TryParse(txtPrego.Text, out quantidade))
            {
                double precoUnitario = 0.50;
                double resultado = quantidade * precoUnitario;
                lbNotaFiscal.Items.Add($"Valor total do(s) Prego(s): R$ {resultado.ToString("F2")}");
                totalCompra += resultado;
                txtPrego.ResetText();
            }

            if (double.TryParse(txtCimento.Text, out quantidade))
            {
                double precoUnitario = 31.90;
                double resultado = quantidade * precoUnitario;
                lbNotaFiscal.Items.Add($"Valor total do(s) Cimento(s): R$ {resultado.ToString("F2")}");
                totalCompra += resultado;
                txtCimento.ResetText();
            }

            if (double.TryParse(txtTinta.Text, out quantidade))
            {
                double precoUnitario = 109.00;
                double resultado = quantidade * precoUnitario;
                lbNotaFiscal.Items.Add($"Valor total da(s) Tinta(s): R$ {resultado.ToString("F2")}");
                totalCompra += resultado;
                txtTinta.ResetText();
            }

            lbNotaFiscal.Items.Add($"Total da compra foi: R$ {totalCompra.ToString()}");

        }
    }
}
