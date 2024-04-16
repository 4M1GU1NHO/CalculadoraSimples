using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraSimples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum Operacoes
        {
            Soma,
            Subtrai,
            Multiplica,
            Divide,
            Nenhuma
        }

        int qtdVirgula, qtdParenteses;
        
        static Operacoes ultimaOperacao = Operacoes.Nenhuma;
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Divide;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Multiplica;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Subtrai;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 0)
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1, 1);
            }
            else 
            {
                return;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Soma;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void FazerCalculo(Operacoes ultimaOperacao)
        {
            List<double> listaNumeros = new List<double>();
            
            switch (ultimaOperacao)
            {
                case Operacoes.Nenhuma:
                    break;
                case Operacoes.Soma:                   
                    listaNumeros = textBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaNumeros[0] + listaNumeros[1]).ToString();
                    break;
                case Operacoes.Subtrai:
                    listaNumeros = textBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaNumeros[0] - listaNumeros[1]).ToString();
                    break;
                case Operacoes.Divide:
                    try
                    {
                        listaNumeros = textBoxDisplay.Text.Split('÷').Select(double.Parse).ToList();
                        textBoxDisplay.Text = (listaNumeros[0] / listaNumeros[1]).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        textBoxDisplay.Text = "Não é possível dividir por 0";
                    }
                    break;
                case Operacoes.Multiplica:
                    listaNumeros = textBoxDisplay.Text.Split('x').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaNumeros[0] * listaNumeros[1]).ToString();
                    break;
                default: 
                    break;
            }
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += (sender as Button).Text;
        }
       
        private void buttonVirgula_Click(object sender, EventArgs e)
        {
            if (!textBoxDisplay.Text.Contains(","))
            {
                textBoxDisplay.Text = textBoxDisplay.Text + ",";
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDisplay.Text);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao != Operacoes.Nenhuma)
            {
                FazerCalculo(ultimaOperacao);
            }  
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void buttonParenthesis_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Contains("("))
            {
                textBoxDisplay.Text = textBoxDisplay.Text + ")";
            }
            else
            {
                textBoxDisplay.Text = textBoxDisplay.Text + "(";
            }
        }
    }
}
