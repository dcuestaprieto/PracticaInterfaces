using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        private string password;
        [Required(ErrorMessage ="La contraseña es requerida")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "La contraseña debe estar compuesta de mayusculas, minusculas, números y caracteres especiales")]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        [RelayCommand]
        public async void Validar()
        {
            Errors.Clear();
            ValidateAllProperties();
            GetErrors(nameof(Username)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            if (Errors.Count == 0) {
                //Valido si el usuario existe para validarlo, pero si no existe añado un error de que no existe
                if (App.UsuarioRepositorio.UsernameExists(Username))
                {
                    if (App.UsuarioRepositorio.UsuarioCorrecto(Username, Password))
                    {
                        //System.Diagnostics.Debug.WriteLine("usuario correcto");
                        await AppShell.Current.GoToAsync(nameof(Vista.VistaUsuarios));
                    }
                    else
                    {
                        Errors.Add("Usuario o contraseña no validas");
                    }
                }
                else
                {
                    Errors.Add("El usuario no existe");
                }


            }
        }

        [RelayCommand]
        public async void ChangeToRegisterView()
        {
            await AppShell.Current.GoToAsync(nameof(Vista.VistaRegistro));
        }

    }
}
