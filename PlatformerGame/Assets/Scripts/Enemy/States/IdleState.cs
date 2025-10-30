using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(EnemyController enemy, StateMachine stateMachine) 
        : base (stateMachine, enemy) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
