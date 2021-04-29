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
	public class EmplSkills
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RelationID { set; get; }
		//[ForeignKey("Employees")]
		public int EmplID { set; get; }
		//[ForeignKey("Skills")]
		public int SkillID { set; get; }

	}
}
