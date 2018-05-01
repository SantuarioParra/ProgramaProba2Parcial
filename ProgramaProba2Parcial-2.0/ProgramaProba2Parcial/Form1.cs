using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgramaProba2Parcial
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void Calcular_Click(object sender, EventArgs e)
        {
            Formulas form = new Formulas();
            graG.Series["g(x)"].Points.Clear();
            grH.Series["h(y)"].Points.Clear();
            int VElementos1 =0, VElementos2=0, VElementos3=0,  VCantidad=0;
            Int32 X = 0, Y = 0;
            double valor = 0.0;

            try {
                VElementos1 = Int32.Parse(Elementos1.Text);
                VElementos2 = Int32.Parse(Elementos2.Text);
                VElementos3 = Int32.Parse(Elementos3.Text);
                X = Int32.Parse(ValorX.Text);
                Y = Int32.Parse(ValorY.Text);
                VCantidad = Int32.Parse(Cantidad.Text);


                double[,] pConjuntas = new double[Y+1 , X+1 ];

                //tabla principal 

                pConjuntaT.RowCount = Y + 1;
                pConjuntaT.ColumnCount = X+1 ;
                pConjuntaT.BackgroundColor = Color.Black;
                
                for (int i = 0; i <=X ; i++)//calcular conjuntas
                {
                    for (int j = 0; j <= Y ; j++)
                    {
                        valor = form.calcularConjunta(i, j, VElementos1, VElementos2, VElementos3, VCantidad);
                        pConjuntas[j, i] = valor;
                        Console.WriteLine(valor);
                        
                    }
                }

                for (int i = 0; i <= Y ; i++)//cargar tabla
                {
                    for (int j = 0; j <=X ; j++)
                    {
                       
                        pConjuntaT.Rows[i].HeaderCell.Value = i.ToString();
                        pConjuntaT.Columns[j].Name = j.ToString();
                        
                    }
                }

                for (int i = 0; i <= X; i++)//cargar valores a la tabla
                {
                    for (int j = 0; j <= Y; j++)
                    {
                        pConjuntaT.Rows[j].Cells[i].Value = pConjuntas[j, i].ToString();

                    }
                }

                //fin tabla principal

                //tabla g(x)
                vGx.RowCount = X + 1;
                vGx.ColumnCount =1;
                vGx.BackgroundColor = Color.Black;

                vGx.Columns[0].Name = "g ( x )";
                
                    for (int j = 0; j <= X; j++)
                    {
                        vGx.Rows[j].HeaderCell.Value = j.ToString();

                    }
                double sumgx = 0;
                for (int j = 0; j <=X; j++)
                {
                    double suma = 0;
                    for (int i = 0; i <=Y ; i++)
                    {
                        suma += pConjuntas[i, j];
                    }
                    graG.Series["g(x)"].Points.AddXY(j.ToString(),suma);
                    sumgx = sumgx + suma;
                    vGx.Rows[j].Cells[0].Value = suma.ToString();
                }
                sumGx.Text = sumgx.ToString();
                //fin tabla g(x)

                //tabla h(y)
                vHy.RowCount = Y + 1;
                vHy.ColumnCount = 1;
                vHy.BackgroundColor = Color.Black;

                vHy.Columns[0].Name = "h ( y )";

                for (int j = 0; j <= Y; j++)
                {

                    vHy.Rows[j].HeaderCell.Value = j.ToString();

                }
                double sumhy = 0;
                for (int i = 0; i <= Y; i++)
                {
                    double suma = 0;
                    for (int j= 0; j <= X; j++)
                    {
                        suma += pConjuntas[i, j];
                    }
                    sumhy = sumhy+suma;
                    grH.Series["h(y)"].Points.AddXY(i.ToString(), suma);
                    vHy.Rows[i].Cells[0].Value = suma.ToString();
                }
                sumHy.Text = sumhy.ToString();
                //fin tabla h(y)



            }
            catch ( Exception error) {
                Console.WriteLine("Los valores introducidos no son validos.");
                MessageBox.Show("Los valores introducidos no son validos.", "ERROR",
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                Console.WriteLine(error.StackTrace);
            }
            

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa funciona para problemas como los manejados en el libro \" RONALD E. WALPOLE, RAYMOND H. MYERS,SHARON L.MYERS Y KEYING YE, Probabilidad y estadística para ingeniería y cienciasNovena edición \" en los problemas: 3.39 y 3.14 ", "Información",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
