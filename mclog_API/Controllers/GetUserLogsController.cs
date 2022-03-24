#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mclog_API.Data;
using mclog_API.Models;

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
            /*
             @"SELECT ActivityLogs.Id, Buildings.BuildingName, Buildings.Address, ActivityLogs.ActivityDate, Users.Age, Users.Gender, ActivityLogs.Status, UserHealthStatus.Temperature
                FROM ActivityLogs
                INNER JOIN Buildings ON Buildings.Id = ActivityLogs.BuildingId
                INNER JOIN UserHealthStatus ON UserHealthStatus.Id = ActivityLogs.HealthStatusId
                INNER JOIN Users ON Users.Id = ActivityLogs.UserId"
             */
            //return _context.getUserLogs.FromSqlRaw(@"SELECT ActivityLogs.Id, ActivityLogs.ActivityDate, ActivityLogs.Status, Buildings.BuildingName, Buildings.Addre, Users.Gender, Users.Province, Users.Region, Users.City, Users.Age FROM ActivityLogs INNER JOIN Buildings ON Buildings.Id = ActivityLogs.BuildingId INNER JOIN Users ON Users.Id = ActivityLogs.UserId").ToList();
            return _context.getUserLogs.FromSqlRaw(@"SELECT ActivityLogs.Id, ActivityLogs.ActivityDate, ActivityLogs.Status, Buildings.BuildingName, Buildings.Address, Users.Gender, Users.Age FROM ActivityLogs INNER JOIN Buildings ON Buildings.Id = ActivityLogs.BuildingId INNER JOIN Users ON Users.Id = ActivityLogs.UserId").ToList();
        }
    }
}