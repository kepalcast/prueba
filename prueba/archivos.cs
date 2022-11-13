using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace prueba
{
    internal class archivos : Usuarios
    {
        public List<Usuarios> usuarios = new List<Usuarios>();
        private string DBFile;

        public void CargarDatos(string pfile)
        {
            this.DBFile = pfile;
            string[] lineas = File.ReadAllLines(pfile);
            foreach (string linea in lineas)
            {
                Usuarios user = JsonSerializer.Deserialize<Usuarios>(linea);
                this.usuarios.Add(user);
            }
        }

        public Usuarios BuscarUsuario(Usuarios pUser)
        {
            Usuarios vacio = new Usuarios();
            foreach (Usuarios user in this.usuarios)
            {
                if (user.cedula == pUser.cedula || user.Usuarioname == pUser.Usuarioname)
                {
                    return user;
                }
            }
            return vacio;
        }

        private void GuardarDatos()
        {
            using (StreamWriter fs = new StreamWriter(DBFile))
            {
                foreach (Usuarios user in this.usuarios)
                {
                    string line = JsonSerializer.Serialize<Usuarios>(user);
                    fs.WriteLine(line);
                }
                fs.Close();
            }
        }

        public bool AgregarUsuario(string pPass, string pUsername, string pDocucel, double pSaldo, double pPuntos)
        {
            Usuarios user = new Usuarios
            {
                contrasena = pPass,
                Usuarioname = pUsername,
                cedula = pDocucel,
                saldo = pSaldo,
                puntos = pPuntos
            };
            Usuarios buscar = this.BuscarUsuario(user);
            Console.WriteLine(buscar);
            if (buscar.Usuarioname == null || buscar.cedula == null)
            {
                this.usuarios.Add(user);
                this.GuardarDatos();
                Console.WriteLine("Usuarios creado exitosamente");
                Thread.Sleep(5000);
            }
            else
            {
                Console.WriteLine("El usuario existe!!");
                Thread.Sleep(5000);
                return false;
            }
            return true;
        }

        public Usuarios ValidarUsuario(string pPass, string pUsername)
        {
            Usuarios vacio = new Usuarios
            {
                contrasena = "",
                Usuarioname = "",
            };
            Usuarios user = new Usuarios
            {
                contrasena = pPass,
                Usuarioname = pUsername,
                saldo = this.saldo
            };
            if (this.BuscarUsuario(user).Usuarioname == pUsername && this.BuscarUsuario(user).contrasena == pPass)
            {
                return user;
            }
            return vacio;
        }

        public void ActualizarUsuario(Usuarios user)
        {
            this.usuarios.Remove(user);
            this.usuarios.Add(user);
            GuardarDatos();
        }
        public void EliminarUsuario()
        {

        }
    }
}
