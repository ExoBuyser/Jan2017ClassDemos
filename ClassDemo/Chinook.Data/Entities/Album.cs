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
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int Albumid { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(160, ErrorMessage = "Title exceeds maximun length of 160 characters")]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "Release year is required.")]
        public int ReleaseYear { get; set; }
        [StringLength(15, ErrorMessage = "Label exceeds maximun length of 15 characters")]
        public string ReleaseLabel { get; set; }


        public virtual Artist Artist { get; set; }
    }
}
