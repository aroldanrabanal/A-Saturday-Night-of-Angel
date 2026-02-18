using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 3f;
    private Vector3 posicionInicial;
    private Vector3 posicionPrevia;
    private int direccion = -1;
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
        float limiteIzquierdo = posicionInicial.x - distancia;
        if (transform.position.x <= limiteIzquierdo) direccion = 1;
        else if (transform.position.x >= posicionInicial.x) direccion = -1;

        transform.Translate(Vector2.right * direccion * velocidad * Time.fixedDeltaTime);
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