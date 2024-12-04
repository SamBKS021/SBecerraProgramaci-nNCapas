using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAllLinq()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = (from estadoLinq in context.Estadoes
                                 select estadoLinq).ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DL_EF.Estado estado in query)
                        {

                            ML.Estado estadoItem = new ML.Estado();
                            estadoItem.IdEstado = estado.IdEstado;
                            estadoItem.Nombre = estado.Nombre;
                            result.Objects.Add(estadoItem);
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
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
