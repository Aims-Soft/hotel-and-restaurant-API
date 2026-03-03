using System;
using Microsoft.AspNetCore.Mvc;
using JobPortalApi.Services;
using JobPortalApi.Entities;
using Microsoft.Extensions.Options;
using JobPortalApi.Configuration;

namespace JobPortalApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CompanyController : ControllerBase
{
    private readonly IOptions<conStr> _dbCon;
    private string cmd;

    public CompanyController(IOptions<conStr> dbCon)
    {
        _dbCon = dbCon;
    }
    [HttpGet("getCompanyEmpolyee")]
    public IActionResult getCompanyEmpolyee()
    {
        try
        {
            cmd = "select * from tbl_employee_range where isdeleted=0";
            var response = dapperQuery.Qry<CompanyEmployee>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCity")]
    public IActionResult getCity()
    {
        try
        {
            cmd = "select cityID,cityName,countryID from tbl_city where isdeleted=0";
            var response = dapperQuery.Qry<GetCity>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getApplicationStatus")]
    public IActionResult getApplicationStatus()
    {
        try
        {
            cmd = "select * from tbl_jobapplicationstatus";
            var response = dapperQuery.Qry<ApplicationStatus>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCountry")]
    public IActionResult getCountry()
    {
        try
        {
            cmd = "select countryID,countryName from tbl_country where isdeleted=0";
            var response = dapperQuery.Qry<GetCountry>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getIndustryType")]
    public IActionResult getIndustryType()
    {
        try
        {
            cmd = "select companyTypeID,companyTypeTitle from tbl_companyType";
            var response = dapperQuery.Qry<IndustryType>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getCompanyDomain")]
    public IActionResult getCompanyDomain(int companyTypeID)
    {
        try
        {
            cmd = "select * from view_companyDomain where companyTypeID="+companyTypeID+"";
            var response = dapperQuery.Qry<CompanyDomain>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("getUserTpye")]
    public IActionResult getUserTpye()
    {
        try
        {
            cmd = "select * from tbl_user_Type";
            var response = dapperQuery.Qry<UserType>(cmd, _dbCon);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("saveCompanyUser")]
        public IActionResult saveCompanyUser(SaveCompanyUser model)
        {
            try
            {
                model.eDocPath = "C:\\inetpub\\wwwroot\\jobPortal\\jobPortal-app\\assets\\Job-images\\CompanyImage";
                model.eLogoPath = "C:\\inetpub\\wwwroot\\jobPortal\\jobPortal-app\\assets\\Job-images\\CompanyLogo";
                model.eLicensePath = "C:\\inetpub\\wwwroot\\jobPortal\\jobPortal-app\\assets\\Job-images\\CompanyLicense";
                model.eBillPath = "C:\\inetpub\\wwwroot\\jobPortal\\jobPortal-app\\assets\\Job-images\\CompanyBill";
                model.eAgreementPath = "C:\\inetpub\\wwwroot\\jobPortal\\jobPortal-app\\assets\\Job-images\\CompanyAgreement";
                model.eLetterPath = "C:\\inetpub\\wwwroot\\jobPortal\\jobPortal-app\\assets\\Job-images\\CompanyLetter";
                var response = dapperQuery.SPReturn("sp_saveCompanyUser", model, _dbCon);
                var data = response.Select(row => new { res = row.ToString() });
                bool result = data.First().res.Contains("Success");

                if (result == true && (model.eDocPath != null && model.eDocPath != "" && model.eDocPath != "null"))
                {
                    var companyID = data.First().res.Split("|||")[1];
                    dapperQuery.saveImageFile(
                        model.eDocPath,
                        companyID,
                        model.eDoc,
                        model.eDocExt);
                }
                if (result == true && (model.eLogoPath != null && model.eLogoPath != "" && model.eLogoPath != "null"))
                {
                    var companyID = data.First().res.Split("|||")[1];
                    dapperQuery.saveImageFile(
                        model.eLogoPath,
                        companyID,
                        model.eLogo,
                        model.eLogoExt);
                }
                if (result == true && (model.eLicensePath != null && model.eLicensePath != "" && model.eLicensePath != "null"))
                {
                    var companyID = data.First().res.Split("|||")[1];
                    dapperQuery.saveImageFile(
                        model.eLicensePath,
                        companyID,
                        model.eLicense,
                        model.eLicenseExt);
                }
                if (result == true && (model.eBillPath != null && model.eBillPath != "" && model.eBillPath != "null"))
                {
                    var companyID = data.First().res.Split("|||")[1];
                    dapperQuery.saveImageFile(
                        model.eBillPath,
                        companyID,
                        model.eBill,
                        model.eBillExt);
                }
                if (result == true && (model.eAgreementPath != null && model.eAgreementPath != "" && model.eAgreementPath != "null"))
                {
                    var companyID = data.First().res.Split("|||")[1];
                    dapperQuery.saveImageFile(
                        model.eAgreementPath,
                        companyID,
                        model.eAgreement,
                        model.eAgreementExt);
                }
                if (result == true && (model.eLetterPath != null && model.eLetterPath != "" && model.eLetterPath != "null"))
                {
                    var companyID = data.First().res.Split("|||")[1];
                    dapperQuery.saveImageFile(
                        model.eLetterPath,
                        companyID,
                        model.eLetter,
                        model.eLetterExt);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

}