using Arboles;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arboles_G2_2024_1
{
    public partial class Form1 : Form
    {
        private Arbol arbol;
        public Form1()
        {
            InitializeComponent();
            arbol = new Arbol(ptbArbol); 
        }

        private void txtbNodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                int dato = int.Parse(txtbNodo.Text);
                arbol.inserta_nodo(arbol.Raiz, null,dato, 0); //(nodo raiz, nodo padre, valor, # rama)
                txtbNodo.Clear();
            }
            if (e.KeyChar == (char)Keys.P)
            {
                arbol.preorden(arbol.Raiz); //extraemos datos
            }
            if (e.KeyChar == (char)Keys.I)
            {
                arbol.inorden(arbol.Raiz); 
            }
            if (e.KeyChar == (char)Keys.S)
            {
                arbol.posorden(arbol.Raiz); 
            }
        }
    }
}
