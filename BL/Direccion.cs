using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result AddEFSP()
        {
            ML.Result result = new ML.Result();
            try
            {

            }catch (Exception e) {
            result.ErrorMessage = e.Message;
                result.Ex = e;
                result.Correct = false;
            }
            return result;
        }
    }
}
