using System;
using UniRx.Async;
using UnityEngine;

public class SubmarineBehaviour : MonoBehaviour
{
    private const string forwardTrigger = "ForwardTrigger";
    private const string leftAndForwardTrigger = "LeftNForwardTrigger";
    private const string rightAndForwardTrigger = "RightNForwardTrigger";
    private Animator animator;

    private float x, y;
    private float rotation;

    public int X
    {
        get
        {
            return (int)Math.Round(x / 10);
        }
    }
    public int Y
    {
        get
        {
            return (int)Math.Round(y / 10);
        }
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.z;
        rotation = gameObject.transform.rotation.eulerAngles.y;

    }

    public UniTask MoveForward() => ForceSetTrigger(forwardTrigger);

    public UniTask MoveLeftAndForward() => ForceSetTrigger(leftAndForwardTrigger);

    public UniTask MoveRightAndForward() => ForceSetTrigger(rightAndForwardTrigger);

    private async UniTask ForceSetTrigger(string triggerName)
    {
        await UniTask.WaitWhile(() => animator.GetBool(triggerName));
        Debug.Log(triggerName);
        animator.SetTrigger(triggerName);
    }

    public bool IsIdle()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsTag("Submarine.Idle");
    }

    public Direction getDirection()
    {
        while (rotation >= 180) {
            rotation -= 360;
        }

        if (rotation >= -45 && rotation <= 45)
        {
            return Direction.NORTH;
        }
        else if (rotation >= 135 || rotation <= -135)
        {
            return Direction.SOUTH;
        }
        else if (rotation < -45 && rotation > -135)
        {
            return Direction.WEST;
        }
        else
        {
            return Direction.EAST;
        }
    }
}
