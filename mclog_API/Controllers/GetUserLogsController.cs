#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mclog_API.Data;
using mclog_API.Models;
using Microsoft.Data.SqlClient;

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public GetUserLogsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GetUserLogs
        [HttpGet]
        public List<GetUserLogs> GetgetUserLogs()
        {  
            return _context.getUserLogs.FromSqlRaw(@"SELECT ActivityLogs.Id, Users.Gender, Symptoms.SymptomName, ActivityLogs.Status, ActivityLogs.ActivityDate, Buildings.BuildingName, Buildings.Address FROM ActivityLogs 
            INNER JOIN BuildingLogs ON BuildingLogs.ActivityLogId = ActivityLogs.Id 
            INNER JOIN Buildings ON BuildingLogs.BuildingId = Buildings.id 
            INNER JOIN Users ON Users.Id = ActivityLogs.UserId 
            INNER JOIN UserHealthStatus ON UserHealthStatus.UserId = Users.Id 
            INNER JOIN Symptoms ON UserHealthStatus.Id = Symptoms.UserHealthStatusId").ToList();
        }   
    }
}
