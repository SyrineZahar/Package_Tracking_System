using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MongoDB.Driver;


namespace deliveryVF
{
    public class Service1 : IService1
    {
        private readonly IMongoCollection<Delivery_Info> _deliveryInfoCollection;

        public Service1()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Delivery_Info");
            _deliveryInfoCollection = database.GetCollection<Delivery_Info>("Delivery_Info");
        }

        public string Package_delivery(int colisId, string entrepriseLivraison, string livreur, string status)
        {
            if (string.IsNullOrWhiteSpace(entrepriseLivraison) ||
                string.IsNullOrWhiteSpace(livreur) ||
                string.IsNullOrWhiteSpace(status))
            {
                return "Erreur : Les informations sur l'entreprise de livraison, le livreur et le statut doivent être fournies.";
            }

            // Create a Delivery_Info object
            var colis = new Delivery_Info
            {
                ColisId = colisId,
                EntrepriseLivraison = entrepriseLivraison,
                Livreur = livreur,
                Status = status
            };

            try
            {
                // Check if a document with the same ColisId already exists
                var existingColis = _deliveryInfoCollection.Find(c => c.ColisId == colisId).FirstOrDefault();

                if (existingColis != null)
                {
                    // Update existing document
                    var updateDefinition = Builders<Delivery_Info>.Update
                        .Set(c => c.EntrepriseLivraison, entrepriseLivraison)
                        .Set(c => c.Livreur, livreur)
                        .Set(c => c.Status, status);

                    _deliveryInfoCollection.UpdateOne(c => c.ColisId == colisId, updateDefinition);
                }
                else
                {
                    // Insert new document
                    _deliveryInfoCollection.InsertOne(colis);
                }

                return "done";
            }
            catch (MongoException ex)
            {
                return "Erreur de base de données: " + ex.Message;
            }
        }

        public Delivery_Info GetDelivery_Info(int colisId)
        {
            try
            {
                // Find a document by ColisId
                var colis = _deliveryInfoCollection.Find(c => c.ColisId == colisId).FirstOrDefault();
                return colis;
            }
            catch (MongoException ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine("Erreur de base de données: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                Console.WriteLine("Erreur inattendue: " + ex.Message);
                return null;
            }
        }
    }
}