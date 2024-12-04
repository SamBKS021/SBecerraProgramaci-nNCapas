using System;
using System.IO;

namespace PL
{
    internal class Usuario
    {

        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            Console.WriteLine("Ingrese su nombre de usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese su Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese su Contraseña");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese su Sexo");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese su Telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese su Celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese su Fecha de nacimiento (yyyy-mm-dd)");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese su CURP");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Ingrese su Rol");
            usuario.Rol.IdRol = Convert.ToByte(Console.ReadLine());


            ML.Result result = BL.Usuario.AddEFLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro insertado");

            }
            else
            {
                Console.WriteLine("Hubo un error: " + result.ErrorMessage);
            }
        }
        public static void Update()
        {

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            Console.WriteLine("Ingrese su ID");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese su nombre de usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese su Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese su Contraseña");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese su Sexo");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese su Telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese su Celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese su Fecha de nacimiento (dd-mm-yyyy)");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese su CURP");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Ingrese su Rol");
            usuario.Rol.IdRol = Convert.ToByte(Console.ReadLine());
            ML.Result result = BL.Usuario.UpdateEFLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro actualizado");

            }
            else
            {
                Console.WriteLine("Hubo un error: " + result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese ID del usuario a eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.DeleteEFLinq(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro eliminado");

            }
            else
            {
                Console.WriteLine("Hubo un error: " + result.ErrorMessage);
            }
        }
        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            Console.WriteLine("Ingrese el ID del usuario a buscar");
            usuario.IdUsuario = (int.Parse(Console.ReadLine()));
            Console.WriteLine("Trayendo datos...");
            ML.Result result = BL.Usuario.GetByIdEFLinq(usuario.IdUsuario);
            if (result.Correct)
            {
                Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("UserName: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Contraseña: " + usuario.Password);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("Fecha de Nacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("CURP: " + usuario.CURP);
                Console.WriteLine("IdRol: " + usuario.Rol.IdRol + "\n");

            }
            else
            {
                Console.WriteLine("Hubo un error: " + result.ErrorMessage);
            }

        }
        public static void GetAll()
        {

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAllEFLinq();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                    Console.WriteLine("UserName: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Contraseña: " + usuario.Password);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("Fecha de Nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("CURP: " + usuario.CURP);
                    Console.WriteLine("IdRol: " + usuario.Rol.IdRol + "\n");

                }
            }
            else
            {
                Console.WriteLine("Hubo un error: " + result.ErrorMessage);
            }
        }

        public static void CargaMasivaTxt()
        {
            string path = @"C:\Users\digis\Documents\Samuel Alejandro Becerra Alcántara\SBecerraProgramaciónNCapas\PL\Files\UsuarioInsertMasivo.txt";
            StreamReader streamReader = new StreamReader(path);
            string linea = "";
            streamReader.ReadLine();
            while ((linea = streamReader.ReadLine()) != null)
            {

                string[] array = linea.Split('|');
                ML.Usuario usuario = new ML.Usuario();
                usuario.UserName = array[0];
                usuario.Nombre = array[1];
                usuario.ApellidoPaterno = array[2];
                usuario.ApellidoMaterno = array[3];
                usuario.Email = array[4];
                usuario.Password = array[5];
                usuario.Sexo = array[6];
                usuario.Telefono = array[7];
                usuario.Celular = array[8];
                usuario.FechaNacimiento = array[9];
                usuario.CURP = array[10];

                usuario.Rol = new ML.Rol();
                usuario.Rol.IdRol = byte.Parse(array[11]);

                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Calle = array[12];
                usuario.Direccion.NumeroInterior = array[13];
                usuario.Direccion.NumeroExterior = array[14];

                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.IdColonia = byte.Parse(array[15]);

                BL.Usuario.AddEFSP(usuario);

            }

        }

    }
}
