using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DearDiary.Models
{
    public class Country
    {
        private ICollection<City> cities;
        private ICollection<Aim> aims;

        public Country()
        {
            this.cities = new HashSet<City>();
            this.aims = new HashSet<Aim>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public virtual ICollection<Aim> Aims
        {
            get { return this.aims; }
            set { this.aims = value; }
        }
    }
}