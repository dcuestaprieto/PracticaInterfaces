﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class ValidadorRegistro : ObservableValidator
    {
        public ObservableCollection<string> Errors { get; set; } = new ObservableCollection<string>();
        //TODO: en la clase App.cs crear el atributo publico y estático UserRepository y llamar al método de listarUsuarios
        public ObservableCollection<User> Users { get; set; }

        private string name;
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string username;
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        [Required(ErrorMessage = "La contraseña es requerida")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "La contraseña debe estar compuesta de mayusculas, minusculas, números y caracteres especiales")]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private string passwordRepeat;
        [Required(ErrorMessage = "Debes repetir la contraseña")]
        public string PasswordRepeat
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private string age;
        [Required(ErrorMessage = "La edad es requerida")]
        [RegularExpression(@"^\d{2}$",ErrorMessage ="La edad no es válida")]
        public string Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        [RelayCommand]
        public async void Validar()
        {
            Errors.Clear();
            ValidateAllProperties();
            GetErrors(nameof(Name)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(Username)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(PasswordRepeat)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));
            GetErrors(nameof(Age)).ToList().ForEach(error => Errors.Add(error.ErrorMessage));

            if (Errors.Count == 0)
            {
                if (!App.UsuarioRepositorio.UsernameExists(Username))
                {
                    App.UsuarioRepositorio.Add(new User { Name = this.Name, Username = this.Username, Passwd = this.Password, Age = int.Parse(this.Age) });
                    await AppShell.Current.GoToAsync(nameof(Vista.VistaUsuarios));
                }
                else
                {
                    Errors.Add("El usuario ya existe");
                }
            }

        }
        [RelayCommand]
        public async void ChangeToSignInView()
        {
            await AppShell.Current.GoToAsync(nameof(Vista.VistaInicio));
        }

    }
}
