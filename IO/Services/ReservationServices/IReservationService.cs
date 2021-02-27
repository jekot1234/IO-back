namespace IO.Services.ReservationServices
{
    using IO.Model.Reservation;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    interface IReservationService
    {
        void AddReservation(Reservation reservation);
        IActionResult DeleteReservation(string reservationId);
        List<Reservation> GetReservations();
        List<Reservation> GetReservations(string tableId, long time);
        List<Reservation> GetReservations(string userId);
    }
}
