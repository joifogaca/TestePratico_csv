using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePratico_csv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDados.DataSource = Dados.FormataDados();

            List<string> cidades = Dados.CarregarCidades();

            foreach (var cidade in cidades)
            {
                cmbMunicipio.Items.Add(cidade);
            }

            List<string> sentidos = Dados.CarregarSentido();

            foreach (var sentido in sentidos)
            {
                cmbSentido.Items.Add(sentido);
            }

            //Importar.ImportarDadosCsv();
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            string filtroCidade = cmbMunicipio.Text;

            string filtroSentido = cmbSentido.Text;

            if ((filtroCidade != null) && (filtroSentido != null))
            {
                string rowFilter = string.Format("[{0}] = '{1}'", "Municipio", filtroCidade);
                rowFilter += string.Format(" AND [{0}] = '{1}'", "sentido", filtroSentido);
                (dgvDados.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

            }
            else
            {

                if (filtroCidade != null)
                {
                    string rowFilter = string.Format("[{0}] = '{1}'", "Municipio", filtroCidade);
                    (dgvDados.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                }

                if (filtroSentido != null)
                {
                    string rowFilter = string.Format("[{0}] = '{1}'", "sentido", filtroSentido);
                    (dgvDados.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

                }

            }

        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            if (caminhoArq.Text != null)
            {
                Importar.ImportarDadosCsv(caminhoArq.Text);
            }
        }
    }
}
