using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public void DoWork()
        {
        }
        public SL.Result Add(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEFSP(usuario);
            return new SL.Result
            {
                Correct = result.Correct,
                Objects = result.Objects,
                Object = result.Object,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }
        public SL.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.DeleteEFSP(usuario);

            return new SL.Result
            {
                Correct = result.Correct,
                Objects = result.Objects,
                Object = result.Object,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };

        }
        public SL.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEFSP(usuario);
            return new SL.Result
            {
                Correct = result.Correct,
                Objects = result.Objects,
                Object = result.Object,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }
        public SL.Result GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEFSP(IdUsuario);
            return new SL.Result
            {
                Correct = result.Correct,
                Objects = result.Objects,
                Object = result.Object,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }
        public SL.Result Update(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEFSP(usuario);
            return new SL.Result
            {
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }
    }
}
