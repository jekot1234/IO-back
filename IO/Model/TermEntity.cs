namespace IO.Model
{
    using System;
    public class TermEntity
    {
        /// <summary>
        /// Term ID.
        /// </summary>
        public long TermID { get; set; }
        /// <summary>
        /// Time the booking starts.
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Time the booking ends.
        /// </summary>
        public DateTime To { get; set; }

        public string TableId { get; set; }
        /// <summary>
        /// If the term is expired.
        /// </summary>
        public bool IsExpired { get; set; }
    }
}