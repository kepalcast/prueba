using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    internal class Usuarios
    {
        public string Usuarioname { get; set; }
        public string contrasena { get; set; }
        public string cedula { get; set; }
        public double saldo { get; set; }
        public double puntos { get; set; }

        public double AgregarDinero(double pConsignar)
        {
            this.saldo = this.saldo + pConsignar;
            this.puntos = this.saldo / 1000;
            return this.saldo;
        }

        public bool RetirarDinero(double pSaldo, double pRetiros)
        {
            int saldo = Convert.ToInt32(pSaldo);
            int retirar = Convert.ToInt32(pRetiros);
            if (retirar <= saldo)
            {
                Console.WriteLine("El saldo disponible es" + Convert.ToString(saldo - retirar));
                this.saldo = this.saldo - retirar;
            }

            return true;
        }
        public bool CanjearPuntos(double pPuntos, double pCanje)
        {
            if (pCanje <= pPuntos)
            {
                this.puntos = pPuntos - pCanje;
                this.saldo = this.saldo + (this.puntos * 1000);
                Console.WriteLine("El saldo disponible de puntos es" + this.puntos);
                return true;
            }
            return false;
        }
    }
}


