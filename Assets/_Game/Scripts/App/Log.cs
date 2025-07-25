using UnityEngine;

namespace Game.App
{
  public static class Log
  {
    private const string Prefix = "[Game]";

    private static readonly ILogger Logger = UnityEngine.Debug.unityLogger;

    public static void Trace(object message)
    {
      Logger.Log(LogType.Log, $"{Prefix} {message}");
    }

    public static void Debug(string message)
    {
      Logger.Log(LogType.Log, $"{Prefix} {message}");
    }

    public static void Info(string message)
    {
      Logger.Log(LogType.Log, $"{Prefix} {message}");
    }

    public static void Warning(string message)
    {
      Logger.Log(LogType.Warning, $"{Prefix} {message}");
    }

    public static void Error(string message)
    {
      Logger.Log(LogType.Error, $"{Prefix} {message}");
    }
  }
}
