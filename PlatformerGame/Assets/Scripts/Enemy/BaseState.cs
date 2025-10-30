using UnityEngine;

public abstract class BaseState
{
    protected StateMachine stateMachine;
    protected EnemyController enemy;

    public BaseState(StateMachine machine, EnemyController enemyController) 
    {
        stateMachine = machine;
        enemy = enemyController;
    }

    public virtual void Enter() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void Exit() { }

}
