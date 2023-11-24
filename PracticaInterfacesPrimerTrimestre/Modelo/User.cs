using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.Modelo
{
    [Table("usuarios")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }
        public string Age { get; set; }
    }
}