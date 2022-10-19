global using YaeAchievement;
using static YaeAchievement.Utils;


InstallExitHook();
CheckSelfIsRunning();
TryDisableQuickEdit();
InstallExceptionHook();
CheckGenshinIsRunning();

Console.WriteLine("----------------------------------------------------");
Console.WriteLine($"YaeAchievement (Modified by Xunkong) - 原神成就导出工具 ({GlobalVars.AppVersionName})");
Console.WriteLine("https://github.com/xunkong/YaeAchievement");
Console.WriteLine("若出现原神闪退的情况，请从下方链接处下载最新版本。");
Console.WriteLine("https://github.com/HolographicHat/YaeAchievement");
Console.WriteLine("----------------------------------------------------");

var gamePath = args.FirstOrDefault();
if (!File.Exists(gamePath))
{
    gamePath = SelectGameExecutable();
}


StartAndWaitResult(gamePath, str =>
{
    GlobalVars.UnexpectedExit = false;
    var list = AchievementAllDataNotify.Parser.ParseFrom(Convert.FromBase64String(str));
    Export.ToXunkong(list);
    return true;
});
