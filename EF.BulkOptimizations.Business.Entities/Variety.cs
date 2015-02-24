namespace EF.BulkOptimizations.Business.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Variety : IEntity
    {
        [Key]
        public int GeographicArea_Code { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}
