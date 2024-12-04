using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]// GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            usuario.ApellidoMaterno = "";
            usuario.Rol.IdRol = 0;
            //ML.Result result = new ML.Result();

            ServiceReferenceUsuario.UsuarioClient cliente = new ServiceReferenceUsuario.UsuarioClient();
            
            
            var result = cliente.GetAll(usuario);
            //ML.Result result = BL.Usuario.GetAllEFSP(usuario);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects.ToList(); ;
                ML.Result resultRol = BL.Rol.GetAllEFSP();
                if (resultRol.Correct)
                {
                    usuario.Rol.Rols = resultRol.Objects;
                }
                else
                {
                    ViewBag.MensajeError = "Hubo un error al obtener los roles: " + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Mensaje = "Hubo un error al obtener los usuarios: " + result.ErrorMessage;
            }
            return View(usuario);//Vista fuertemente tipeada
        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            usuario.Nombre = usuario.Nombre == null ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = usuario.ApellidoPaterno == null ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = usuario.ApellidoMaterno == null ? "" : usuario.ApellidoMaterno;

            ServiceReferenceUsuario.UsuarioClient cliente = new ServiceReferenceUsuario.UsuarioClient();
            var result = cliente.GetAll(usuario);
            //ML.Result result = BL.Usuario.GetAllEFSP(usuario);
            ML.Result resultRol = BL.Rol.GetAllEFSP();


            if (result.Correct)
            {
                usuario.Usuarios = result.Objects.ToList();
                if (resultRol.Correct)
                {
                    usuario.Rol.Rols = resultRol.Objects;
                }
                else
                {
                    ViewBag.Mensaje = "Error al obtener los roles" + resultRol.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Mensaje = "Error al obtener los usuarios" + result.ErrorMessage;
                return PartialView("Modal");
            }
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            if (IdUsuario == null)//Add
            {
                //ServiceReferenceUsuario.UsuarioClient client = new ServiceReferenceUsuario.UsuarioClient();
                //var result = client.Add(usuario); 
                ML.Usuario usuario = new ML.Usuario();
                usuario.Rol = new ML.Rol();
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                ML.Result resultRol = new ML.Result();
                ML.Result resultEst = new ML.Result();

                resultEst = BL.Estado.GetAllLinq();
                resultRol = BL.Rol.GetAllEFSP();
                if (resultRol.Correct)
                {
                    usuario.Rol.Rols = resultRol.Objects;
                    if (resultEst.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEst.Objects;
                    }
                }
                else
                {
                    ViewBag.MensajeError = "No hay roles por mostrar";
                    return PartialView("Modal");
                }

                return View(usuario);

            }
            else //Update
            {

                //ML.Result result = BL.Usuario.GetByIdEFSP(IdUsuario.Value);
                ServiceReferenceUsuario.UsuarioClient cliente = new ServiceReferenceUsuario.UsuarioClient();

                var result = cliente.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    ML.Usuario usuario = new ML.Usuario();
                    ML.Rol rol = new ML.Rol();
                    usuario.Rol = new ML.Rol();
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                    usuario = (ML.Usuario)result.Object;

                    ML.Result resultEstados = new ML.Result();
                    ML.Result resultMunicipios = new ML.Result();
                    ML.Result resultColonias = new ML.Result();

                    ML.Result resultRol = BL.Rol.GetAllEFSP();
                    resultEstados = BL.Estado.GetAllLinq();
                    resultMunicipios = BL.Municipio.GetMunicipiosByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    resultColonias = BL.Colonia.GetColoniasByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                    if (resultRol.Correct)
                    {
                        //rol = (ML.Rol) resultRol.Object;
                        usuario.Rol.Rols = resultRol.Objects;

                        if (resultEstados.Correct)
                        {
                            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                            usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                        }
                    }
                    else
                    {
                        ViewBag.MensajeError = "Error al acceder";
                        return PartialView("Modal");
                    }
                    return View(usuario);
                }
                else
                {
                    ViewBag.MensajeError = "Error: " + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //DateTime fechaNavegador = DateTime.ParseExact(usuario.FechaNacimiento.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                //usuario.FechaNacimiento = fechaNavegador.ToString("dd-MM-yyyy");
                HttpPostedFileBase imagen = Request.Files["ImagenUsuario"];
                if (imagen != null && imagen.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirAByte(imagen);
                }
                if (usuario.IdUsuario == 0)
                {
                    //ML.Result result = BL.Usuario.AddEFSP(usuario);
                    ServiceReferenceUsuario.UsuarioClient client = new ServiceReferenceUsuario.UsuarioClient();
                    var result = client.Add(usuario); 
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El usuario se registro de manera correcta";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo registrar el usuario: " + result.ErrorMessage;
                    }
                }
                else
                {
                    ServiceReferenceUsuario.UsuarioClient client = new ServiceReferenceUsuario.UsuarioClient();
                    var result = client.Update(usuario);
                    //ML.Result result = BL.Usuario.UpdateEFSP(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El usuario se actualizo correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar: " + result.ErrorMessage;
                    }
                }
            }
            else
            {
                ML.Result resultEstados = new ML.Result();
                ML.Result resultMunicipios = new ML.Result();
                ML.Result resultColonias = new ML.Result();

                ML.Result resultRol = BL.Rol.GetAllEFSP();
                resultEstados = BL.Estado.GetAllLinq();
                resultMunicipios = BL.Municipio.GetMunicipiosByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                resultColonias = BL.Colonia.GetColoniasByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                if (resultRol.Correct)
                {
                    //rol = (ML.Rol) resultRol.Object;
                    usuario.Rol.Rols = resultRol.Objects;

                    if (resultEstados.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                        usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                    }
                }
                else
                {
                    ViewBag.MensajeError = "Error al acceder";
                    return PartialView("Modal");
                }
                return View(usuario);

            }

            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult CargaMasivatxt()
        {
            HttpPostedFileBase txt = Request.Files["txtMasivo"];
            string linea = "";
            if (txt != null && txt.ContentLength > 0)
            {
                using (var reader = new StreamReader(txt.InputStream))
                {
                    ML.Result result = new ML.Result();
                    string err = "";
                    reader.ReadLine();
                    while ((linea = reader.ReadLine()) != null)
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

                        result = BL.Usuario.AddEFSP(usuario);

                        if (!result.Correct)
                        {
                            err += usuario.UserName + ", ";
                            continue;
                        }

                    }
                    ViewBag.Mensaje = "Hubo un error al insetar a los usuarios: " + err;
                }
            }
            else
            {
                ViewBag.Mensaje = "No se detecto ningún archivo";
                return PartialView("Modal");
            }

            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult CargaMasivaExcel()
        {
            if (Session["pathExcel"] == null)
            {
                HttpPostedFileBase excel = Request.Files["excelMasivo"];
                if (excel != null && excel.ContentLength > 0)
                {
                    string ExtrensionPermitida = ConfigurationManager.AppSettings["ExtensionExcel"];

                    string nombreArchivo = Path.GetExtension(excel.FileName);
                    if (nombreArchivo == ExtrensionPermitida)
                    {
                        string filePath = Server.MapPath("~/CargaMasiva/") + Path.GetFileNameWithoutExtension(excel.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx";
                        if (!System.IO.File.Exists(filePath))
                        {
                            excel.SaveAs(filePath);
                            string connectionString = ConfigurationManager.ConnectionStrings["OleDBConnection"] + filePath;
                            ML.Result leerExcel = BL.CargaMasiva.LeerExcel(connectionString);

                            if (leerExcel.Correct)
                            {
                                ML.Result resultValidar = BL.CargaMasiva.ValidarDatos(leerExcel.Objects);
                                if (resultValidar.Objects.Count > 0)
                                {
                                    ViewBag.Error = resultValidar.Objects;
                                    return PartialView("Modal");
                                }
                                else
                                {
                                    Session["pathExcel"] = filePath;
                                    ViewBag.Mensaje = "La validación fue exitosa, proceda a insertar";
                                    return PartialView("Modal");
                                }

                            }
                            else
                            {
                                ViewBag.Mensaje = "Hubo un problema al leer el archivo: " + leerExcel.ErrorMessage;
                                return PartialView("Modal");
                            }

                        }
                        else
                        {
                            ViewBag.Mensaje = "Ya existe un archivo con ese nombre";
                            return PartialView("Modal");
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "El archivo recibido no es un formato Excel";
                        return PartialView("Modal");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El archivo esta vacio o nulo";
                    return PartialView("Modal");
                }

            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + Session["pathExcel"].ToString();
                ML.Result leerExcel = BL.CargaMasiva.LeerExcel(connectionString);
                ML.Result erroresVista = new ML.Result();
                if (leerExcel.Correct)
                {
                    erroresVista.Objects = new List<Object>();
                    foreach (ML.Usuario usuario in leerExcel.Objects)
                    {
                        DateTime fechaNavegador = DateTime.ParseExact(usuario.FechaNacimiento.ToString(), "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        usuario.FechaNacimiento = fechaNavegador.ToString("dd-MM-yyyy");

                        ML.Result insert = BL.Usuario.AddEFSP(usuario);
                        if (!insert.Correct)
                        {
                            erroresVista.Objects.Add(insert);
                        }
                    }
                    if (erroresVista.Objects.Count > 0)
                    {
                        Session["pathExcel"] = null;
                        ViewBag.Error = erroresVista.Objects;
                        return PartialView("Modal");
                    }
                    else
                    {
                        Session["pathExcel"] = null;
                        ViewBag.Mensaje = "Se insertaron los registros de manera correcta";
                        return PartialView("Modal");
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(ML.Usuario usurio)
        {
            ServiceReferenceUsuario.UsuarioClient cliente = new ServiceReferenceUsuario.UsuarioClient();

            var resultCliente = cliente.Delete(usurio);
            //ML.Result result = BL.Usuario.DeleteEFSP(usurio);

            if (resultCliente.Correct)
            {
                ViewBag.MensajeError = "Se ha eliminado correctamente";
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.MensajeError = "Ha habido un error al eliminar: " + resultCliente.ErrorMessage;
                return PartialView("Modal");
            }
        }

        public JsonResult GetMunicipiosByIdEstado(int? IdEstado)
        {
            ML.Result result = new ML.Result();
            if (IdEstado != null)
            {
                //GetAll
                result = BL.Municipio.GetMunicipiosByIdEstado(IdEstado.Value);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColoniasByIdMunicipio(int? IdMunicipio)
        {
            ML.Result result = new ML.Result();

            result = BL.Colonia.GetColoniasByIdMunicipio(IdMunicipio.Value);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SwitchStatus(int IdUsuario, bool status)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.UpdateStatus(IdUsuario, status);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public byte[] ConvertirAByte(HttpPostedFileBase imagen)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(imagen.InputStream);
            byte[] data = reader.ReadBytes((int)imagen.ContentLength);
            return data;
        }


    }
}