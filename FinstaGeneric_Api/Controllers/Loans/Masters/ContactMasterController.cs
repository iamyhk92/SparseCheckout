using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinstaInfrastructure.Loans.Masters;
using FinstaRepository.DataAccess.Loans.Masters;
using FinstaRepository.Interfaces.Loans.Masters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FinstaApi.Controllers.Loans.Masters
{
    [ApiController]
    public class ContactMasterController : ControllerBase
    {

        string Con = string.Empty;
        static IConfiguration _iconfiguration;
        public ContactMasterController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            Con = _iconfiguration.GetSection("ConnectionStrings").GetSection("Connection").Value;
        }


        IContactMaster obj = new ContactMasterDAL();
        List<contactAddressDTO> lstcontactaddress { get; set; }
        List<EnterpriseTypeDTO> lstEnterprisetype { get; set; }
        List<BusinessTypeDTO> lstBusinessType { get; set; }


        [Route("api/loans/masters/contact/Savecontact")]
        [HttpPost]
        public void Savecontact(ContactMasterDTO contact)
        {
            try
            {
                obj.Savecontact(contact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("api/loans/masters/contact/GetContactDetails")]

        public List<ContactMasterDTO> GetContactdetails()
        {
            try
            {
                return obj.GetContactdetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("api/loans/masters/contact/SaveAddressType")]
        [HttpPost]
        public bool SaveAddressType(contactAddressDTO _address)
        {
            try
            {
                return obj.SaveAddressType(_address.pAddressType);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("api/loans/masters/contact/GetAddressType")]

        public List<contactAddressDTO> GetAddressType()
        {
            lstcontactaddress = new List<contactAddressDTO>();
            try
            {
                lstcontactaddress = obj.GetAddressType(Con);

            }
            catch (Exception)
            {
                throw;
            }
            return lstcontactaddress;

        }




        [Route("api/loans/masters/contact/SaveEnterpriseType")]
        [HttpPost]
        public bool SaveEnterpriseType(EnterpriseTypeDTO _Enterprise)
        {
            try
            {
                return obj.SaveAddressType(_Enterprise.pEnterpriseType);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("api/loans/masters/contact/GetEnterpriseType")]

        public List<EnterpriseTypeDTO> GetEnterpriseType()
        {
            lstEnterprisetype = new List<EnterpriseTypeDTO>();
            try
            {
                lstEnterprisetype = obj.GetEnterpriseType();
            }
            catch (Exception)
            {
                throw;
            }
            return lstEnterprisetype;

        }



        [Route("api/loans/masters/contact/SaveBusinessTypes")]
        [HttpPost]
        public bool SaveNatureofbusiness(BusinessTypeDTO _type)
        {
            try
            {
                return obj.SaveBusinessTypes(_type.pBusinesstype);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("api/loans/masters/contact/GetBusinessTypes")]
        public List<BusinessTypeDTO> GetBusinessTypes()
        {
            lstBusinessType = new List<BusinessTypeDTO>();
            try
            {
                lstBusinessType = obj.GetBusinessTypes();
            }
            catch (Exception)
            {
                throw;
            }
            return lstBusinessType;

        }
    }
}