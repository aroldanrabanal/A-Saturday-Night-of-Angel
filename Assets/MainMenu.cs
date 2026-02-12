using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de nivel

public class MainMenu : MonoBehaviour
{
    public void LoadLevel1()
    {
        // Carga la escena por su nombre exacto
        SceneManager.LoadScene("Nivel1");
    }

    public void LoadLevel2()
    {
        // Carga la escena del Nivel 2 (asegúrate de que se llame así)
        SceneManager.LoadScene("Nivel2");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}