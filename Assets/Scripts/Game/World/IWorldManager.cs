
using System;

public interface IWorldManager
{
    IGameMap GetGameMap();

    void gameEnded();
}