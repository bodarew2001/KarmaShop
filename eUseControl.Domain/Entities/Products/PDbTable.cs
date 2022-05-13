
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace eUseControl.Domain.Entities.Products
{
     public class PDbTable
     {
          //Id
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          //Name
          public string Name { get; set; }

          //Price
          public decimal Price { get; set; }

          public string ImagePath { get; set; }
     }
}
