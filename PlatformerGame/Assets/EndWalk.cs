using UnityEngine;

public class EndWalk : StateMachineBehaviour
{
    EnemyController enemy;
    float initialSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (enemy == null) 
        {
            enemy = animator.GetComponent<EnemyController>();
        }

        if (enemy != null)
        {
            initialSpeed = enemy.moveSpeed;
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy == null) return;

        float progress = stateInfo.normalizedTime;
        float newSpeed = Mathf.Lerp(initialSpeed, 0f, progress);

        enemy.moveSpeed = newSpeed;
        animator.SetFloat("Speed", newSpeed);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy == null) return;
        enemy.moveSpeed = initialSpeed;
    }
}
