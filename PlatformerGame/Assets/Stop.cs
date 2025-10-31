using UnityEngine;

public class Stop : StateMachineBehaviour
{
    EnemyController enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy == null) enemy.GetComponent<EnemyController>();
        
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.moveSpeed = 0f;
    }
}
