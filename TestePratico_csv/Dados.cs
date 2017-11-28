using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico_csv
{
    public class Dados
    {
        private static Entities context = new Entities();

        private static List<Drenagem_superficial> dadosTabela;



        public static DataTable FormataDados()
        {
            dadosTabela = context.Drenagem_superficial.ToList();

            DataTable dt = new DataTable();

            var registroAtributos = dadosTabela.GroupBy(d => d.Atributo).Select(g => g.First()).ToList();

            dt.Columns.Add("CodigoRegistro", typeof(string));

            foreach (var registro in registroAtributos)
            {
                dt.Columns.Add(registro.Atributo, typeof(string));
            }

            var registrosCodigos = dadosTabela.GroupBy(d => d.CodigoRegistro).Select(g => g.First()).ToList();

            foreach (var registro in registrosCodigos)
            {
                DataRow dr = dt.NewRow();

                dr["CodigoRegistro"] = registro.CodigoRegistro;

                var registrosPorCod = dadosTabela.Where(d => d.CodigoRegistro == registro.CodigoRegistro).ToList();

                foreach (var registroPorCod in registrosPorCod)
                {
                    dr[registroPorCod.Atributo] = registroPorCod.Valor;
                }

                dt.Rows.Add(dr);

            }

           

            return dt;
        }

        public static List<string> CarregarCidades()
        {
            List<string> municipios = new List<string>();

            dadosTabela = context.Drenagem_superficial.ToList();

            var registrosMunicipio = dadosTabela.Where(d => d.Atributo == "Municipio").ToList();

            var registrosDistinctMunicipio = registrosMunicipio.GroupBy(d => d.Valor).Select(g => g.First()).ToList();

            foreach (var regCidade in registrosDistinctMunicipio)
            {
                municipios.Add(regCidade.Valor);
            }

            return municipios;
        }

        public static List<string> CarregarSentido()
        {

            List<string> sentidos = new List<string>();

            dadosTabela = context.Drenagem_superficial.ToList();

            var registrosSentido = dadosTabela.Where(d => d.Atributo == "sentido").ToList();

            var registrosDistinctSentido = registrosSentido.GroupBy(d => d.Valor).Select(g => g.First()).ToList();

            foreach (var regCidade in registrosDistinctSentido)
            {
                sentidos.Add(regCidade.Valor);
            }

            return sentidos;
        }

        public static void Filtrar(string minicipio, string cidade)
        { 
            
        }
    }
}
