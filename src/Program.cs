global using YaeAchievement;
using static YaeAchievement.Utils;

var gamePath = args.FirstOrDefault();
if (!File.Exists(gamePath))
{
    return;
}

InstallExitHook();
CheckSelfIsRunning();
TryDisableQuickEdit();
InstallExceptionHook();
CheckGenshinIsRunning();

Console.WriteLine("----------------------------------------------------");
Console.WriteLine($"YaeAchievement (Modified by Xunkong) - 原神成就导出工具 ({GlobalVars.AppVersionName})");
Console.WriteLine("https://github.com/xunkong/YaeAchievement");
Console.WriteLine("原项目 https://github.com/HolographicHat/YaeAchievement");
Console.WriteLine("----------------------------------------------------");


StartAndWaitResult(gamePath, str =>
{
    GlobalVars.UnexpectedExit = false;
    var list = AchievementAllDataNotify.Parser.ParseFrom(Convert.FromBase64String(str));
    Export.ToXunkong(list);
    return true;
});
