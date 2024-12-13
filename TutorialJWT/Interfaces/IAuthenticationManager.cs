using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialJWT.Interfaces
{
    public interface IAuthenticationManager
    {
        string Authenticate(string username, string password);
		//http://172.31.116.41:8282/mw/SupportSite2.git
    }
}
