using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int prevRoomIndex = PlayerPrefs.GetInt("Previous Room", 1);
        SceneManager.LoadScene(prevRoomIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
