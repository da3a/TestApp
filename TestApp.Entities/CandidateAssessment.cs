using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Entities;

namespace TestApp.Entities
{
    public class CandidateAssessment : BaseEntity
    {
        [Key(), ForeignKey("Candidate"), Display(Name = "Candidate Id"), Required]
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

        [Display(Name = "Do you have healthy skin?")]
        public bool HealthySkin { get; set; }

        [Display(Name = "Atopic dermatitis?")]
        public bool AtopicDermatitis { get; set; }

        [Display(Name = "Psoriasis?")]
        public bool Psoriasis { get; set; }

        [Display(Name = "Do you have history of allergy to cosmetics, sunscreens and tropical medications?")]
        public bool AllergyHistory { get; set; }

        [Display(Name = "Chronic diseases that involve taking medication?")]
        public bool ChronicDiseases { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Please detail any drugs taken for chronic diseases")]
        public string ChronicDiseasesDrugTypes { get; set; }

        [Display(Name = "Suffer Diabetes?")]
        public bool SufferDiabetes { get; set; }

        [Display(Name = "Have suffered from diabetes for more than 6 months?")]
        public bool SufferDiabetesGtSixMonths { get; set; }

        [Display(Name = "Has your diabetes been under control for the last 6 months?")]
        public bool SufferDiabetesUnderControl { get; set; }

        [Display(Name = "Suffer from thyroid problems?")]
        public bool SufferThyroidProblems { get; set; }

        [Display(Name = "Suffer from thyroid problems for more than six months?")]
        public bool SufferThyroidProblemsGtSixMonths { get; set; }

        [Display(Name = "Have your thyroid problems been under control for the last 6 months?")]
        public bool SufferThyroidProblemsUnderControl { get; set; }

        [Display(Name = "Are you pregnant or expect to be pregnant in the coming months?")]
        public bool PregnantNextMonths { get; set; }

        [Display(Name = "Are you breastfeeding?")]
        public bool BreastFeeding { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Comments")]
        public string Comments { get; set; }


    }
}
