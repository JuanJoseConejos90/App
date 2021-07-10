using System;
using System.Collections.Generic;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace deliveryAppInfrastructure.utilities
{
    public class BCryptUtil
    {

        public String generatePassBCryt(String pass)
        {
            String HashPassword = String.Empty;
            if (!String.IsNullOrEmpty(pass))
            {
                HashPassword= BC.HashPassword(pass);
            }

            return HashPassword;
        }

        public Boolean verifyPass(String pass, String HashPassword)
        {

            Boolean verify = false;
            if (!String.IsNullOrEmpty(pass) && !String.IsNullOrEmpty(HashPassword))
            {
                verify = BC.Verify(pass, HashPassword);
            }

            return verify;

        }
        
    }
}
