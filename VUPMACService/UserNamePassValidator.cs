using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace VUPMACService
{
    public class UserNamePassValidator :System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "vup@video-up.com" && password == "vup@123"))
            {
                throw new FaultException("Incorrect Username or Password");
            }
        }
    }
}