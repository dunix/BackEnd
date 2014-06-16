using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;

namespace WCF
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet]
        Resultado UpdatePerfil(int Id_Usuario, string Telefono, string Ocupacion, string Email);


        [OperationContract]
        [WebGet]
        Resultado Suma();

        [OperationContract]
        [WebGet]
        Resultado Rutina(int a);

        [OperationContract]
        [WebGet]
        Resultado Perfil(int NUMERO_CLIENTE);

        [OperationContract]
        [WebGet]
        Resultado Login(String a, String b);

        [OperationContract]
        [WebGet]
        Resultado Horario(string valor);


        [OperationContract]
        [WebGet]
        Resultado GetPago(int Id_Usuario);

        [OperationContract]
        [WebGet]
        Resultado GetMedidas(int Id_Usuario);

        [OperationContract]
        [WebGet]
        Resultado GetNotificaciones(int Id_Usuario);

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
