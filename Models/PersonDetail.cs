using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCRUDBackend.Models
{
    public class ContactList 
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2)")]
        public int ContactDdd { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public int ContactNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public int ContactPersonId { get; set; }
    }
    public class PersonDetail
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string PersonName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(11)")]
        public string PersonCpf { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string PersonBirthdate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string PersonEmail { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public int PersonContacts { get; set; }
    }
}
