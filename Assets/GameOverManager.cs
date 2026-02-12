using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar escenas

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver() {
        gameOverPanel.SetActive(true); // Muestra el panel
        Time.timeScale = 0f;          // Pausa el juego
    }

    public void RestartGame() {
        Time.timeScale = 1f;          // Reanuda el tiempo antes de cargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Esto solo funciona en el juego exportado (.exe)
    }
}