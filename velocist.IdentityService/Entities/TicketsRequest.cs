using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace velocist.IdentityService.Entities {
    public class TicketsRequest {

        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Type { get; set; }

        [Required]
        [MaxLength(15)]
        public string Status { get; set; }

        [Required]
        [MaxLength(15)]
        public string Priority { get; set; }

        [Required]
        public string Summary { get; set; }

        public DateTime DateSubmitted { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<TicketsResponse> TicketsResponse { get; set; }

    }
}
