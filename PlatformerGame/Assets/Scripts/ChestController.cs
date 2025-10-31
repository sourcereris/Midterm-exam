using UnityEngine;

public class ChestController : MonoBehaviour
{
    Animator animator;

    public bool isOpening { get; set; } = false;
    public bool isOpen { get; set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening) animator.SetBool("Opening", true);
        if (isOpen) animator.SetBool("Open", true);
    }
}
