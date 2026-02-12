using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 2f;
    public float distancia = 3f;
    
    private Vector3 posicionInicial;
    private Vector3 posicionPrevia;
    private int direccion = 1; // 1 para arriba, -1 para abajo
    private GameObject jugadorEncima;

    void Start() {
        posicionInicial = transform.position;
        posicionPrevia = transform.position;
    }

    void FixedUpdate() {
        // 1. Mover la plataforma
        MoverPlataforma();

        // 2. Si el jugador está encima, moverlo verticalmente con ella
        if (jugadorEncima != null) {
            Vector3 movimientoPlataforma = transform.position - posicionPrevia;
            jugadorEncima.transform.position += movimientoPlataforma;
        }

        posicionPrevia = transform.position;
    }

    void MoverPlataforma() {
        // Límites basados en la Y inicial
        float limiteSuperior = posicionInicial.y + distancia;
        float limiteInferior = posicionInicial.y;

        // Movimiento vertical
        transform.Translate(Vector2.up * direccion * velocidad * Time.fixedDeltaTime);

        // Cambiar dirección al tocar límites
        if (transform.position.y >= limiteSuperior) {
            direccion = -1;
        }
        else if (transform.position.y <= limiteInferior) {
            direccion = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            jugadorEncima = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            jugadorEncima = null;
        }
    }
}