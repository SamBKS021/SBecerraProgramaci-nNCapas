using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CargaMasiva
    {
        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tableUsuario = new DataTable();

                        da.Fill(tableUsuario);
                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow item in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.UserName = item[0].ToString();
                                usuario.Nombre = item[1].ToString();
                                usuario.ApellidoPaterno = item[2].ToString();
                                usuario.ApellidoMaterno = item[3].ToString();
                                usuario.Email = item[4].ToString();
                                usuario.Password = item[5].ToString();
                                usuario.Sexo = item[6].ToString();
                                usuario.Telefono = item[7].ToString();
                                usuario.Celular = item[8].ToString();
                                usuario.FechaNacimiento = item[9].ToString();
                                usuario.CURP = item[10].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = Convert.ToByte(item[11]);

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = item[12].ToString();
                                usuario.Direccion.NumeroInterior = item[13].ToString();
                                usuario.Direccion.NumeroExterior = item[14].ToString();

                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = Convert.ToByte(item[15]);

                                result.Objects.Add(usuario);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.ErrorMessage = "No encontró información";
                            result.Correct = false;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Correct = false;
                result.Ex = e;

            }

            return result;
        }

        public static ML.Result ValidarDatos(List<object> usuarios)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            int contadorRegistros = 1;

            foreach (ML.Usuario itemUsuario in usuarios)
            {
                ML.ErrorExcel errorExcel = new ML.ErrorExcel();
                errorExcel.NumeroRegistro = contadorRegistros;
                if (string.IsNullOrEmpty(itemUsuario.UserName) || itemUsuario.UserName.Length>50)
                {
                    errorExcel.Error += "El UserName de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 50 caracteres.\n";
               
                }
                if (string.IsNullOrEmpty(itemUsuario.Nombre) || itemUsuario.Nombre.Length > 50)
                {
                    errorExcel.Error += "El nombre de " + itemUsuario.UserName + " es null/vacio o sobrepasa 50 caracteres.\n";
                    
                }
                if (string.IsNullOrEmpty(itemUsuario.ApellidoPaterno) || itemUsuario.ApellidoPaterno.Length > 50)
                {
                    errorExcel.Error += "El Apellido Paterno de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 50 caracteres.\n";
                    
                }
                if(itemUsuario.ApellidoMaterno.Length > 50)
                {
                    errorExcel.Error += "El Apellido Materno de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 50 caracteres.\n";
                }
                if (string.IsNullOrEmpty(itemUsuario.Email) || itemUsuario.Email.Length > 254)
                {
                    errorExcel.Error += "El Email de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 50 caracteres.\n";
                 
                }
                if (string.IsNullOrEmpty(itemUsuario.Password) || itemUsuario.Password.Length > 50)
                {
                    errorExcel.Error += "La contraseña de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 50 caracteres.\n";
                    
                }
                if (string.IsNullOrEmpty(itemUsuario.Sexo) || itemUsuario.Sexo.Length > 2)
                {
                    errorExcel.Error += "El sexo de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 2 caracteres.\n";
                    
                }
                if (string.IsNullOrEmpty(itemUsuario.Telefono) || itemUsuario.Telefono.Length > 20)
                {
                    errorExcel.Error += "El telefono  de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 20 caracteres.\n";
                  
                }
                if (string.IsNullOrEmpty(itemUsuario.Celular) || itemUsuario.Celular.Length > 20)
                {
                    errorExcel.Error += "El celular de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 20 caracteres.\n";
                   
                }
                if(itemUsuario.CURP.Length > 50)
                {
                    errorExcel.Error += "El CURP de " + itemUsuario.Nombre + " es mayor a 50 caracteres";
                }
                if (itemUsuario.Rol.IdRol <= 0 )
                {
                    errorExcel.Error += "El rol de " + itemUsuario.Nombre + " es null/vacio o negativo.\n";
                   
                }
                if (string.IsNullOrEmpty(itemUsuario.Direccion.Calle) ||itemUsuario.Direccion.Calle.Length>50)
                {
                    errorExcel.Error += "La calle de " + itemUsuario.Nombre + " es null/vacio o sobrepasa 50 caracteres.\n";
                    
                }
                if (itemUsuario.Direccion.NumeroInterior.Length > 20)
                {
                    errorExcel.Error += "El número interior de " + itemUsuario.Nombre + " es mayor a 20 caracteres";
                }
                if (itemUsuario.Direccion.NumeroExterior.Length > 20 || string.IsNullOrEmpty(itemUsuario.Direccion.NumeroExterior))
                {
                    errorExcel.Error += "El número Exterior de " + itemUsuario.Nombre + " es nulo/vacio o mayor a 20 caracteres";
                }
                if (itemUsuario.Direccion.Colonia.IdColonia <= 0)
                {
                    errorExcel.Error += "La colonia de " + itemUsuario.Nombre + " es null o vacio.\n";
                }         
                
                if (!string.IsNullOrEmpty(errorExcel.Error))
                {
                    result.Objects.Add(errorExcel);
                }
                contadorRegistros++;
            }

            return result;

        }
    }
}
