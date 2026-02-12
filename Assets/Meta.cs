using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Carga la siguiente escena por su nombre
            SceneManager.LoadScene("Nivel2"); 
        }
    }
}