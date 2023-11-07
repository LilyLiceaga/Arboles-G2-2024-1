using System.Drawing;
using System.Windows.Forms;
namespace Arboles
{

    public class Arbol
    {
        private nodo raiz = null;
        PictureBox ptb;
        Bitmap b;
        Graphics g;//para dibujar figuras geometricas
        Pen lapiz;//traza lineas
        int despX = 150;//grosor
        int despY = 50; //grosor
        int raizX;
        int raizY;

        public nodo Raiz
        {
            get
            {
                return raiz;
            }
        }

        public Arbol()
        {

        }

        public Arbol(PictureBox ptb)
        {
            this.ptb = ptb;
            lapiz = new Pen(Color.Purple, 5);
            b = new Bitmap(ptb.Width, ptb.Height);
            raizX = ptb.Width / 2;
            raizY = 20;

        }



        public void inserta_nodo(nodo A, nodo padre, int valor, int rama)
        {
            ptb.Image = (Image)b;
            g = Graphics.FromImage(b);
            if (A == null) //Creando nodo raiz si no existe
            {
                A = new nodo(); //creamos nodo raiz
                A.dato = valor;
                A.izq = null;
                A.der = null;
                if (raiz == null)
                {
                    raiz = A;
                    g.DrawString(A.dato.ToString(), new Font("Comic Sans", 15, FontStyle.Bold), new SolidBrush(Color.Black), raizX-14, raizY+6);
                    A.posx = raizX;
                    A.posy = raizY;
                    g.DrawEllipse(new Pen(Color.Black, 1), A.posx -15, A.posy+3, 30, 30);
                }
                else
                {
                    if (rama == 1)
                    {
                        A.posx = padre.posx - despX;
                        A.posy = padre.posy + despY;
                        padre.izq = A;
                        g.DrawString(A.dato.ToString(), new Font("Comic Sans", 15, FontStyle.Bold), new SolidBrush(Color.Black), A.posx-5, A.posy-1);
                        g.DrawEllipse(new Pen(Color.Black, 1), A.posx - 10, A.posy, 30, 30);
                        g.DrawLine(new Pen(Color.Black, 2), padre.posx, padre.posy, A.posx, A.posy);
                    }

                    else if (rama == 2)
                    {
                        A.posx = padre.posx + despX;
                        A.posy = padre.posy + despY;
                        padre.der = A;
                        g.DrawString(A.dato.ToString(), new Font("Comic Sans", 15, FontStyle.Bold), new SolidBrush(Color.Black), A.posx-20, A.posy);
                        g.DrawEllipse(new Pen(Color.Black, 1), A.posx-20, A.posy, 30, 30);
                        g.DrawLine(new Pen(Color.Black, 2), padre.posx+2, padre.posy+2, A.posx+2, A.posy+2);
                    }
                    if (despX >= 60)
                    {
                        despX -= 20;
                    }

                }

            }
            else //si nodo raiz existe (inicialmente)
            {
                if (valor < A.dato)
                {


                    inserta_nodo(A.izq, A, valor, 1);
                }
                else if (valor > A.dato)
                {

                    inserta_nodo(A.der, A, valor, 2);
                }
                else
                {
                    MessageBox.Show("Dato duplicado ");
                }
            }
        }

        public void preorden(nodo A)
        {
            if (A != null)
            {
                MessageBox.Show(A.dato.ToString(), "Mostrando ");
                preorden(A.izq);
                preorden(A.der);
            }
           
        }


        public void inorden(nodo A)
        {

            if (A != null)
            {

                inorden(A.izq);
                MessageBox.Show(A.dato.ToString(), "Mostrando Dato");
                inorden(A.der);

            }
        }
        public void posorden(nodo A)
        {

            if (A != null)
            {
                posorden(A.izq);
                posorden(A.der);
                MessageBox.Show(A.dato.ToString(), "Mostrando Dato");

            }
        }



    }

    public class nodo
    {
        public int dato;
        public nodo izq;//uns clase dentro de su misma clase (referencia)
        public nodo der;
        public int posx;//para el usuario
        public int posy;//para el usuario
    } 

}