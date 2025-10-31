using UnityEngine;

public class AnimationEvenetRelay : MonoBehaviour 
{
    EnemyController enemy;
    Animator animator;

    private void Awake()
    {
        enemy = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
    }

    public void Armored() 
    {
        animator.SetBool("Armored", true);
    }
}
