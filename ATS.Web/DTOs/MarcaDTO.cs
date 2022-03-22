using System.ComponentModel.DataAnnotations;

namespace ATS.Web.DTOs
{
    public class MarcaDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Status{ get; set; }
    }
}