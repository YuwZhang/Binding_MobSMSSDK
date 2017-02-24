using System;

namespace Binding_SMSSDK
{
    public enum SMSResponseState : uint
    {
        Success = 0,
        Fail = 1,
        Cancel = 2
    }

    public enum SMSGetCodeMethod : uint
    {
        Sms = 0,
        Voice = 1
    }

    public enum SMSUIResponseState : uint
    {
        SMSUIResponseStateSuccess = 0,
        SMSUIResponseStateFail = 1,
        SMSUIResponseStateCancel = 2,
    }
}

