using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemo.Data.Entities
{
	public class Customer : IEntity
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "You must provide a first name")]
		[Display(Name = "First Name")]
		[StringLength(50, ErrorMessage = "Name is too long!")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "You must provide a last name")]
		[Display(Name = "Last Name")]
		[StringLength(50, ErrorMessage = "Name is too long!")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "You must provide a valid phone number")]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Home Phone")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
		[StringLength(12, ErrorMessage = "You must provide a valid phone number")]
		public string HomePhone { get; set; }

		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Cell Phone")]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
		[StringLength(12, ErrorMessage = "You must provide a valid phone number")]
		public string CellPhone { get; set; }

		[Display(Name = "Address Line 1")]
		[StringLength(150, ErrorMessage = "Too long!")]
		public string AddressOne { get; set; }

		[Display(Name = "Address Line 2")]
		[StringLength(150, ErrorMessage = "Too long!")]
		public string AddressTwo { get; set; }

		[DataType(DataType.PostalCode)]
		[Display(Name = "Postal Code")]
		[StringLength(5, ErrorMessage = "Must be a valid 5 digit US postal code")]
		public string PostalCode { get; set; }
	}
}
