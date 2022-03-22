
using System;

namespace ATS.Domain.Models
{
    public class VeiculoDTO
    {

 
        public Proprietario Proprietarios { get; set; }

      
        public Marca Marca { get; set; }


        public string RENAVAM { get; set; }


        public string Modelo { get; set; }


        public string AnoFabricacao { get; set; }

        public int AnoModelo { get; set; }


        public string Quilometragem { get; set; }


        public decimal Valor { get; set; }

       public string Status { get; set; }
    }
}
