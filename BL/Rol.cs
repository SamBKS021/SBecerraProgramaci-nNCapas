using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {

        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = (from rolLinq in context.Rols
                                 select rolLinq).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (DL_EF.Rol rol in query)
                        {
                            ML.Rol rolItem = new ML.Rol();
                            rolItem.IdRol = Convert.ToByte(rol.IdRol);
                            rolItem.Nombre = rol.Nombre;
                            result.Objects.Add(rolItem);
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

        public static ML.Result GetByIdEFLinq(int IdRol)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    ML.Rol rol = new ML.Rol();
                    var query = (from rolLinq in context.Rols
                                 where rolLinq.IdRol == IdRol
                                 select new
                                 {
                                     Idrol = rolLinq.IdRol,
                                     Nombre = rolLinq.Nombre,
                                 }).SingleOrDefault();
                    if (query != null)
                    {

                        result.Objects = new List<object>();
                        rol.IdRol = Convert.ToByte(query.Idrol);
                        rol.Nombre = query.Nombre;
                        result.Correct = true;
                        result.Objects.Add(rol);

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

        public static ML.Result GetAllEFSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = context.RolGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)

                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = Convert.ToByte(item.IdRol);
                            rol.Nombre = item.Nombre;

                            result.Objects.Add(rol);
                            result.Correct = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.ErrorMessage= ex.Message;
                result.Ex= ex;
            }
            return result;
        }
    }
}
