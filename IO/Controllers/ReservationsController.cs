namespace IO.Controllers
{
    using IO.Model.Reservation;
    using IO.Services.ReservationServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("/reservation")]
    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        public ReservationsController(ReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [HttpGet]
        [Route("/reservation")]
        public List<Reservation> GetReservations()
        {
            return reservationService.GetReservations();
        }

        [HttpGet]
        [Route("/reservation/{tableId}/{timeStamp}")]
        public List<Reservation> GetReservationsByData(string tableId, string time)
        {
            return reservationService.GetReservations(tableId, time);
        }

        [HttpPost]
        [Route("/reservation")]
        public void AddReservation(Reservation reservation)
        {
            reservationService.AddReservation(reservation);
        }

        [HttpDelete]
        [Route("/reservation")]
        public IActionResult DeleteReservation(string reservationId)
        {
            return reservationService.DeleteReservation(reservationId);
        }
    }
}
