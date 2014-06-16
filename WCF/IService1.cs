using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet]
        Resultado Suma();

        [OperationContract]
        [WebGet]
        Resultado Login(String a, String b);

        [OperationContract]
        [WebGet]
        Resultado Horario(string valor);
    }
    [DataContract]
    public class Resultado
    {
        [DataMember]
        public List<ArrayList> Result { get; set; }

        public List<ArrayList> getResult()
        { 
            return Result;
        }
        public void setResult( List<ArrayList> New_Result) {
            Result = New_Result;
        }
    }
}
