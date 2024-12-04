using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

//Using importa librerias
namespace BL
{
    public class Usuario
    {
        /*
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Crear objetos que se destruyen al finalizar el bloque using
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("EXEC SPInsertUsuario @Nombre = @Nombre, @Apellido=@Apellido,@Edad=@Edad,@NumTel=@NumTel,@Nacionalidad=@Nacionalidad", con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.ApellidoPaterno);
                    command.Parameters.AddWithValue("@Edad", usuario.Edad);
                    command.Parameters.AddWithValue("@NumTel", usuario.Telefono);
                    command.Parameters.AddWithValue("@Nacionalidad", usuario.Nacionalidad);

                    con.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Verifica los datos, no se inserto";
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("EXEC SPUpdateUsuario @Nombre = @Nombre, @Apellido=@Apellido,@Edad=@Edad,@NumTel=@NumTel,@Nacionalidad=@Nacionalidad ,@Id=@Id", con);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.ApellidoPaterno);
                    command.Parameters.AddWithValue("@Edad", usuario.Edad);
                    command.Parameters.AddWithValue("@NumTel", usuario.Telefono);
                    command.Parameters.AddWithValue("@Nacionalidad", usuario.Nacionalidad);
                    command.Parameters.AddWithValue("@Id", usuario.IdUsuario);

                    con.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Verifica los datos, no se actualizo";
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("EXEC SPDeleteUsuario @Id=@Id", con);
                    command.Parameters.AddWithValue("@Id", usuario.IdUsuario);
                    con.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Verifica los datos, no se elimino";
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {

                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result GetById(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("EXEC SPGetUsuario @Id= @Id;", con);
                    command.Parameters.AddWithValue("@Id", usuario.IdUsuario);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    //Console.WriteLine($"Nombre: {reader["Nombre"]}");
                    Console.WriteLine($"ID: {reader["Id"]}\nNombre: {reader["Nombre"]}\nApellido: {reader["Apellido"]}\nEdad: {reader["Edad"]}\nNumero Telefonico: {reader["NumTel"]}\nNacionalidad: {reader["Nacionalidad"]}");
                    if (reader.HasRows)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existe esa ID";
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("EXEC SPGetUsuario;", con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}\nNombre: {reader["Nombre"]}\nApellido: {reader["Apellido"]}\nEdad: {reader["Edad"]}\nNumero Telefonico: {reader["NumTel"]}\nNacionalidad: {reader["Nacionalidad"]}\n");
                    }
                    if (reader.HasRows)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        */
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Crear objetos que se destruyen al finalizar el bloque using
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("UsuarioAddSP", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", usuario.UserName);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Password", usuario.Password);
                    command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@Celular", usuario.Celular);
                    command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    command.Parameters.AddWithValue("@CURP", usuario.CURP);
                    command.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);

