using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace InikoChallenge.Models.Data
{

	/// <summary>
	/// 
	/// </summary>
	public class Employees
	{
		private string personalDetails;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ID { set; get; }
		public string Name { set; get; }
		public string Surname { set; get; }
		public string? PersonalDetails { get => personalDetails; set => personalDetails = value; }
		//[ForeignKey]
		//public ICollection<Skills> Skills;
		public string Skills;

	}
}
