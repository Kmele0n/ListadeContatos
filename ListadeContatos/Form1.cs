using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ListadeContatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Contato[] contatos = new Contato[1];

        private void Escrever(Contato contato)
        {
            StreamWriter escreverEmArquivo = new StreamWriter("Contatos.txt");
            escreverEmArquivo.WriteLine(contatos.Length + 1);
            escreverEmArquivo.WriteLine(contato.Nome);
            escreverEmArquivo.WriteLine(contato.Sobrenome);
            escreverEmArquivo.WriteLine(contato.Telefone);

            for (int x = 0; x < contatos.Length; x++)
            {
                escreverEmArquivo.WriteLine(contatos[x].Nome);
                escreverEmArquivo.WriteLine(contatos[x].Sobrenome);
                escreverEmArquivo.WriteLine(contatos[x].Telefone);

            }
            escreverEmArquivo.Close();
        }

        private void Ler()


        {
            StreamReader lerArquivo = new StreamReader("Contatos.txt");
            contatos = new Contato[Convert.ToInt32(lerArquivo.ReadLine())];

            for (int x = 0; x < contatos.Length; x++)
            {
                contatos[x] = new Contato();
                contatos[x].Nome = lerArquivo.ReadLine();
                contatos[x].Sobrenome = lerArquivo.ReadLine();
                contatos[x].Telefone = lerArquivo.ReadLine();
            }

            lerArquivo.Close ();
        }

        private void Exibir()
        {
            listBoxContatos.Items.Clear();
            for (int x = 0; x < contatos.Length; x++)
            {
                listBoxContatos.Items.Add(contatos[x].ToString());
            }
        }
       
        private void LimparFormulario()
        {
            textBoxNome.Text = String.Empty;
            textBoxSobrenome.Text = String.Empty;
            textBoxTelefone.Text = String.Empty;
        }

     
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ButtonA_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            contato.Nome = textBoxNome.Text;
            contato.Sobrenome = textBoxSobrenome.Text;
            contato.Telefone = textBoxTelefone.Text;

           listBoxContatos.Items.Add(contato.ToString());
        }

        private void Buttonadicionar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato();
            contato.Nome = textBoxNome.Text;
            contato.Sobrenome = textBoxSobrenome.Text;
            contato.Telefone = textBoxTelefone.Text;

            //listBoxContatos.Items.Add(contato.ToString());

            Escrever(contato);
            Ler();
            Exibir();
            LimparFormulario();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Ler();
            Exibir();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Ler();
            Exibir();

        }
    }
}
