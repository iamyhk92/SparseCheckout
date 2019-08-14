using System;
using System.Collections.Generic;
using System.Text;

namespace FinstaInfrastructure.Loans.Masters
{
  public class ContactMasterDTO
    {
        public string pName { get; set; }
        public Int64 pContactId { get; set; }
        public string pReferenceId { get; set; }
        public string pContactType { get; set; }
        public string pSurName { get; set; }
        public string pDob { get; set; }
        public string pGender { get; set; }
        public string pGenderCode { get; set; }
        public string pFatherName { get; set; }
        public string pSpouseName { get; set; }
        public string pTypeofEnterprise { get; set; }
        public string pNatureofBussiness { get; set; }
        public int pStatusId { get; set; }
        public int pCreatedBy { get; set; }
        public DateTime pCreatedDate { get; set; }
        public int pModifiedBy { get; set; }
        public DateTime pMidifiedDate { get; set; }
        public List<contactAddressDTO> pAddressList { get; set; }
        public List<conatactdetaisDTO> pcontactdetailslist { get; set; }


        public List<EnterpriseTypeDTO> pEnterpriseTypelist { get; set; }

        public List<BusinessTypeDTO> pBusinesstypelist { get; set; }


        public string pBusinesscontactreferenceid { get; set; }
        public string pBusinesscontactName { get; set; }
        public Int16  pAge { get; set; }
        public string pTitle { get; set; }
    }

    public class contactAddressDTO
    {
        public string pAddressType { get; set; }
        public string pAddress1 { get; set; }
        public string pAddress2 { get; set; }
        public string pState { get; set; }
        public int pStateId { get; set; }
        public string pDistrict { get; set; }
        public string pDistrictId { get; set; }
        public string pCity { get; set; }
        public int pCityId { get; set; }
        public string pCountry { get; set; }
        public Int64 pPinCode { get; set; }
    }
    public class conatactdetaisDTO
    {
        public string pEmailId1 { get; set; }
        public string pEmailId2 { get; set; }
        public string pContactNo { get; set; }
        public string pAlternativeNo { get; set; }
        public string pBusinessContactNo { get; set; }
    }

    public class EnterpriseTypeDTO
    {
        public string pEnterpriseType { get; set; }

    }

    public class BusinessTypeDTO
    {
        public string pBusinesstype { get; set; }

    }
}
