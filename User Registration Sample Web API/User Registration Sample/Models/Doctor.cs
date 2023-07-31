using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace User_Registration_Sample.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DoctorName { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string NIC { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
    }
}
