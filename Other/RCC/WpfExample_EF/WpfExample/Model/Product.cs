namespace WpfExample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Модель сущности "Товар"
    /// </summary>
    //[Table("Products")]
    public partial class Product
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автоинкремент
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
      
        public int StatusId { get; set; }

        private DateTime? _dateOfChange = null;
        public DateTime DateOfChange
        {
            get
            {
                if (this._dateOfChange.HasValue)
                    return this._dateOfChange.Value; 
                else
                   return DateTime.Now;
            }

            set
            {
                this._dateOfChange = value;
            }
        }
    }
}