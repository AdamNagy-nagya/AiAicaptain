using System;
using System.Collections.Generic;
using UniRx.Async;

public class SubmarineTunnel : AiAiCaptain.FreePlayer.Interfaces.ISubmarine
{
    private readonly Queue<Func<UniTask>> actionQueue = new Queue<Func<UniTask>>();
    private const int actionDelay = 1000;
    private ISubmarine submarine;
    public SubmarineTunnel(ISubmarine submarine)
    {
        this.submarine = submarine;
        ActionLoop();
    }

    public void MoveForward()
    {
        actionQueue.Enqueue(() => submarine.moveForward().GetValueOrDefault());
    }

    public void MoveLeft()
    {
        actionQueue.Enqueue(() => submarine.moveLeftAndForward().GetValueOrDefault());
    }

    public void MoveRight()
    {
        actionQueue.Enqueue(() => submarine.moveRightAndForward().GetValueOrDefault());
    }

    private async void ActionLoop()
    {
        while (true)
        {
            await UniTask.WaitWhile(() => actionQueue.Count == 0);
            await UniTask.WaitUntil(() => submarine.behaviour.IsIdle());
            var actionCreator = actionQueue.Dequeue();
            var task = actionCreator();
            task.Forget();
            await UniTask.Delay(actionDelay);
        }
    }
}
