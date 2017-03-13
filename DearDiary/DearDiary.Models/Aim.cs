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
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        // TODO: enum?
        [Required]
        public string Type { get; set; }

        public Guid AimCategoryId { get; set; }
        public virtual AimCategory AimCategory { get; set; }

        public string Description { get; set; }

        public Guid CityId { get; set; }
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
    }
}
