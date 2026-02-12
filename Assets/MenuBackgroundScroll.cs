using UnityEngine;

public class MenuBackgroundScroll : MonoBehaviour
{
    public float speed = 10f; // Aumentamos la velocidad para que sea obvio

    void Update()
    {
        // Movimiento simple y directo
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si se aleja demasiado (ej. -50), lo mandamos al otro lado (50)
        // Esto es solo para probar que se mueve
        if (transform.position.x < -50f)
        {
            transform.position = new Vector3(50f, transform.position.y, transform.position.z);
        }
    }
}