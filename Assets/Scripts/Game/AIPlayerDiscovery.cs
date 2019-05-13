using System;
using System.Linq;
using AiAiCaptain.FreePlayer.Interfaces;

public class AIPlayerDiscovery
{
    public IFreePlayer GetFirstFreePlayer()
    {
        var type = typeof(IFreePlayer);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p));

        var player = Activator.CreateInstance(types.First());
        return player as IFreePlayer;
    }
}