using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuditSeverityModule.Models
{
    public class SaveAuditDetails
    {

        [Key]
        public int id { get; set; }
        [JsonPropertyName("projectName")]
        public string projectName { get; set; }
        [JsonPropertyName("projectManagerName")]
        public string projectManagerName { get; set; }
        [JsonPropertyName("applicationOwnerName")]
        public string applicationOwnerName { get; set; }
        [JsonPropertyName("auditType")]
        public string auditType { get; set; }
        [JsonPropertyName("auditDate")]
        public string auditDate { get; set; }
        [JsonPropertyName("auditId")]
        public int auditId { get; set; }
        [JsonPropertyName("projectExecutionStatus")]
        public string projectExecutionStatus { get; set; }
        [JsonPropertyName("remedialActionDuration")]
        public string remedialActionDuration { get; set; }


    }
}
