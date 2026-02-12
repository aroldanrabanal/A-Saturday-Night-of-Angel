using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    
    // Referencia al Animator
    private Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Buscamos el Animator al empezar
    }

    void Update() {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // --- ANIMACIÓN DE CAMINAR ---
        // Usamos Abs para que siempre sea positivo. Si es > 0, camina.
        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0) transform.localScale = new Vector3(4, 4, 4);
        else if (moveInput < 0) transform.localScale = new Vector3(-4, 4, 4);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // --- ANIMACIÓN DE SALTO ---
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);

        // --- ANIMACIÓN DE DISPARO ---
        if (Input.GetButtonDown("Fire1")) {
            anim.SetTrigger("Shoot");
        }

    }

private void OnCollisionStay2D(Collision2D collision) 
    {
        // Usamos Stay en lugar de Enter para que detecte el suelo constantemente
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = false;
        }
    }
}