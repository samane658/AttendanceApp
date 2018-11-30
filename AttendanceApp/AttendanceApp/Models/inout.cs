using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class inout
    {
        public int Id { get; set; }

        [Display(Name = "تاریخ")]
        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public ApplicationUser user { get; set; }

        public string personId { get; set; }

        [Display(Name = "شروع")]
        [Column(TypeName = "datetime2")]
        public DateTime startTime { get; set; }

        [Display(Name = "پایان")]
        [Column(TypeName = "datetime2")]
        public DateTime endTime { get; set; }


        [Display(Name = "مرخصی ؟")]
        public bool isRest { get; set; }

        /*
         * 
         * [DatabaseGenerated(DatabaseGeneratedOption.Computed)
         public int pmd {get (){ counting ligic}}
             
             */

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double workInThisDay {
            get
            {
                if (endTime != null)
                return ((endTime - startTime).TotalHours);
                
                return 0.0;
            }

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double delayInThisDay {
            get {
                var rule = new rule();

                //ToDo check delay accounting
                if (startTime != null)
                {
                    var delay = startTime.TimeOfDay.TotalHours - rule.startWorkTime;
                    if (delay > 0.0)
                        return (delay);
                }
                 

                return (0.0);
            }

        }

        [Display(Name = "تایید شده ؟")]
        public bool isCommited { get; set; }
        public ICollection<ApplicationUser> person { get; set; }
    }
}