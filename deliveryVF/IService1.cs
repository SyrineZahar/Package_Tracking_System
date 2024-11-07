using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace deliveryVF
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Package_delivery(int colisId, string entrepriseLivraison, string livreur, string status);

        [OperationContract]
        Delivery_Info GetDelivery_Info(int colisId);

    }


    [DataContract]
    public class Delivery_Info
    {
        [BsonId]
        public ObjectId id { get; set; }

        [DataMember]
        public int ColisId { get; set; }

        [DataMember]
        public string EntrepriseLivraison { get; set; }

        [DataMember]
        public string Livreur { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
