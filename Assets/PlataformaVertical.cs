using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 2f;
    public float distancia = 3f;
    
    private Vector3 posicionInicial;
    private Vector3 posicionPrevia;
    private int direccion = 1;
    private GameObject jugadorEncima;

    void Start() {
        posicionInicial = transform.position;
        posicionPrevia = transform.position;
    }

    void FixedUpdate() {
        MoverPlataforma();

        if (jugadorEncima != null) {
            Vector3 movimientoPlataforma = transform.position - posicionPrevia;
            jugadorEncima.transform.position += movimientoPlataforma;
        }

        posicionPrevia = transform.position;
    }

    void MoverPlataforma() {
        float limiteSuperior = posicionInicial.y + distancia;
        float limiteInferior = posicionInicial.y;

        transform.Translate(Vector2.up * direccion * velocidad * Time.fixedDeltaTime);

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