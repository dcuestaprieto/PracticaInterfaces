using CommunityToolkit.Mvvm.ComponentModel;
using PracticaInterfacesPrimerTrimestre.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.VistaModelo
{
    public partial class ValidadorInicio : ObservableValidator
    {
        public ObservableCollection<string> Errors { get; set; } = new ObservableCollection<string>();
        //TODO: en la clase App.cs crear el atributo publico y estático UserRepository y llamar al método de listarUsuarios
        public ObservableCollection<User> Users { get; set; }
        private string username;
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username 
        {
            get => username;
            set => SetProperty(ref username, value);

        }
    }
}
