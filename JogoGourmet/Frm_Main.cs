using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class Frm_Main : Form
    {
        private List<Prato> _pratos;        

        public Frm_Main()
        {
            InitializeComponent();            
            InicializarPratos();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            FazerPerguntas(_pratos);
        }

        private void InicializarPratos()
        {
            _pratos = new List<Prato>();

            var pratoPrincipal = new Prato() { Nome = "Massa" };
            pratoPrincipal.Pratos.Add(new Prato() { Nome = "Lasanha" });
            _pratos.Add(pratoPrincipal);

            pratoPrincipal = new Prato() { Nome = "Bolo de Chocolate" };
            _pratos.Add(pratoPrincipal);
        }

        private void FazerPerguntas(List<Prato> pratos)
        {
            var pergunta = "O prato que voce pensou é";

            for (int i = 0; i < pratos.Count; i++)
            {
                var pratoAtual = pratos[i];

                var result = MessageBox.Show($"{pergunta} {pratoAtual.Nome} ?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (pratoAtual.Pratos.Count == 0)                    
                        MessageBox.Show("Acertei de Novo");                    
                    else                    
                        FazerPerguntas(pratoAtual.Pratos);

                    break;                    
                }
                else if ((i + 1) == pratos.Count)
                {
                    string nome = null;
                    if (Util.InputBox("Desisto", "Qual prato você pensou ?", ref nome) == DialogResult.Cancel)
                        nome = null;

                    string nomeAuxiliar = null;
                    if (Util.InputBox("Complete", $"{nome ?? "null"} é _______ mas {pratos[i].Nome} não.", ref nomeAuxiliar) == DialogResult.Cancel)
                        nomeAuxiliar = null;
                    
                    var novoPrato = new Prato() { Nome = nomeAuxiliar ?? "null" };
                    novoPrato.Pratos.Add(new Prato() { Nome = nome ?? "null" });

                    var temp = pratos[i];
                    pratos[i] = novoPrato;                        
                    pratos.Add(temp);

                    break;
                }                
            }
        }
    }
}
