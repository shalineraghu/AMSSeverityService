using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using AuditSeverityModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditSeverityModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditSeverityController : ControllerBase
    {
        private readonly ISeverityProvider _severityProvider;
        private readonly ApplicationContext _context;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditSeverityController));
        public AuditSeverityController(ISeverityProvider severityProvider, ApplicationContext context)
        {
            _severityProvider = severityProvider;
            _context = context;
        }



        [HttpGet]
        public IActionResult ProjectExecutionStatus()
        {
            _log4net.Info(" Http GET Request From: " + nameof(AuditSeverityController));
            return Ok("SUCCESS");
        }



        [HttpPost]
        public IActionResult ProjectExecutionStatus( AuditRequest req)
        {
            _log4net.Info(" Http POST Request From: " + nameof(AuditSeverityController));

            if (req == null)
                return BadRequest();

            if (req.Auditdetails.Type != "Internal" && req.Auditdetails.Type != "SOX")
                return BadRequest("Wrong Audit Type");

            try
            {
                AuditResponse response = _severityProvider.SeverityResponse(req);
                return Ok(response);
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);  
                return StatusCode(500);
            }

        }

        [Route("savedetails")]
        [HttpPost]
        public async Task<IActionResult> SaveAuditDetailAsync(SaveAuditDetails det)
        {
            _log4net.Info(" Http POST Request From: " + nameof(AuditSeverityController));
            SaveAuditDetails saveDetails = null;
            if (det == null)
                return BadRequest();
            else {
                try
                {

                    saveDetails = new SaveAuditDetails()
                    {
                        projectName = det.projectName,
                        projectManagerName = det.projectManagerName,
                        applicationOwnerName = det.applicationOwnerName,
                        auditType = det.auditType,
                        auditDate = det.auditDate,
                        auditId = det.auditId,
                        projectExecutionStatus = det.projectExecutionStatus,
                        remedialActionDuration = det.remedialActionDuration
                    };
                    await _context.SaveDetail.AddAsync(saveDetails);
                    await _context.SaveChangesAsync();
                    return Ok(saveDetails);
                    //return saveDetails;
                }
                
                catch (Exception e)
                {
                    var w32ex = e as Win32Exception;
                    var code = w32ex.ErrorCode;
                    _log4net.Error(e.Message);
                    return StatusCode(code);
                }
            }
            

        }


    }
}
//For Postman test
//{
//    "ProjectName": "Audit Management",
//    "ProjectManagerName": "Sayan",
//    "ApplicationOwnerName": "Arpan",
//    "Auditdetails": 
//    {
//        "Type": "Internal",
//        "Date": "12/11/2005",
//        "questions": 
//        {
//            "Question1": true,
//            "Question2": true,
//            "Question3": false,
//            "Question4": false,
//            "Question5": false
//        }
//    }
//}