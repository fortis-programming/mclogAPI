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
            return _context.getUserLogs.FromSqlRaw(@"SELECT ActivityLogs.Id, Buildings.BuildingName, Buildings.Address, ActivityLogs.ActivityDate, Users.Age, Users.Gender, ActivityLogs.Status, UserHealthStatus.Temperature
                FROM ActivityLogs
                INNER JOIN Buildings ON Buildings.Id = ActivityLogs.BuildingId
                INNER JOIN UserHealthStatus ON ActivityLogs.HealthStatusId = UserHealthStatus.Id
                INNER JOIN Symptoms ON Symptoms.Id = UserHealthStatus.Id
                INNER JOIN Users ON Users.Id = ActivityLogs.UserId").ToList();
        }   
    }
}
