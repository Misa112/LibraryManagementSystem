// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models
{
    public partial class Loan
    {
        public Loan()
        {
            Copies = new HashSet<Copy>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTo { get; set; }
        public double Fee { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Loans")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Copy.Loan))]
        public virtual ICollection<Copy> Copies { get; set; }
    }
}