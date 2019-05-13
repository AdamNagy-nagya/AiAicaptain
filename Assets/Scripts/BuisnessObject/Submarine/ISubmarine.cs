using System;
using UniRx.Async;

public interface ISubmarine : IBuisnessObject
{
    SubmarineBehaviour behaviour { get; }
    Nullable<UniTask> moveForward();
    Nullable<UniTask> moveLeftAndForward();
    Nullable<UniTask> moveRightAndForward();
    bool canMoveForward();
    bool canMoveLeft();
    bool canMoveRight();
    ITorpedo launchTorpedo(int x, int y);
    Direction Direction { get; }
    void hit(int amount);
    int getChests();
}