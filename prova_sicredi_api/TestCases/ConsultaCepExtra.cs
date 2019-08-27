using System;
using NUnit.Framework;
using RestSharp;
using prova_sicredi_api.PageObjects;
using FrameworkCsharp.Utils;
using System.Collections.Generic;

namespace prova_sicredi_api
{
    [TestFixture]       
    public class ConsultaCepExtra
    {
        DadosRetorno DadosRetorno = new DadosRetorno();

        [Test]
        public void ValidaCepExtra()
        {

            try
            {

                    
                    RestClient restClient = new RestClient(string.Format("https://viacep.com.br/ws/RS/Gravatai/Barroso/json/"));
                    RestRequest restRequest = new RestRequest(Method.GET);
                    IRestResponse restResponse = restClient.Execute(restRequest);
                   
                    if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        Console.WriteLine("Erro na requisição da API" + restResponse.Content);
                    else
                    {
                        var response = restClient.Execute<List<DadosRetorno>>(restRequest);

                        foreach (DadosRetorno item in response.Data)
                        {
                            Console.WriteLine("CEP: " + item.cep);
                            Console.WriteLine("Logradouro " + item.logradouro);
                            Console.WriteLine("Complemento " + item.complemento);
                            Console.WriteLine("Bairro: " + item.bairro);
                            Console.WriteLine("Localidade: " + item.localidade);
                            Console.WriteLine("UF: " + item.uf);
                            Console.WriteLine("Unidade: " + item.unidade);
                            Console.WriteLine("IBGE: " + item.ibge);
                            Console.WriteLine("GIA: " + item.gia);
                           
                        }



                    }

            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro" + erro.Message);
            }
        }
    }
}
