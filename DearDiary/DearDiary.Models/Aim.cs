using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DearDiary.Models
{
    public class Aim
    {
        private ICollection<User> inUsersBucketList;
        private ICollection<User> inUsersDoneList;

        public Aim()
        {
            this.inUsersBucketList = new HashSet<User>();
            this.inUsersDoneList = new HashSet<User>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // TODO: enum or static class?
        [Required]
        public string Status { get; set; }

        public string OwnerUsername { get; set; }
            
        //[Required]
        public string Photo { get; set; }

        public int? AimCategoryId { get; set; }
        public virtual AimCategory AimCategory { get; set; }

        public string Description { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<User> InUsersBucketList
        {
            get { return this.inUsersBucketList; }
            set { this.inUsersBucketList = value; }
        }

        public virtual ICollection<User> InUsersDoneList
        {
            get { return this.inUsersDoneList; }
            set { this.inUsersDoneList = value; }
        }

        // TODO: Do I need a country in here?
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
