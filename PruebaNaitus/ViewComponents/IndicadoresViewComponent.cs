using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prueba_Naitus.Models;
using System.Net;

namespace PruebaNaitus.ViewComponents
{
    public class IndicadoresViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Indicador objSerie;
            List<Indicador> lista = new List<Indicador>();
            string[] codigos = {"uf","dolar","euro","utm" };
            for (int i=0;i<4;i++)
            {
               
                string url = "http://www.mindicador.cl/api/" + codigos[i] +"/"+ DateTime.Now.ToString("dd-MM-yyyy");
                string res = "";

                try
                {
                    WebClient web = new WebClient();
                    Stream stream = web.OpenRead(url);
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        res = reader.ReadToEnd();
                    }

                    objSerie = JsonConvert.DeserializeObject<Indicador>(res);
                    lista.Add(objSerie);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }

           

            return View(lista);
        }
    }
}
