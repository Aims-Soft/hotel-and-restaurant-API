using System;
using Microsoft.AspNetCore.Mvc;
using JobPortalApi.Services;
using JobPortalApi.Entities;
using Microsoft.Extensions.Options;
using JobPortalApi.Configuration;

namespace JobPortalApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AdminController : ControllerBase
{
    private readonly IOptions<conStr> _dbCon;
    private string cmd;

    public AdminController(IOptions<conStr> dbCon)
    {
        _dbCon = dbCon;
    }
    [HttpGet("getJobCountAdmin")]
    public IActionResult getJobCountAdmin()
    {
        try
        {
            cmd = "select * from view_JobCountAdmin";
            var response = dapperQuery.Qry<TotalJobAdmin>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("CompanyJobs")]
    public IActionResult CompanyJobs(int companyID)
    {
        try
        {
            if (companyID == null || companyID == 0)
            {
                cmd = "select * from view_CompanyJobs order by jobTitle";
            }
            else
            {
                cmd = "select * from view_CompanyJobs where companyID=" + companyID + " order by jobTitle";
            }
            
            var response = dapperQuery.Qry<CompanyJob>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("AllJobs")]
    public IActionResult AllJobs(int companyID)
    {
        try
        {
            if (companyID == null || companyID == 0)
            {
                cmd = "select distinct * from view_alljobs";
            }
            else
            {
                cmd = "select distinct * from view_alljobs where companyID="+companyID+"";
            }
            var response = dapperQuery.Qry<AllJobs>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCompanyDetail")]
    public IActionResult getCompanyDetail()
    {
        try
        {
            cmd = "select * from view_companyDetails order by companyID desc";
            var response = dapperQuery.Qry<CompanyDetails>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCompanyJobUser")]
    public IActionResult getCompanyJobUser(int jobID)
    {
        try
        {
            cmd = "select *from view_companyJobUser where jobID="+jobID+"";
            var response = dapperQuery.Qry<CompanyJobUser>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getUserJobDetails")]
    public IActionResult getUserJobDetails(int userID)
    {
        try
        {
            cmd = "select * from view_userJobDetails where userID="+userID+"";
            var response = dapperQuery.Qry<UserJobDetails>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getUserJobs")]
    public IActionResult getUserJobs(int userID)
    {
        try
        {
            cmd = "select * from view_userJobs where userID="+userID+"";
            var response = dapperQuery.Qry<UserJobDetails>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getUserJobDomain")]
    public IActionResult getUserJobDomain(int userID)
    {
        try
        {
            cmd = "select * from view_userJobDomain where userID="+userID+"";
            var response = dapperQuery.Qry<UserJobDomains>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCompanyDetailRequest")]
    public IActionResult getCompanyDetailRequest()
    {
        try
        {
            cmd = "select * from view_companyDetailsRequest order by companyID desc";
            var response = dapperQuery.Qry<CompanyDetails>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getApplicantInfo")]
    public IActionResult getApplicantInfo()
    {
        try
        {
            cmd = "select * From view_ApplicantInfo";
            var response = dapperQuery.Qry<ApplicantDetails>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("CompanyRequestStatus")]
    public IActionResult CompanyRequestStatus(CompanyRequest model)
    {
        try
        {
            var response = dapperQuery.SPReturn("sp_saveCompanyRequest", model, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return Ok(e);
        }
    }
}