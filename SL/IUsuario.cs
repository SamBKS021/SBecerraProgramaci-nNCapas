using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        SL.Result Add(ML.Usuario usuario);
        [OperationContract]
        SL.Result Delete(ML.Usuario usuario);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL.Result GetAll(ML.Usuario usuario);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL.Result GetById(int IdUsuario);
        [OperationContract]
        SL.Result Update(ML.Usuario usuario);
    }
}
