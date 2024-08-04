using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //获取Score并显示
        int score = PlayerPrefs.GetInt("Score", 0);
        GetComponent<UnityEngine.UI.Text>().text = "Score: "+score.ToString();
    }

    
}
