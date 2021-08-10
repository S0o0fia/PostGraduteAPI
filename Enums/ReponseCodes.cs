using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniWebAPI.Enums
{
    public enum ResponseCode
    {
        Success = 0,
        Error = 100,
        AccessDenied = 101,
        UserNotConfirmed = 10,
        UserNotFound = 11,
        UserAlreadyExist = 12,
        InvalidUserOrPassword = 13,
        CannotResetPassword = 14,
        EmailHasSentToUser = 16,
        EmailIsNoSent = 17,
        AccountIsNotActive = 18,
        ForgetPasswordCodeIsInvalid = 103,
        InvalidForgetPasswordCode = 104,
        TryAgain = 105,
        EmailOrPasswordAreInvalid = 106,
        EmailIsAlreadyTaken = 109,
        ImageIsEmpty = 110,
        ImageExtensionIsNotProvided = 111,
    }
}
