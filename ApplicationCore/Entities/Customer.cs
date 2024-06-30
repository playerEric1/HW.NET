using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; }

    [Column(TypeName = "varchar(10)")] public string Gender { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Column(TypeName = "varchar(11)")]
    public string Phone { get; set; }

    public string City { get; set; }
}