                    con.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Verifica los datos, no se inserto";
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    SqlCommand command = new SqlCommand("UsuarioUpdateSP", con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@UserName", usuario.UserName);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Password", usuario.Password);
                    command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@Celular", usuario.Celular);
                    command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    command.Parameters.AddWithValue("@CURP", usuario.CURP);
                    command.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);

                    con.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Verifica los datos, no se actualizo";
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;

        }
        public static ML.Result Delete(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    usuario.Rol = new ML.Rol();
                    SqlCommand command = new SqlCommand("UsuarioDeleteSP", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    con.Open();
                    int filasAfectadas = command.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Verifica los datos, no se elimino";
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {

                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result GetById(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    usuario.Rol = new ML.Rol();
                    SqlCommand command = new SqlCommand("UsuarioGetByIdSP", con);
                    command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    DataTable tablaUsuario = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(tablaUsuario);
                    if (tablaUsuario.Rows.Count > 0)
                    {
                        DataRow registro = tablaUsuario.Rows[0];

                        usuario.IdUsuario = Convert.ToInt32(registro[0].ToString());
                        usuario.UserName = registro[1].ToString();
                        usuario.Nombre = registro[2].ToString();
                        usuario.ApellidoPaterno = registro[3].ToString();
                        usuario.ApellidoMaterno = registro[4].ToString();
                        usuario.Email = registro[5].ToString();
                        usuario.Password = registro[6].ToString();
                        usuario.Sexo = registro[7].ToString();
                        usuario.Telefono = registro[8].ToString();
                        usuario.Celular = registro[9].ToString();
                        usuario.FechaNacimiento = registro[10].ToString();
                        usuario.CURP = registro[11].ToString();
                        usuario.Rol.IdRol = Convert.ToByte(registro[12].ToString());



                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existe esa ID";
                    }

                    con.Close();
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection con = new SqlConnection(DL.Conexion.GetConnection()))
                {

                    SqlCommand command = new SqlCommand("UsuarioGetAllSP", con);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tablaUsuario = new DataTable();
                    adapter.Fill(tablaUsuario);

                    if (tablaUsuario.Rows.Count > 0)
                    {

                        result.Objects = new List<object>();
                        foreach (DataRow registro in tablaUsuario.Rows)
                        {

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = Convert.ToInt32(registro[0].ToString());
                            usuario.UserName = registro[1].ToString();
                            usuario.Nombre = registro[2].ToString();
                            usuario.ApellidoPaterno = registro[3].ToString();
                            usuario.ApellidoMaterno = registro[4].ToString();
                            usuario.Email = registro[5].ToString();
                            usuario.Password = registro[6].ToString();
                            usuario.Sexo = registro[7].ToString();
                            usuario.Telefono = registro[8].ToString();
                            usuario.Celular = registro[9].ToString();
                            usuario.FechaNacimiento = registro[10].ToString();
                            usuario.CURP = registro[11].ToString();
                            usuario.Rol.IdRol = Convert.ToByte(registro[12].ToString());

                            result.Objects.Add(usuario);

                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existe esa ID";
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }
        public static ML.Result AddEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new DL_EF.SBecerraProgramacionNCapasEntities())
                {
                    int filasAfectadas = context.UsuarioAddSP(
                        usuario.UserName,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Email,
                        usuario.Password,
                        usuario.Sexo,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.FechaNacimiento.ToString(),
                        usuario.CURP,
                        usuario.Rol.IdRol,
                        usuario.Imagen,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia
                    );

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result UpdateEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    int filasAfectadas = context.UsuarioUpdateSP(
                        usuario.IdUsuario,
                        usuario.UserName,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Email,
                        usuario.Password,
                        usuario.Sexo,
                        usuario.Telefono,
                        usuario.Celular,
                        Convert.ToString(usuario.FechaNacimiento),
                        usuario.CURP,
                        usuario.Rol.IdRol,
                        usuario.Imagen,
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.Colonia.IdColonia);

                    if (filasAfectadas > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }


            return result;
        }

        public static ML.Result UpdateStatus(int IdUsuario, bool status)
        {
            Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = context.UpdateStatusUsuario(
                        IdUsuario,
                        status
                        );
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }


                }

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Ex = e;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result DeleteEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new DL_EF.SBecerraProgramacionNCapasEntities())
                {
                    int filasAfectadas = context.UsuarioDeleteSP(usuario.IdUsuario);
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }


            return result;
        }
        public static ML.Result GetByIdEFSP(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new DL_EF.SBecerraProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetByIdSP(idUsuario).SingleOrDefault();
                    ML.Usuario usuario = new ML.Usuario();

                    if (query != null)
                    {
                        result.Object = new object();

                        usuario.Rol = new ML.Rol();
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.NombreUsuario;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        if (query.FechaNacimiento == null)
                        {
                            usuario.FechaNacimiento = DateTime.Today.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("yyyy-MM-dd");
                        }
                        usuario.CURP = query.CURP;
                        usuario.Rol.IdRol = Convert.ToByte(query.IdRol);
                        usuario.Imagen = query.Imagen;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;
                        usuario.Direccion.Colonia.IdColonia = Convert.ToByte(query.IdColonia);
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = Convert.ToByte(query.IdMunicipio);
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = Convert.ToByte(query.IdEstado);
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                    result.Object = usuario;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }


            return result;
        }

        public static ML.Result GetAllEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            using (DL_EF.SBecerraProgramacionNCapasEntities context = new DL_EF.SBecerraProgramacionNCapasEntities())
            {
                var query = context.UsuarioGetAllSPView(
                    usuario.Nombre,
                    usuario.ApellidoPaterno,
                    usuario.ApellidoMaterno,
                    usuario.Rol.IdRol
                    ).ToList();
                if (query.Count > 0)
                {
                    result.Objects = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Usuario usuario1 = new ML.Usuario();
                        usuario1.Rol = new ML.Rol();
                        usuario1.Direccion = new ML.Direccion();
                        usuario1.Direccion.Colonia = new ML.Colonia();
                        usuario1.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario1.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                        usuario1.IdUsuario = item.IdUsuario;
                        usuario1.UserName = item.UserName;
                        usuario1.Nombre = item.NombreUsuario;
                        usuario1.ApellidoPaterno = item.ApellidoPaterno;
                        usuario1.ApellidoMaterno = item.ApellidoMaterno;
                        usuario1.Email = item.Email;
                        usuario1.Password = item.Password;
                        usuario1.Sexo = item.Sexo;
                        usuario1.Telefono = item.Telefono;
                        usuario1.Celular = item.Celular;
                        usuario1.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        usuario1.CURP = item.CURP;
                        usuario1.Rol.Nombre = item.NombreRol;
                        usuario1.Imagen = item.Imagen;
                        usuario1.Status = item.Status;
                        usuario1.Direccion.Calle = item.Calle;
                        usuario1.Direccion.NumeroInterior = item.NumeroInterior;
                        usuario1.Direccion.NumeroExterior = item.NumeroExterior;
                        usuario1.Direccion.Colonia.Nombre = item.NombreColonia;
                        usuario1.Direccion.Colonia.CodigoPostal = item.CodigoPostal;
                        usuario1.Direccion.Colonia.Municipio.Nombre = item.NombreMunicipio;
                        usuario1.Direccion.Colonia.Municipio.Estado.Nombre = item.NombreEstado;


                        result.Objects.Add(usuario1);
                        result.Correct = true;
                    }
                }

            }

            return result;
        }

        public static ML.Result AddEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new DL_EF.SBecerraProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioEF = new DL_EF.Usuario();

                    usuarioEF.IdUsuario = usuario.IdUsuario;
                    usuarioEF.UserName = usuario.UserName;
                    usuarioEF.Nombre = usuario.Nombre;
                    usuarioEF.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioEF.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioEF.Email = usuario.Email;
                    usuarioEF.Password = usuario.Password;
                    usuarioEF.Sexo = usuario.Sexo;
                    usuarioEF.Telefono = usuario.Telefono;
                    usuarioEF.Celular = usuario.Celular;
                    usuarioEF.FechaNacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
                    usuarioEF.CURP = usuario.CURP;
                    usuarioEF.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioEF);
                    int filasAfectadas = context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }

            return result;
        }
        public static ML.Result UpdateEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var resultSelect = (from usuarioLinq in context.Usuarios
                                        where usuarioLinq.IdUsuario == usuario.IdUsuario
                                        select usuarioLinq
                                       ).SingleOrDefault();

                    if (resultSelect != null)
                    {
                        resultSelect.UserName = usuario.UserName;
                        resultSelect.Nombre = usuario.Nombre;
                        resultSelect.ApellidoPaterno = usuario.ApellidoPaterno;
                        resultSelect.ApellidoMaterno = usuario.ApellidoMaterno;
                        resultSelect.Email = usuario.Email;
                        resultSelect.Password = usuario.Password;
                        resultSelect.Sexo = usuario.Sexo;
                        resultSelect.Telefono = usuario.Telefono;
                        resultSelect.Celular = usuario.Celular;
                        resultSelect.FechaNacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
                        resultSelect.CURP = usuario.CURP;
                        resultSelect.IdRol = usuario.Rol.IdRol;

                        int filasAfectadas = context.SaveChanges();
                        if (filasAfectadas > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = (from usuarioLinq in context.Usuarios
                                 where usuarioLinq.IdUsuario == usuario.IdUsuario
                                 select usuarioLinq
                                       ).SingleOrDefault();
                    context.Usuarios.Remove(query);
                    int filasAfectadas = context.SaveChanges();
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result GetByIdEFLinq(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Rol = new ML.Rol();
                    var query = (from usuarioLinq in context.Usuarios
                                 where usuarioLinq.IdUsuario == IdUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioLinq.IdUsuario,
                                     UserName = usuarioLinq.UserName,
                                     Nombre = usuarioLinq.Nombre,
                                     ApellidoPaterno = usuarioLinq.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLinq.ApellidoMaterno,
                                     Email = usuarioLinq.Email,
                                     Password = usuarioLinq.Password,
                                     Sexo = usuarioLinq.Sexo,
                                     Telefono = usuarioLinq.Telefono,
                                     Celular = usuarioLinq.Celular,
                                     FechaNacimiento = usuarioLinq.FechaNacimiento,
                                     CURP = usuarioLinq.CURP,
                                     IdRol = usuarioLinq.IdRol,
                                 }).SingleOrDefault();
                    if (query != null)
                    {

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.FechaNacimiento = Convert.ToString(query.FechaNacimiento);
                        usuario.CURP = query.CURP;
                        usuario.Rol.IdRol = Convert.ToByte(query.IdRol);


                        result.Correct = true;
                        result.Object = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.SBecerraProgramacionNCapasEntities context = new DL_EF.SBecerraProgramacionNCapasEntities())
                {
                    var query = (from usuarioLinq in context.Usuarios
                                 select usuarioLinq).ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<Object>();
                        foreach (DL_EF.Usuario usuario in query)
                        {

                            ML.Usuario usuarioItem = new ML.Usuario();
                            usuarioItem.Rol = new ML.Rol();
                            usuarioItem.IdUsuario = usuario.IdUsuario;
                            usuarioItem.UserName = usuario.UserName;
                            usuarioItem.Nombre = usuario.Nombre;
                            usuarioItem.ApellidoPaterno = usuario.ApellidoPaterno;
                            usuarioItem.ApellidoMaterno = usuario.ApellidoMaterno;
                            usuarioItem.Email = usuario.Email;
                            usuarioItem.Password = usuario.Password;
                            usuarioItem.Sexo = usuario.Sexo;
                            usuarioItem.Telefono = usuario.Telefono;
                            usuarioItem.Celular = usuario.Celular;
                            usuarioItem.FechaNacimiento = usuario.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            usuarioItem.CURP = usuario.CURP;
                            usuarioItem.Rol.IdRol = Convert.ToByte(usuario.Rol.IdRol);

                            result.Objects.Add(usuarioItem);

                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {

                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
    }


}
