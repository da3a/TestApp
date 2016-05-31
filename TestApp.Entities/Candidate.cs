using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core;

namespace TestApp.Entities
{

    public enum Gender
    {
        Female,
        Male
    }

    public class Candidate : BaseEntity
    {
        [Key()]
        public int CandidateId { get; set; }

        [StringLength(100, ErrorMessage = "First Name Maximum 100 characters"), Display(Name = "First Name"), Required]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Last Name Maximum 100 characters"), Display(Name = "Last Name"), Required]
        public string LastName { get; set; }

        [Display(Name = "Home Email")]
        public string HomeEmail { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = AppConstants.DateFormat, ApplyFormatInEditMode = true), Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = AppConstants.DateFormat, ApplyFormatInEditMode = true), Display(Name = "Visit Date")]
        public DateTime? VisitDate { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "First Telephone"), Required]
        public string FirstTelephone { get; set; }

        [Display(Name = "Gender"), Required]
        public Gender Gender { get; set; }

        public string FullName
        {
            get { return string.Format("{0},{1}", LastName, FirstName); }
        }

        public virtual CandidateAssessment CandidateAssessment { get; set; }

    }
}
