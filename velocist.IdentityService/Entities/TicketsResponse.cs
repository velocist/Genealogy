using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace velocist.IdentityService.Entities {
    public class TicketsResponse {

        [Key]
        public int Id { get; set; }


        [ForeignKey("TicketRequest")]
        public int TicketId { get; set; }

        public string Summary { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}
