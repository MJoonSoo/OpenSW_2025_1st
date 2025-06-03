using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }
}
