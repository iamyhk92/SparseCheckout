using FinstaInfrastructure.Loans.Masters;
using System;
using System.Collections.Generic;
using System.Text;


namespace FinstaRepository.Interfaces.Loans.Masters
{
   public  interface IContactMaster
    {
       // bool Saveaddresstype(string addressname);
        bool Savecontact(ContactMasterDTO contact);
        List<ContactMasterDTO> GetContactdetails();



        #region ContactAddressTypes       
        bool SaveAddressType(string addressname);

        List<contactAddressDTO> GetAddressType(string ConnectionString);
        #endregion

        #region ContactEnterpriseTypes     
        bool SaveEnterpriseType(string Enterprisetype);

        List<EnterpriseTypeDTO> GetEnterpriseType();
        #endregion


        #region ContactEnterpriseTypes     
        bool SaveBusinessTypes(string BusinessTypes);

        List<BusinessTypeDTO> GetBusinessTypes();
        #endregion
       
    }

}
