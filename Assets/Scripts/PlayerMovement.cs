using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float mSpeed = 5f;
    private Rigidbody2D rB;
    private Vector2 mInput;
    private Animator animator;
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rB.linearVelocity = mInput * mSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", mInput.x);
            animator.SetFloat("LastInputY", mInput.y);
        }
            

        mInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", mInput.x);
        animator.SetFloat("InputY", mInput.y);
    }
}
