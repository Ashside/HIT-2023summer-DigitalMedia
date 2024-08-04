using UnityEngine;
using UnityEngine.UI;

public class SettingMenuController : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle easyToggle;
    public Toggle mediumToggle;
    public Toggle hardToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 100f);
        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);
        if (difficulty == 0)
        {
            easyToggle.isOn = true;
        }
        else if (difficulty == 1)
        {
            mediumToggle.isOn = true;
        }
        else if (difficulty == 2)
        {
            hardToggle.isOn = true;
        }
    }
    
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        if (easyToggle.isOn)
        {
            PlayerPrefs.SetInt("Difficulty", 0);
        }
        else if (mediumToggle.isOn)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
        }
        else if (hardToggle.isOn)
        {
            PlayerPrefs.SetInt("Difficulty", 2);
        }
        // 在UELOG中打印出当前的游戏音量和难度
        Debug.Log("Game Volume: " + PlayerPrefs.GetFloat("GameVolume", 100f));
        Debug.Log("Difficulty: " + PlayerPrefs.GetInt("Difficulty", 1));
        
    }
    
}
