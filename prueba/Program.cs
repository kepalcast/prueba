using prueba;

int opcion = 0;

Usuarios usuarios = new Usuarios();
archivos arch = new archivos();
arch.CargarDatos("OUTPUTS/users.txt");
while(opcion != 4)
{
    Console.Clear();
    Console.WriteLine("Bienvenido a tu banco de confianza..");
    Console.WriteLine("1. Crear Usuario");
    Console.WriteLine("2. Iniciar sesión");
    Console.WriteLine("4. Salir");
    Console.WriteLine("Eliga una de las opciones");
    opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingresar un usuario");
            string usuarioLog = Console.ReadLine();
            Console.WriteLine("Ingresar su cédula");
            string cedulaLog = Console.ReadLine();
            Console.WriteLine("Ingresar una contraseña");
            string contrasenaLog1 = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña nuevamente");
            string contrasenaLog2 = Console.ReadLine();
            Console.WriteLine("Ingrese su dinero por favor");
            double saldo = Convert.ToDouble(Console.ReadLine());
            double puntos = saldo / 1000;
            if (contrasenaLog1 == contrasenaLog2)
            {
                arch.AgregarUsuario(contrasenaLog2.Encriptar(), usuarioLog, cedulaLog, saldo, puntos);
                Console.WriteLine("Cuenta creada correctamente");
                Thread.Sleep(5000);
            }
            break;

        case 2:
            Console.WriteLine("Ingrese su usuario");
            string usuarioLog1 = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña");
            string contrasenaLog = Console.ReadLine();
            usuarios.Usuarioname = usuarioLog1;
            usuarios.contrasena = contrasenaLog.Encriptar();
            usuarios = arch.BuscarUsuario(usuarios);
            if (usuarios.contrasena == contrasenaLog.Encriptar() && usuarios.Usuarioname == usuarioLog1)
            {
                Console.WriteLine("Hola"+usuarioLog1+"Ingreso exitoso!");
                Thread.Sleep(5000);

                int OpcionCuenta = 0;
                while (OpcionCuenta != 6)
                {
                    Console.WriteLine("Elige una opción");
                    Console.WriteLine("1. Consultar mi saldo");
                    Console.WriteLine("2. Consultar puntos");
                    Console.WriteLine("3. Canjear puntos");
                    Console.WriteLine("4. Retirar dinero");
                    Console.WriteLine("5. Consignar dinero");
                    Console.WriteLine("6. Cerrar");
                    OpcionCuenta = Convert.ToInt32(Console.ReadLine());
                    switch (OpcionCuenta)
                    {
                        case 1:
                            Console.WriteLine("Su saldo es:");
                            Console.WriteLine(usuarios.saldo);
                            Thread.Sleep(5000);
                            break;
                        case 2:
                            Console.WriteLine("Sus puntos son: ");
                            Console.WriteLine(usuarios.puntos);
                            Thread.Sleep(5000);
                            break;
                        case 3:
                            Console.WriteLine("Cuantos puntos desea canjear");
                            double canjeo = Convert.ToDouble(Console.ReadLine());
                            if(usuarios.CanjearPuntos(usuarios.puntos, canjeo))
                            {
                                arch.ActualizarUsuario(usuarios);
                            }
                            Thread.Sleep(5000);
                            break;
                        case 4:
                            Console.WriteLine("Cuanto desea retirar");
                            double retirar = Convert.ToDouble(Console.ReadLine());
                            if(usuarios.RetirarDinero(usuarios.saldo, retirar))
                            {
                                arch.ActualizarUsuario(usuarios);
                                Thread.Sleep(5000);
                            }
                            else 
                            {
                                Console.WriteLine("Saldo insuficiente");
                                Thread.Sleep(5000);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Cuanto desea cosignar");
                            double consignar = Convert.ToDouble(Console.ReadLine());
                            usuarios.AgregarDinero(consignar);
                            arch.ActualizarUsuario(usuarios);
                            break;
                        case 6:
                            Console.WriteLine("Cerrando la sesión....");
                            Thread.Sleep(500);
                            break;
                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                            }
                    }

            }
            else
            {
                Console.WriteLine("Usuario no existe");
                Thread.Sleep(5000);
            }
            break;
        case 3:
            Console.WriteLine("Saliendo de la sucursal...");
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
            }

    }
