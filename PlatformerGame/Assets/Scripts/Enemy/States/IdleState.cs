using UnityEngine;

public class IdleState : BaseState
{
    float _detectionRadius = 3f;
    float _radiusSquared;
    public IdleState(EnemyController enemy, StateMachine stateMachine) 
        : base (stateMachine, enemy) { }

    public override void Enter()
    {
        enemy.animator.Play("Walk");
        _radiusSquared = _detectionRadius * _detectionRadius;
    }

    public override void Exit()
    {
        
    }

    public override void FrameUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        if (enemy.PlayerTransform == null) return;

        Vector3 distance = enemy.transform.position - enemy.PlayerTransform.position;

        if(distance.sqrMagnitude < _radiusSquared) 
        {
            enemy.StateMachine.ChangeState(enemy.StateMachine.ArmoredState);
        }
    }
}
