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

        /*
         * Método que devuelve un usuario por el username
         * Puede devolver null, pero para evitarlo 
         * está el método de comprobar si existe el nombre de usuario primero
         */
        public User FindUserByUsername(string username)
        {
            return connection.Table<User>().Where(u => u.Username.Equals(username)).First();
        }

        /*
         * Este método devuelve true o false dependiendo de si existe ese username en la base de datos
         * Este metodo se debe ejecutar antes que el anterior para no obtener un usuario null en caso de que no exista.
         */
        public Boolean UsernameExists(string username)
        {

            int result = connection.Table<User>().Where(u => u.Username.Equals(username)).Count();
            /*
             * true si es diferente de 0 (en la base de datos ya está ese username)
             * false si el count es 0 (no está ese nombre en la base de datos)
             */
            return result != 0;
        }

        /*
         * Este método devuelve true o false dependiendo de si el nombre de usuario y la contraseña
         * son iguales que a las del usuario que hay en la base de datos
         */
        public Boolean UsuarioCorrecto(string username, string password)
        {
            Boolean isValid = false;
            //Si no está disponible es que ya existe en la base de datos
            if(UsernameExists(username))
            {
                User user = FindUserByUsername(username);
                if (user != null)
                {
                    if (user.Username.Equals(username) && user.Passwd.Equals(password))
                    {
                        //solo es true si las credenciales son las mismas a las pasadas por parámetro
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}
