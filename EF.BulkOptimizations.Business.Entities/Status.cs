namespace EF.BulkOptimizations.Business.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Status : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Range(1900, 2100)]
        public int? Year { get; set; }

        [Required, StringLength(20)]
        public string Code { get; set; }

        [StringLength(256)]
        public string ApplicationCode { get; set; }

        [StringLength(256)]
        public string Network { get; set; }

        [StringLength(256)]
        public string Comment { get; set; }
    }
}
