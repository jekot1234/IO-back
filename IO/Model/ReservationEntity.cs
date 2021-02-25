namespace IO.Model
{
    using System;
    public class ReservationEntity
    {
       /// <summary>
       /// Reservation ID.
       /// </summary>
        public long ReservationID { get; set; }
        /// <summary>
        /// Reserved table ID.
        /// </summary>
        public long TableID { get; set; }
        /// <summary>
        /// If the term is expired.
        /// </summary>
        public bool IsExpired { get; set; }
        /// <summary>
        /// Time the booking starts.
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Time the booking ends.
        /// </summary>
        public DateTime To { get; set; }
    }
}
