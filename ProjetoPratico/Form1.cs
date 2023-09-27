using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPratico
{
    public partial class btnLimparPreco : Form
    {
        public btnLimparPreco()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show ("Tem certeza que deseja sair?", "Sair?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            textBoxNome.Clear();
            maskedTextBoxRg.Clear();
            maskedTextBoxCpf.Clear();
            maskedTextBoxPass.Clear();
            textBoxNome.Enabled = true;
            maskedTextBoxRg.Enabled = true;
            maskedTextBoxCpf.Enabled = true;
            maskedTextBoxPass.Enabled = true;
            listBox1.Items.RemoveAt(0);
            listBox1.Items.RemoveAt(0);
            listBox1.Items.RemoveAt(0);
            listBox1.Items.RemoveAt(0);
            textBoxNome.Focus();
            btnInserir.Enabled = true;
            btnLimpar.Enabled = false;
            btnEscolherDestino.Enabled = false;
            comboBoxDestino.Enabled = false;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(0, "Nome: " + textBoxNome.Text);
            listBox1.Items.Insert(1, "RG: " + maskedTextBoxRg.Text);
            listBox1.Items.Insert(2, "CPF: " + maskedTextBoxCpf.Text);
            listBox1.Items.Insert(3, "Passaporte: " + maskedTextBoxPass.Text);
            textBoxNome.Enabled = false;
            maskedTextBoxRg.Enabled = false;
            maskedTextBoxCpf.Enabled = false;
            maskedTextBoxPass.Enabled = false;
            btnInserir.Enabled = false;
            btnEscolherDestino.Enabled = true;
            btnLimpar.Enabled = true;
            comboBoxDestino.Enabled = true;

        }

        private void comboBoxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDestino.SelectedIndex == -1)
            {
                pictureBoxDestino.Visible = true;
                pictureBoxDestino.Image = null;
            }
            else if (comboBoxDestino.SelectedIndex == 0)
            {
                pictureBoxDestino.Visible = true;
                pictureBoxDestino.Image = Properties.Resources.foz_parana;
            }
            else if (comboBoxDestino.SelectedIndex == 1)
            {
                pictureBoxDestino.Visible = true;
                pictureBoxDestino.Image = Properties.Resources.LencoisMaranhenses_Maranhao;
            }
            else if (comboBoxDestino.SelectedIndex == 2)
            {
                pictureBoxDestino.Visible = true;
                pictureBoxDestino.Image = Properties.Resources.maceio_alagoas;
            }
            else if (comboBoxDestino.SelectedIndex == 3)
            {
                pictureBoxDestino.Visible = true;
                pictureBoxDestino.Image = Properties.Resources.salvador_bahia;
            }
        }

        private void btnEscolherDestino_Click(object sender, EventArgs e)
        {
            listBox1.Items.Insert(4, "------------------------------------------------------------");
            listBox1.Items.Insert(5, "Destino: " + comboBoxDestino.SelectedItem);
            comboBoxDestino.Enabled = false;
            btnEscolherDestino.Enabled = false;
            btnLimpar.Enabled = false;
            maskedTextBoxDataIda.Enabled = true;
            btnSelecionarIda.Enabled = true;
            btnEscolherOutro.Enabled = true;
        }

        private void btnEscolherOutro_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(4);
            listBox1.Items.RemoveAt(4);
            comboBoxDestino.SelectedIndex = -1;
            comboBoxDestino.Enabled = true;
            btnEscolherDestino.Enabled = true;
            btnLimpar.Enabled = true;
            pictureBoxDestino.Visible = true;
            btnEscolherOutro.Enabled = false;
        }

        private void btnSelecionarIda_Click(object sender, EventArgs e)
        {
            DateTime data = monthCalendar1.SelectionStart;

            maskedTextBoxDataIda.Text = data.ToShortDateString();
            maskedTextBoxDataIda.Enabled = false;
            btnSelecionarIda.Enabled = false;
            maskedTextBoxDataVolta.Enabled = true;
            btnSelecionarVolta.Enabled = true;
            btnEscolherOutro.Enabled = false;
        }

        private void btnSelecionarVolta_Click(object sender, EventArgs e)
        {
            DateTime data = monthCalendar1.SelectionStart;

            maskedTextBoxDataVolta.Text = data.ToShortDateString();
            maskedTextBoxDataVolta.Enabled = false;
            btnSelecionarVolta.Enabled = false;
            maskedTextBoxDataVolta.Enabled = false;
            btnLimparData.Enabled = true;

            listBox1.Items.Insert(6, "------------------------------------------------------------");
            listBox1.Items.Insert(7, "Data de Ida: " + maskedTextBoxDataIda.Text);
            listBox1.Items.Insert(8, "Data de Volta: " + maskedTextBoxDataVolta.Text);

            btnSelecTipoViagem.Enabled = true;
            btnLimparTipoViagem.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;

        }

        private void btnLimparData_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(6);
            listBox1.Items.RemoveAt(6);
            listBox1.Items.RemoveAt(6);
            maskedTextBoxDataIda.Enabled = true;
            btnSelecionarIda.Enabled = true;
            btnEscolherOutro.Enabled = true;
            btnLimparData.Enabled = false;
        }

        private void btnSelecTipoViagem_Click(object sender, EventArgs e)
        {
            string final, tipo1 = "", tipo2 = "", tipo3 = "", tipo4 = "";

            

            if (checkBox1.Checked)
            {
                tipo1 = checkBox1.Text + ". ";
            }

            if (checkBox2.Checked)
            {
                tipo2 = checkBox2.Text + ". ";
            }

            if (checkBox3.Checked)
            {
                tipo3 = checkBox3.Text + ". ";
            }

            if (checkBox4.Checked)
            {
                tipo4 = checkBox4.Text + ". ";
            }

            final = tipo1 + tipo2 + tipo3 + tipo4;


            listBox1.Items.Insert(9, "------------------------------------------------------------");
            listBox1.Items.Insert(10, "Tipo de Viagem: " + final);

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;

            btnSelecTipoViagem.Enabled = false;
            btnSelecTipoAlojam.Enabled = true;
            btnLimparData.Enabled = false;
            btnLimparTipoViagem.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
        }

        private void FormViagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btnLimparTipoViagem_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;

            listBox1.Items.RemoveAt(9);
            listBox1.Items.RemoveAt(9);
            btnSelecTipoViagem.Enabled = true;
            btnLimparTipoViagem.Enabled = false;
            btnSelecTipoAlojam.Enabled = false;
            btnLimparData.Enabled = true;
        }

        private void trackBarPreco_Scroll(object sender, EventArgs e)
        {
            labelValor.Text = trackBarPreco.Value.ToString("C");
        }

        private void btnSelecTipoAlojam_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
            {
                string resultado;

                if (radioButton1.Checked)
                {
                    resultado = radioButton1.Text;
                    listBox1.Items.Insert(11, "------------------------------------------------------------");
                    listBox1.Items.Insert(12, "Tipo de Alojamento: " + resultado);
                }
                else if (radioButton2.Checked)
                {
                    resultado = radioButton2.Text;
                    listBox1.Items.Insert(11, "------------------------------------------------------------");
                    listBox1.Items.Insert(12, "Tipo de Alojamento: " + resultado);
                }
                else if (radioButton3.Checked)
                {
                    resultado = radioButton3.Text;
                    listBox1.Items.Insert(11, "------------------------------------------------------------");
                    listBox1.Items.Insert(12, "Tipo de Alojamento: " + resultado);
                }
                else if (radioButton4.Checked)
                {
                    resultado = radioButton4.Text;
                    listBox1.Items.Insert(11, "------------------------------------------------------------");
                    listBox1.Items.Insert(12, "Tipo de Alojamento: " + resultado);
                }

                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                btnSelecTipoAlojam.Enabled = false;
                btnLimparTipoViagem.Enabled = false;

                listBoxAtividExtras.Enabled = true;
                btnEscolherAtividExtras.Enabled = true;
                btnEscolherNovamente.Enabled = false;
                btnLimparTipoAlojam.Enabled = true;
            }
            else
            {
                MessageBox.Show("Favor selecionar alojamento", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnLimparTipoAlojam_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(11);
            listBox1.Items.RemoveAt(11);

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            btnSelecTipoAlojam.Enabled = true;
            btnLimparTipoViagem.Enabled = true;

            listBoxAtividExtras.Enabled = false;
            btnEscolherAtividExtras.Enabled = false;
            btnEscolherNovamente.Enabled = false;
            btnLimparTipoAlojam.Enabled = false;


        }

        private void btnEscolherAtividExtras_Click(object sender, EventArgs e)
        {
            StringBuilder atividadesFinal = new StringBuilder();

            foreach (object selectedItem in listBoxAtividExtras.SelectedItems)
            {
                string atividadeEscolhida = selectedItem.ToString();
                atividadesFinal.Append(atividadeEscolhida);
                atividadesFinal.Append(", ");
              
            }

            if (atividadesFinal.Length > 2)
            {
                atividadesFinal.Length -= 2;
            }
            listBox1.Items.Insert(13, "------------------------------------------------------------");
            listBox1.Items.Insert(14, "Atividades Escolhidas: " + atividadesFinal);

            btnEscolherAtividExtras.Enabled = false;
            btnLimparTipoAlojam.Enabled = false;
            btnEscolherNovamente.Enabled = true;
            btnSelecionarPreco.Enabled = true;
            listBoxAtividExtras.Enabled = false;
            trackBarPreco.Enabled = true;
        }

        private void btnEscolherNovamente_Click(object sender, EventArgs e)
        {
            btnLimparTipoAlojam.Enabled = true;
            btnEscolherAtividExtras.Enabled = true;
            btnEscolherNovamente.Enabled = false;
            listBoxAtividExtras.Enabled = true;
            btnSelecionarPreco.Enabled = false;
            trackBarPreco.Enabled = false;
            btnLimpaPreco.Enabled = false;

            listBox1.Items.RemoveAt(13);
            listBox1.Items.RemoveAt(13);
        }

        private void textBoxNome_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNome.Text.Length > 5) return;

            if(textBoxNome.Text.Length < 5)
            {
                e.Cancel = true;
                MessageBox.Show("Digite um nome válido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionarPreco_Click(object sender, EventArgs e)
        {
                listBox1.Items.Insert(15, "------------------------------------------------------------");
                listBox1.Items.Insert(16, "Faixa de preço: R$ " + trackBarPreco.Value.ToString());
                btnEscolherNovamente.Enabled = false;
                btnLimpaPreco.Enabled = true;
                btnSelecionarPreco.Enabled = false;
                btnProcurar.Enabled = true;
        }

        private void btnLimpaPreco_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(15);
            listBox1.Items.RemoveAt(15);
            btnEscolherNovamente.Enabled = true;
            btnSelecionarPreco.Enabled = true;
            btnProcurar.Enabled = false;
        }

        private void maskedTextBoxRg_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBoxRg.Text.Length == 12) return;

            if (maskedTextBoxRg.Text.Length < 12)
            {
                e.Cancel = true;
                MessageBox.Show("Digite um RG válido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBoxCpf_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBoxCpf.Text.Length == 14) return;

            if (maskedTextBoxCpf.Text.Length < 14)
            {
                e.Cancel = true;
                MessageBox.Show("Digite um CPF válido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBoxPass_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBoxPass.Text.Length == 8) return;

            if (maskedTextBoxPass.Text.Length < 8)
            {
                e.Cancel = true;
                MessageBox.Show("Digite um Passaporte válido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nenhuma viagem encontrada com essas preferências!", "Deu ruim!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
