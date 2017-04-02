using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Staff
{
    public class RefresherTraining:LocalEntity
    {
        [BoundWith("EmployeeObj")]
        public Guid Employee { get; set; }
        [Skip]
        public Employee EmployeeObj { get; set; }

        public string CourseName { get; set; }
        
        #region Свидетельство (удостоверение)

        public string CertificateNo { get; set; }
        public DateTime? CertificateDate { get; set; }

        #endregion
    }
}
