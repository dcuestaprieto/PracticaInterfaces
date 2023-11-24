using PracticaInterfacesPrimerTrimestre.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre.Repositorios
{
    public class UsuarioRepositorio
    {
        private string route;
        private SQLiteConnection connection;

        public UsuarioRepositorio(string route)
        {
            this.route = route;
            connection = new SQLiteConnection(this.route);
            System.Diagnostics.Debug.WriteLine($"Ruta de Base de datos: {this.route}");
            if (!connection.TableMappings.Any(e => e.MappedType.Name == "usuarios"))
            {
                connection.CreateTable<User>();
            }
        }
        public void add(User user)
        {
            connection.Insert(user);
        }
        public ObservableCollection<User> showUsuarios()
        {
            List<User> userList = connection.Table<User>().ToList();
            ObservableCollection<User> shownUserList = new ObservableCollection<User> (userList);
            return shownUserList;
        }
    }
}
