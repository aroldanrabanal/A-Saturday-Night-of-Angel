using UnityEngine;

public class MenuBackgroundScroll : MonoBehaviour
{
    public float speed = 0.5f; 
    private float width;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        // Calcula el ancho del sprite para saber cuándo repetir
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Mueve el fondo a la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el fondo se ha desplazado todo su ancho, vuelve a la posición inicial
        if (transform.position.x < startPos.x - width)
        {
            transform.position = startPos;
        }
    }
}