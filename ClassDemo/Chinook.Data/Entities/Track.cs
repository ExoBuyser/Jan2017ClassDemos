using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Chinook.Data.Entities
{
    [Table("Tracks")]
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Name is a Required field.")]
        [StringLength(200, ErrorMessage="Name is limited to 200 characters")]
        public string Name { get; set; }


        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Composer is limited to 220 characters")]
        public string Composer { get; set; }

        [Required(ErrorMessage="Milliseconds is a required field")]
        [Range(1.0,double.MaxValue,ErrorMessage="Milliseconds value out of range; must be greater than 0")]
        public int Miliseconds { get; set; }

        public int? Bytes { get; set; }



        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }
        public virtual MediaType MediaType { get; set; }

        //public virtual Genre Genre {get;set;}
        //public virtual ICollection<PlaylistTrack> PlaylisTracks {get;set;}
        //public virtual ICollection<InvoiceLine> InvoiceLines{get;set;}
    }
}
