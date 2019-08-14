using FinstaInfrastructure.Loans.Masters;
using FinstaRepository.Interfaces.Loans.Masters;
using HelperManager;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace FinstaRepository.DataAccess.Loans.Masters
{
   public class ContactMasterDAL: IContactMaster
    {
        NpgsqlConnection con = new NpgsqlConnection(NPGSqlHelper.SQLConnString);
        NpgsqlDataReader dr = null;



        public List<contactAddressDTO> lstAddressDetails { get; set; }
        public List<EnterpriseTypeDTO> lstEnterpriseType { get; set; }
       public List<BusinessTypeDTO> lstBusinessType { get; set; }

        public bool Savecontact(ContactMasterDTO contact)
        {
            bool isSaved = false;
            try
            {
                string savecontact = string.Empty;
                if (contact.pContactType == "")
                {
                    savecontact = "insert into tabcontact(contactreferenceid,contacttype,name,surname,dob,gender,gendercode,fathername,spousename,contactnumber,alternatenumber,emailid1,emailid2,statusid,createdby,dreateddate) values('" + contact.pReferenceId  + "','" + contact.pContactType  + "','" + contact.pName + "','" + contact.pSurName + "','" + contact.pDob + "','" + contact.pGender + "','" + contact.pGenderCode  + "','" + contact.pFatherName + "','" + contact.pSpouseName + "','" +contact.pcontactdetailslist[0].pContactNo + "','" + contact.pcontactdetailslist[0].pAlternativeNo + "','"+contact.pcontactdetailslist[0].pEmailId1+ "','" + contact.pcontactdetailslist[0].pEmailId2 + "',1,1,current_timestamp)";
                    NPGSqlHelper.ExecuteNonQuery(NPGSqlHelper.SQLConnString, CommandType.Text, savecontact);
                    isSaved = true;
                }
                else
                {
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isSaved;
        }
        public List<ContactMasterDTO> GetContactdetails()
        {
            List<ContactMasterDTO> lstcontactdetails = new List<ContactMasterDTO>();

            try
            {
          dr = NPGSqlHelper.ExecuteReader(NPGSqlHelper.SQLConnString, CommandType.Text, "select * from tabcontact tc join tabcontactaddressdetails tca on tc.contactreferenceid=tca.contactreferenceid");
                while (dr.Read())
                {
                    ContactMasterDTO obj = new ContactMasterDTO();
                    obj.pReferenceId                          = dr["contacttype"].ToString();
                    obj.pContactType                          = dr["contacttype"].ToString();
                    obj.pName                                 = dr["name"].ToString();
                    obj.pSurName                              = dr["surname"].ToString();
                    obj.pDob                                  = dr["dob"].ToString();
                    obj.pGender                               = dr["gender"].ToString();
                    obj.pFatherName                           = dr["fathername"].ToString();
                    obj.pSpouseName                           = dr["spousename"].ToString();
                    obj.pcontactdetailslist[0].pContactNo     = dr["contactnumber"].ToString();
                    obj.pcontactdetailslist[0].pAlternativeNo = dr["alternatenumber"].ToString();
                    obj.pcontactdetailslist[0].pEmailId1      = dr["emailid1"].ToString();
                    obj.pcontactdetailslist[0].pEmailId1      = dr["emailid2"].ToString();
                    obj.pAddressList[0].pAddressType          = dr["pAddressType"].ToString();
                    obj.pAddressList[0].pAddress1             = dr["pAddress1"].ToString();
                    obj.pAddressList[0].pAddress2             = dr["pAddress2"].ToString();
                    obj.pAddressList[0].pState                = dr["pState"].ToString();
                    obj.pAddressList[0].pDistrict             = dr["pDistrict"].ToString();
                    obj.pAddressList[0].pCity                 = dr["pCity"].ToString();
                    obj.pAddressList[0].pCountry              = dr["pCountry"].ToString();
                    obj.pAddressList[0].pPinCode              = Convert .ToInt64( dr["pPinCode"]);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lstcontactdetails;
        }



        #region ContactAddressTypes       
        public bool SaveAddressType(string addresstype)
        {
            bool isSaved = false;
            try
            {

                NPGSqlHelper.ExecuteNonQuery(NPGSqlHelper.SQLConnString, CommandType.Text, "insert into tblmstaddresstypes(addresstype,statusid,createdby,createddate)values('" + addresstype + "',1,1,current_timestamp);");
                isSaved = true;

            }
            catch (Exception)
            {

                throw;
            }
            return isSaved;
        }


        public List<contactAddressDTO> GetAddressType(string ConnectionString)
        {
            lstAddressDetails = new List<contactAddressDTO>();
            try
            {
                dr = NPGSqlHelper.ExecuteReader(ConnectionString, CommandType.Text, "select ADDRESSTYPE from TBLMSTADDRESSTYPES");
                while (dr.Read())
                {
                    contactAddressDTO objaddressdetails = new contactAddressDTO();
                    objaddressdetails.pAddressType = dr["ADDRESSTYPE"].ToString();
                    lstAddressDetails.Add(objaddressdetails);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstAddressDetails;

        }

        #endregion


        #region ContactEnterpriseTypes       

        public List<EnterpriseTypeDTO> GetEnterpriseType()
        {


            try
            {
                dr = NPGSqlHelper.ExecuteReader(NPGSqlHelper.SQLConnString, CommandType.Text, "select ENTERPRISETYPE from TBLMSTENTERPRISETYPES");
                while (dr.Read())
                {
                    EnterpriseTypeDTO objenterprise = new EnterpriseTypeDTO();
                    objenterprise.pEnterpriseType = dr["ENTERPRISETYPE"].ToString();
                    lstEnterpriseType.Add(objenterprise);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstEnterpriseType;

        }

        public bool SaveEnterpriseType(string Enterprisetype)
        {
            bool isSaved = false;
            try
            {

                NPGSqlHelper.ExecuteNonQuery(NPGSqlHelper.SQLConnString, CommandType.Text, "insert into tblmstenterprisetypes(enterprisetype,statusid,createdby,createddate))values('" + Enterprisetype + "',1,1,current_timestamp);");
                isSaved = true;

            }
            catch (Exception)
            {

                throw;
            }
            return isSaved;
        }

        #endregion


        #region ContactBusinessTypes       

        public List<BusinessTypeDTO> GetBusinessTypes()
        {
            lstBusinessType = new List<BusinessTypeDTO>();

            try
            {
                dr = NPGSqlHelper.ExecuteReader(NPGSqlHelper.SQLConnString, CommandType.Text, "select businesstype from tblmstbusinesstypes");
                while (dr.Read())
                {
                    BusinessTypeDTO objbusinesstype = new BusinessTypeDTO();
                    objbusinesstype.pBusinesstype = dr["businesstype"].ToString();
                    lstBusinessType.Add(objbusinesstype);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstBusinessType;

        }

        public bool SaveBusinessTypes(string Businesstype)
        {
            bool isSaved = false;
            try
            {

                NPGSqlHelper.ExecuteNonQuery(NPGSqlHelper.SQLConnString, CommandType.Text, "insert into tblmstbusinesstypes(businesstype,statusid,createdby,createddate))values('" + Businesstype + "',1,1,current_timestamp);");
                isSaved = true;

            }
            catch (Exception)
            {

                throw;
            }
            return isSaved;
        }

        #endregion


    }
}
