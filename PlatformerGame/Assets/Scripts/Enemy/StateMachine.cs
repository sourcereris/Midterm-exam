using UnityEngine;

public class StateMachine
{
    public BaseState CurrentState {  get; private set; }

    public IdleState IdleState;
    public ArmoredState ArmoredState;

    public StateMachine(EnemyController enemy) 
    {
        this.IdleState = new IdleState(enemy, this);
        this.ArmoredState = new ArmoredState(enemy, this);
    }

    public void Initialize(BaseState startingState) 
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(BaseState newState) 
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void UpdateState() 
    {
        CurrentState?.FrameUpdate();
    }

    public void PhysicsUpdate()
    {
        CurrentState?.PhysicsUpdate();
    }
}
