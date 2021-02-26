namespace IO.Services.ReservationServices
{
    using IO.Model.DataBaseSettings;
    using IO.Model.Reservation;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservations;
        public ReservationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reservations = database.GetCollection<Reservation>(settings.ReservationsCollectionName);
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public List<Reservation> GetReservations()
        {
            return _reservations.Find(_ => true).ToList();
        }
        public List<Reservation> GetReservations(string tableId, long time)
        {
            long endTime = time + 86400000;

           return _reservations.Find(res => res.From >= time && res.From <= endTime && res.TableID == tableId).ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            _reservations.InsertOne(reservation);
        }

        public IActionResult DeleteReservation(string reservationId)
        {
            try
            {
                if (!_reservations.DeleteOne(r => r.ReservationID == reservationId).IsAcknowledged)
                {
                    return new BadRequestResult();
                }
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }

        }

    }
}
