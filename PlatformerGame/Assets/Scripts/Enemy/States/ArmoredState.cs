using UnityEngine;

public class ArmoredState : BaseState
{
    float _detectionRadius = 3f;
    float _radiusSquared;
    public ArmoredState(EnemyController enemy, StateMachine stateMachine)
        : base(stateMachine, enemy) { }

    public override void Enter()
    {
        _radiusSquared = _detectionRadius * _detectionRadius;
        Debug.Log("Armored");
        enemy.animator.SetTrigger("Start Defending");
    }

    public override void Exit()
    {
        enemy.animator.ResetTrigger("Start Defending");
        enemy.animator.SetTrigger("Stop Defending");
    }

    public override void FrameUpdate()
    {
        if (enemy.PlayerTransform == null) return;

        Vector3 distance = enemy.PlayerTransform.position - enemy.transform.position;

        if (distance.sqrMagnitude > _radiusSquared)
        {
            enemy.StateMachine.ChangeState(enemy.StateMachine.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
