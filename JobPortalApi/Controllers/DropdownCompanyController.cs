using System;
using Microsoft.AspNetCore.Mvc;
using JobPortalApi.Services;
using JobPortalApi.Entities;
using Microsoft.Extensions.Options;
using JobPortalApi.Configuration;

namespace JobPortalApi.Controllers;

[ApiController]
[Route("[controller]")]

public class DropdownCompanyController : ControllerBase
{
    private readonly IOptions<conStr> _dbCon;
    private string cmd;

    public DropdownCompanyController(IOptions<conStr> dbCon)
    {
        _dbCon = dbCon;
    }
    [HttpGet("getJobCategory")]
    public IActionResult getJobCategory()
    {
        try
        {
            cmd = "select * from tbl_jobCategory";
            var response = dapperQuery.Qry<JobCategory>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getJobType")]
    public IActionResult getJobType()
    {
        try
        {
            cmd = "select * from tbl_jobType";
            var response = dapperQuery.Qry<JobType>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getWorkspaceType")]
    public IActionResult getWorkspaceType()
    {
        try
        {
            cmd = "select * from tbl_jobSpace";
            var response = dapperQuery.Qry<JobSpace>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getExperience")]
    public IActionResult getExperience()
    {
        try
        {
            cmd = "select * from tbl_experience where isdeleted=0";
            var response = dapperQuery.Qry<Experience>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getBenefit")]
    public IActionResult getBenefit()
    {
        try
        {
            cmd = "select * from tbl_Benefit where isDeleted=0";
            var response = dapperQuery.Qry<Benefit>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}