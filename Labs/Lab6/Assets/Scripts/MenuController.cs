using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Small behaviour to handle menu button callbacks.
 */
public class MenuController : MonoBehaviour
{
    
    /*
     * When the start button is pressed, load the Game scene.
     */
    public void OnStartClicked()
    {
        SceneManager.LoadScene("Game");
    }

    /*
     * When the back button is clicked, load the Menu scene.
     */
    public void OnBackClicked()
    {
    SceneManager.LoadScene("Menu");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
    
    public void OnSettingsClicked()
    {
        SceneManager.LoadScene("Settings");
    }
}