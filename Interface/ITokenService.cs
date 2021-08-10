using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniWebAPI.Models;
using UniWebAPI.ViewModel;

namespace UniWebAPI.Interface
{
   public interface ITokenService
    {
        string CreatToken(PostGradutesInfo user);
    }
}
