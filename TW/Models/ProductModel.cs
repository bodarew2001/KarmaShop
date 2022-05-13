﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TW.Models
{
     public class ProductModel
     {
          //Id
          public int Id { get; set; }

          //Name
          [
              Display(Name = "Nume"),
              Required(ErrorMessage = "Acest câmp este obligatoriu."),
              MinLength(4, ErrorMessage = "Lungimea minimă 4 caractere."),
              MaxLength(20, ErrorMessage = "Lungimea maximă 20 caractere.")
          ]
          public string Name { get; set; }

          //Price
          [
              Display(Name = "Pret"),
              Required(ErrorMessage = "Acest câmp este obligatoriu."),
              DataType(DataType.Currency)
          ]
          public decimal Price { get; set; }

          //Image
          [
              Display(Name = "Incarcati imagine"),
              Required(ErrorMessage = "Acest câmp este obligatoriu."),
              DataType(DataType.Upload)
          ]
          public HttpPostedFileBase Image { get; set; }

          public string ImagePath { get; set; }
     }
}