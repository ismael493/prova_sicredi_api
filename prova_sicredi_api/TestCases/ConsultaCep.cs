using System;
using NUnit.Framework;
using RestSharp;
using prova_sicredi_api.PageObjects;
using RestSharp.Serialization.Json;
using System.IO;
using prova_sicredi_api.Utils;
using FrameworkCsharp.Utils;

namespace prova_sicredi_api
{
    [TestFixture]       
    public class ConsultaCep
    {
        DadosRetorno DadosRetorno = new DadosRetorno();
        private PropertiesUtils log;

        [Test]
        public void ValidaCep()
        {

            try
            {
                string cep = "91450080";

                string logName = "logConsulta" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_FFF");
                Directory.CreateDirectory(ProjConfig.GetPath("\\TestResults\\") + logName + "\\");
                File.Create((ProjConfig.GetPath("\\TestResults\\") + logName + "\\" + logName + ".txt")).Close();
                log = new PropertiesUtils(ProjConfig.GetPath("\\TestResults\\") + logName + "\\" + logName + ".txt");
                log.Save();
                int i = 1;

                if (cep.Length == 8)
                {
                    
                    RestClient restClient = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/ ", cep));
                    RestRequest restRequest = new RestRequest(Method.GET);
                    IRestResponse restResponse = restClient.Execute(restRequest);

                    if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        Console.WriteLine("Erro na requisição da API" + restResponse.Content);
                    else
                    {
                        DadosRetorno dadosRetorno = new JsonDeserializer().Deserialize<DadosRetorno>(restResponse);

                        if (dadosRetorno.cep is null)
                        {
                            Console.WriteLine("Cep não encontado na base de dados");
                            log.Set("Cep não encontado na base de dados: " + ToString(), dadosRetorno.Equals(null));
                            log.Save();
                            return;
                        }
                        log.Set("CEP: " + i.ToString(),dadosRetorno.cep);                        
                        log.Set("Logradouro: " + i.ToString(),dadosRetorno.logradouro);                        
                        log.Set("Complemento: " + i.ToString(),dadosRetorno.complemento);                     
                        log.Set("Bairro: " + i.ToString(),dadosRetorno.bairro);
                        log.Set("Localidade: " + i.ToString(),dadosRetorno.localidade);
                        log.Set("UF: " + i.ToString(),dadosRetorno.uf);
                        log.Set("Unidade: " + i.ToString(), dadosRetorno.unidade);
                        log.Set("IBGE: " + i.ToString(),dadosRetorno.ibge);
                        log.Set("GIA: " + i.ToString(),dadosRetorno.gia);
                        log.Save();

                    }

                }
                else
                {
                    Console.WriteLine("Cep inválido verifique o formato informado!");
                    log.Set("Cep inválido verifique o formato informado! " + ToString() , cep.GetType());
                    log.Save();
                    return;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro.Message);
            }
        }
    }
}
