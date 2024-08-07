using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTE_GUNA.projeto.window
{
    public partial class TelaMessageBox : Form
    {
        public TelaMessageBox()
        {
            InitializeComponent();
        }

        #region FUNCOES

        public bool btnSimClick = false;
        public bool btnNaoClick = false;

        //PRINTA SOMENTE UMA MENSAGEM SEM OS BUTONS
        public void Mensagem(string mensagem)
        {
            btnNao.Visible = false;
            btnSim.Visible = false;
            txtMensagem.Size = new System.Drawing.Size(336, 166);
            txtMensagem.Text = mensagem;
        }


        public string RetornaSimNao(string pergunta)
        {
            //printa a pergunta
            txtMensagem.Text = pergunta;


            if (btnSimClick == true)
            {
                //caso o button sim tenha sido clicado
                return "sim";
            }
            else if (btnNaoClick == true)
            {
                //caso o button nao tenha sido clicado
                return "nao";
            }
            else
            {
                //caso nem o button sim nem o nao tenha sido clicado
                return "";
            }

        }

        #endregion


        private void TelaMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void btnSim_Click_1(object sender, EventArgs e)
        {
            //se o button foi clicado
            btnSimClick = true;
            this.Close();
        }

        private void btnX_Click_1(object sender, EventArgs e)
        {
            //button fechar a tela de pagamento
            this.Close();
            FecharTodasInstancias();
        }

        public static List<TelaMessageBox> _instanciasAbertas = new List<TelaMessageBox>();

        public static void AdicionarInstancia(TelaMessageBox instancia)
        {
            _instanciasAbertas.Add(instancia);
        }

        public static void FecharTodasInstancias()
        {
            foreach (var instancia in _instanciasAbertas.ToList())
            {
                instancia.Close();
            }
            _instanciasAbertas.Clear();
        }

        private void btnNao_Click_1(object sender, EventArgs e)
        {
            //se o button foi clicado
            btnNaoClick = true;
            this.Close();
            FecharTodasInstancias();
        }
    }
}