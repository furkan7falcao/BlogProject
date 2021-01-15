using Furkan.Furkan_BlogProject.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Business.Tools.JwtTool
{
    public interface IJwtService
    {
        public JwtToken GenerateJwt(AppUser appUser);
    }
}
