using UnityEngine;
using UnityEngine.InputSystem; //implementação de bibliotecas

public class playerMoment : MonoBehaviour //principal classe
{
    [SerializeField]private float moveSpeed = 5f; //é a linha de velocidade do personagem, quanto mais longe do 0, + rápido vai andar
    private Rigidbody2D rd; //pra aplicar física 2d
    private Vector2 moveInput; 
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rd.linearVelocity = moveInput * moveSpeed;

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
            animator.SetBool("isWalking", true);
    }
        else
        {
            animator.SetBool("isWalking", false);
        }
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        }
        
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); 
    }
    
}
