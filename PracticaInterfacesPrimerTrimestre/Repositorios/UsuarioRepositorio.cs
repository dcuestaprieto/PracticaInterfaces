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
        private readonly string route;
        private readonly SQLiteConnection connection;
        private const string tableName = "usuarios";

        public UsuarioRepositorio(string route)
        {
            this.route = route;

            //Creamos la conexión con la ruta pasada por argumento
            connection = new SQLiteConnection(this.route);

            //Mostramos la ruta de la base de datos
            System.Diagnostics.Debug.WriteLine($"\nRuta de Base de datos: {this.route}\n");

            /* Comprobamos si existe alguna tabla en la base de datos
             * con el nombre de la tabla que esta clase representa*/
            if (!connection.TableMappings.Any(e => e.MappedType.Name == tableName))
            {
                connection.CreateTable<User>();
            }
        }

        public void Add(User user)
        {
            connection.Insert(user);
        }
        public ObservableCollection<User> showUsuarios()
        {
            List<User> userList = connection.Table<User>().ToList();
            return new ObservableCollection<User> (userList);
        }

        public User FindUser(int id)
        {
            return connection.Find<User>(id);
        }

        public Boolean IsUsernameAvailable(string name)
        {
            //int conteo = connection.Table<User>().Where(u => u.Name.Equals(userName)).ToList().Count;
            //System.Diagnostics.Debug.WriteLine(conteo);
            //System.Diagnostics.Debug.WriteLine(connection.Table<User>().Any(user => user.Name.Equals(userName)));
            //return connection.Table<User>().Any(user => user.Name.Equals(userName));
            
            //
            /*
             * si el count es 0 es que sí está disponible (true)
             * si el count es diferente de 0 es que ya hay algún registro con ese nombre (false)
             */
            return connection.Table<User>().Where(u => u.Name.Equals(name)).Count() == 0;
        }
        public Boolean InicioValido(string username, string password)
        {
            Boolean isValid = true;
            if(IsUsernameAvailable(username))
            {
                var usuariosFiltrados = connection.Table<User>()
                               .Where(u => u.Name.Equals(username) && u.Passwd.Equals(password))
                               .ToList();
            }
            else
            {
                isValid = false;
            }


            return isValid;
        }
    }
}
