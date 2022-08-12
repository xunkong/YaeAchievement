using System.ComponentModel;

namespace YaeAchievement.Win32;

public static class Extensions
{

    public static int PrintMsgAndReturnErrCode(this Win32Exception ex, string msg)
    {
        Logger.Error($"{msg}: {ex.Message}");
        return ex.NativeErrorCode;
    }

}