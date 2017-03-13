using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DearDiary.Models
{
    public class City
    {
        // TODO: does it have to be only here or in the country model as well
        private ICollection<Aim> aims;
        public City()
        {
            this.aims = new HashSet<Aim>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Aim> Aims
        {
            get { return this.aims; }
            set { this.aims = value; }
        }

        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}