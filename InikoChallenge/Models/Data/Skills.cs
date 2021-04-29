using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InikoChallenge.Models.Data
{
	public class Skills
	{
		private string description;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ID { set; get; }
		public string Name { set; get; }
		public string? Description { get => description; set => description = value; }

		public ICollection<Employees> Employees;
	}
}
