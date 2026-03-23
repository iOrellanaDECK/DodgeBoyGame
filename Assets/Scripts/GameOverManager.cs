using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Reanudar el juego
        SceneManager.LoadScene("MainMenu"); // Asegúrate que el nombre coincida
    }

    public void RetryGame()
{
    Time.timeScale = 1f; // Reanuda el tiempo
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
}
}
