using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetColoniasByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SBecerraProgramacionNCapasEntities context = new SBecerraProgramacionNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(IdMunicipio);
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var colonia in query)
                        {

                            ML.Colonia coloniaItem = new ML.Colonia();
                            coloniaItem.Municipio= new ML.Municipio();
                            coloniaItem.IdColonia = colonia.IdColonia;
                            coloniaItem.Nombre = colonia.Nombre;
                            coloniaItem.CodigoPostal = colonia.CodigoPostal;
                            coloniaItem.Municipio.IdMunicipio = colonia.IdMunicipio.Value;

                            result.Objects.Add(coloniaItem);
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
