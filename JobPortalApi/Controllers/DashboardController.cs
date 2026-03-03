using System;
using Microsoft.AspNetCore.Mvc;
using JobPortalApi.Services;
using JobPortalApi.Entities;
using Microsoft.Extensions.Options;
using JobPortalApi.Configuration;

namespace JobPortalApi.Controllers;

[ApiController]
[Route("[controller]")]

public class DashboardController : ControllerBase
{
    private readonly IOptions<conStr> _dbCon;
    private string cmd;

    public DashboardController(IOptions<conStr> dbCon)
    {
        _dbCon = dbCon;
    }
    [HttpGet("getTotalJobCount")]
    public IActionResult getTotalJobCount(int companyID)
    {
        try
        {
            cmd = "select * from view_JobCount where companyID="+companyID+"";
            var response = dapperQuery.Qry<TotalJob>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("AllDashboardJobs")]
    public IActionResult AllDashboardJobs(int companyID)
    {
        try
        {
            if (companyID == null || companyID == 0)
            {
                cmd = "select distinct * from view_AllDashboardJobs";
            }
            else
            {
                cmd = "select distinct * from view_AllDashboardJobs where companyID="+companyID+"";
            }
            var response = dapperQuery.Qry<AllJobs>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getActiveJob")]
    public IActionResult getActiveJob(int companyID)
    {
        try
        {
            if (companyID == null || companyID == 0)
            {
                cmd = "select * from view_ActiveJobs order by jobID desc";
            }
            else
            {
                cmd = "select * from view_ActiveJobs where companyID=" + companyID + " order by jobID desc";
            }
            var response = dapperQuery.Qry<ActiveJob>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCompanyActiveJob")]
    public IActionResult getCompanyActiveJob(int companyID)
    {
        try
        {
            if (companyID == null || companyID == 0)
            {
                cmd = "select * from view_CompanyActiveJobs order by jobID desc";
            }
            else
            {
                cmd = "select * from view_CompanyActiveJobs where companyID=" + companyID + " order by jobID desc";
            }
            var response = dapperQuery.Qry<ActiveJob>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getJobApplications")]
    public IActionResult getJobApplications(int companyID)
    {
        try
        {
            if (companyID == null || companyID == 0)
            {
                cmd = "select * from view_JobApplication order by jobID desc";
            }
            else
            {
                cmd = "select * from view_JobApplication where companyID="+companyID+" order by jobID desc";
            }
            var response = dapperQuery.Qry<JobApplications>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}