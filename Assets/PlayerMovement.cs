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
        // --- MOVIMIENTO ---
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Actualizamos el Float "Speed" para la Run Animation
        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        // Girar el sprite
        if (moveInput > 0) transform.localScale = new Vector3(4, 4, 4);
        else if (moveInput < 0) transform.localScale = new Vector3(-4, 4, 4);

        // --- SALTO Y DOBLE SALTO ---
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

        // --- PARÁMETROS DEL ANIMATOR ---
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);

        // --- DISPARO (Shoot Animation) ---
        // Cambiamos el nombre del trigger en el código para que sea idéntico al Animator
        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("Shoot"); 
        }
    }

    void ExecuteJump() {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        // Disparamos el trigger para reiniciar la Jump Animation
        anim.SetTrigger("Jump"); 
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }
}