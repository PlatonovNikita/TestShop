using System;

namespace IXORA.PlatonovNikita.TestShop.Model.Entities
{
    /// <summary>
    /// Client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Full name of client.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Client phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
