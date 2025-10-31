using UnityEngine;

public class AnimationEvenetRelay : MonoBehaviour 
{
    EnemyController enemy;
    Animator animator;
    ChestController chest;

    private void Awake()
    {
        enemy = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
        chest = GetComponent<ChestController>();
    }

    public void Armored() 
    {
        animator.SetBool("Armored", true);
    }

    public void Unarmored()
    {
        animator.SetBool("Armored", false);
    }

    public void ChestIsOpen() 
    {
        chest.isOpen = true;
    }
}
