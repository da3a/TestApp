using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core;

namespace TestApp.Entities
{
    public class BaseEntity
    {
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = AppConstants.DateFormat), Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = AppConstants.DateFormat), Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}
