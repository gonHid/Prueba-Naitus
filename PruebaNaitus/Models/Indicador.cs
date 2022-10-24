using System;


namespace Prueba_Naitus.Models
{

    using System;
    using Newtonsoft.Json;
    

    public partial class Indicador
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("autor")]
        public string Autor { get; set; }

        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("unidad_medida")]
        public string UnidadMedida { get; set; }

        [JsonProperty("serie")]
        public Serie[] Serie { get; set; }
    }

    public partial class Serie
    {
        [JsonProperty("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }
    }

}
