using UnityEngine;

/*
 * On screen HUD to display current health.
 */
public class PlayerHud : MonoBehaviour
{
    private Texture2D _halfHeart;
    private Texture2D _heart;
    private PlayerController _playerController;

    /*
     * Load and store the heart images and cache the PlayerController
     * component for later.
     */
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _heart = Resources.Load<Texture2D>("heart");
        _halfHeart = Resources.Load<Texture2D>("halfHeart");
    }

    /*
     * Using the current health from the PlayerController, display the
     * correct number of hearts and half hearts.
     */
    private void OnGUI()
    {
        int health = _playerController.GetHealth();
        int fullHearts = health / 2;
        bool halfHeart = health % 2 == 1;

        for (int i = 0; i < fullHearts; i++)
        {
            GUI.DrawTexture(new Rect(10 + i * 50, 10, 50, 50), _heart);
        }

        if (halfHeart)
        {
            GUI.DrawTexture(new Rect(10 + fullHearts * 50, 10, 50, 50), _halfHeart);
        }
        
        //Draw the score with black color
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 70, 100, 50), "Score: " + _playerController.GetScore().ToString(), new GUIStyle()
        {
            fontSize = 30,
            fontStyle = FontStyle.Bold,
        });
    }
}