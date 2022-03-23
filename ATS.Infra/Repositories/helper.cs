namespace ATS.Infra.Repositories
{
    public static class helper
    {
       public const string url = "https://brasilapi.com.br/api/cep/v1/";
 
        public static ATS.Domain.Models.CEP ReturnGetCEPRequest( string param)
        {
            ATS.Domain.Models.CEP? retorno = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                //HTTP GET
                var responseTask = client.GetAsync(param);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ATS.Domain.Models.CEP>();
                    readTask.Wait();
                    retorno = readTask.Result;
                    return retorno;
                }
                else
                {
                    retorno = null;
                }

            }
            return null;
        }

 
    }
}
