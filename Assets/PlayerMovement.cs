using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    
    [Header("Doble Salto")]
    private int extraJumps;
    public int extraJumpsValue = 1; 

    private Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
    }

    void Update() {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0) transform.localScale = new Vector3(4, 4, 4);
        else if (moveInput < 0) transform.localScale = new Vector3(-4, 4, 4);

        if (isGrounded) {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump")) {
            if (isGrounded) {
                ExecuteJump();
            } else if (extraJumps > 0) {
                ExecuteJump();
                extraJumps--;
            }
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);

        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("Shoot"); 
        }
    }

    void ExecuteJump() {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        anim.SetTrigger("Jump"); 
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }
}