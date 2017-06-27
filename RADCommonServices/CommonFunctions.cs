using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace RADCommonServices
{
    public class CommonFunctions
    {
        public int GetUsersCompanyID(HttpContext Context)
        {
            int companyID = 0;
            BusinessLogic objBussLogic = new BusinessLogic();
            string userId = objBussLogic.GetUserId(Context.User.Identity.Name);
            if (userId != "0")
            {
                Guid userGuid = Guid.Parse(userId);
                DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
                if (dtCompanies != null && dtCompanies.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCompanies.Rows)
                    {
                        companyID = Convert.ToInt32(dr["CompanyID"]);
                    }
                }
            }
            return companyID;
        }
    }
}
