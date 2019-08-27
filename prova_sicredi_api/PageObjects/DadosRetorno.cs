using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_sicredi_api.PageObjects
{

    public class DadosRetorno
    {
       
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }


    }
    public class listaCep
    {
        public List<DadosRetorno> ListaCep { get; set; }
    }
   
}
