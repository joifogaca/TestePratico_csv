using DataStreams.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestePratico_csv
{
    public class Importar
    {
        public static void ImportarDadosCsv(string caminho)
        {
            if (System.IO.File.Exists(caminho))
            {
                Entities context = new Entities();

                StreamReader stream = new StreamReader(caminho);

                string linha = null;
                string[] header = stream.ReadLine().Split(';');

                while ((linha = stream.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');
                    string guid = Guid.NewGuid().ToString();

                    for (int i = 0; i < dados.Length; i++)
                    {
                        Drenagem_superficial registro = new Drenagem_superficial();
                        registro.CodigoRegistro = guid;
                        registro.Atributo = header[i];
                        registro.Valor = dados[i];

                        context.Drenagem_superficial.Add(registro);


                    }
                    context.SaveChanges();


                }

                stream.Close();

            }
            }

            

       
    }
}
