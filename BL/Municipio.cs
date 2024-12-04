using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetMunicipiosByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = context.MunicipioGetByIdEstado(IdEstado);
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var municipio in query)
                        {
                        ML.Municipio municipioItem = new ML.Municipio();
                            municipioItem.Estado = new ML.Estado();
                            municipioItem.IdMunicipio = municipio.IdMunicipio;
                            municipioItem.Nombre = municipio.Nombre;
                            municipioItem.Estado.IdEstado = municipio.IdEstado.Value;
                            result.Objects.Add(municipio);
                        }
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
                result.Correct = false;
                result.Ex = e;
            }
            return result;
        }
        
    }
}
