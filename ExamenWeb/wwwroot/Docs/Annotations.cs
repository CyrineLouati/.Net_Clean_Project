/*
 * [Key]
[DataType(DataType.ImageUr1), Display(Name = “Image")
[Display(Name = "Production Date")
[DataType(DataType.DateTine)]
[DataType(DataType.MultilineText)]
[Required(Errortessage = “Nane Required”)
[StringLength(25, ErrorMessage = "Must be less than 25 characters”)
[Maxtength(50)]
[MinLength(50)]
[DataType(DataType.Currency)]
[Range(8, int.Maxvalue)
[Foreignkey("Categoryld ")]
[Owned]
[NotMapped]
[Compare("Password")]
*/