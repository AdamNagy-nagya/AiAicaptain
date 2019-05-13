using System;
using UniRx.Async;
using UnityEngine;

public class Submarine : ISubmarine
{
    private int healthPoints;
    private int chests;
    public SubmarineBehaviour behaviour { get; }
    private IWorldManager gameContext;

    public Submarine(SubmarineBehaviour behaviour, IWorldManager gameContext)
    {
        this.behaviour = behaviour;
        this.gameContext = gameContext;
        Debug.Log("Sub : " + X + " " + Y);
    }

    public Direction Direction => behaviour.getDirection();

    public int X => behaviour.X;

    public int Y => behaviour.Y;

    public void hit(int amount)
    {
        healthPoints -= amount;
    }

    public ITorpedo launchTorpedo(int x, int y)
    {
        throw new NotImplementedException();
    }

    public Nullable<UniTask> moveForward()
    {
        ITile nextTile = getForwardNextTile();
        if (nextTile.isStepable())
        {
            changeMyTile(nextTile);
            return new Nullable<UniTask>(behaviour.MoveForward());
        }
        else
        {
            return null;
        }
    }

    public Nullable<UniTask> moveLeftAndForward()
    {
        ITile nextTile = getForwardLeftNextTile();
        if (getForwardNextTile().isStepable() && nextTile.isStepable())
        {
            changeMyTile(nextTile);
            return new Nullable<UniTask>(behaviour.MoveLeftAndForward());
        }
        else
        {
            return null;
        }
    }

    public Nullable<UniTask> moveRightAndForward()
    {
        ITile nextTile = getForwardRightNextTile();
        if (getForwardNextTile().isStepable() && nextTile.isStepable())
        {
            changeMyTile(nextTile);
            return new Nullable<UniTask>(behaviour.MoveRightAndForward());
        }
        else
        {
            return null;
        }
    }

    private ITile getForwardNextTile()
    {
        int x = X;
        int y = Y;

        switch (Direction)
        {
            case Direction.EAST:
                x++;
                break;
            case Direction.WEST:
                x--;
                break;
            case Direction.NORTH:
                y++;
                break;
            case Direction.SOUTH:
                y--;
                break;
        }
        Debug.Log("x " + x + " y " + y);
        return gameContext.GetGameMap().GetTile(x, y);
    }

    private ITile getForwardLeftNextTile()
    {
        int x = X;
        int y = Y;

        switch (Direction)
        {
            case Direction.EAST:
                x++;
                y++;
                break;
            case Direction.WEST:
                x--;
                y--;
                break;
            case Direction.NORTH:
                x--;
                y++;
                break;
            case Direction.SOUTH:
                x++;
                y--;
                break;
        }
        return gameContext.GetGameMap().GetTile(x, y);
    }

    private ITile getForwardRightNextTile()
    {
        int x = X;
        int y = Y;

        switch (Direction)
        {
            case Direction.EAST:
                x++;
                y--;
                break;
            case Direction.WEST:
                x--;
                y++;
                break;
            case Direction.NORTH:
                x++;
                y++;
                break;
            case Direction.SOUTH:
                x--;
                y--;
                break;
        }
        return gameContext.GetGameMap().GetTile(x, y);
    }

    private void changeMyTile(ITile goalTile)
    {
        gameContext.GetGameMap().GetTile(X, Y).leaveTile(this);
        goalTile.enterTile(this);
    }

    public void notifyEnteredGoalTile()
    {
        gameContext.gameEnded();
    }

    public int getChests()
    {
        throw new NotImplementedException();
    }

    public bool canMoveForward()
    {
        ITile nextTile = getForwardNextTile();
        return nextTile.isStepable() || true;
    }

    public bool canMoveLeft()
    {
        ITile nextTile = getForwardLeftNextTile();
        return getForwardNextTile().isStepable() && nextTile.isStepable() ||true;
    }

    public bool canMoveRight()
    {
        ITile nextTile = getForwardRightNextTile();
        return getForwardNextTile().isStepable() && nextTile.isStepable() ||true;
    }
}