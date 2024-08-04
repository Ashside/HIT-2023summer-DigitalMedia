using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Behaviour to handle keyboard input and also store the player's
 * current health.
 */
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float jumpForce = 500f;
    public int health = 6;
    public int score = 0;
    
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip skateSound;
    public AudioClip coinSound;
    
    private bool _canJump;
    

    private Rigidbody2D _rigidbody2d;
    private AudioSource _audioSource;
    /*
     * Apply initial health and also store the Rigidbody2D reference for
     * future because GetComponent<T> is relatively expensive.
     */
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        
        GetDifficulty();
        GetVolume();
        
        _audioSource.clip = skateSound;
        _audioSource.loop = true;
        _audioSource.Play();
        
        
    }

    private void FixedUpdate()
    {
        //_rigidbody2d.velocity = new Vector2(playerSpeed, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_canJump)
            {
                _audioSource.Pause();
                _rigidbody2d.AddForce(new Vector2(0, jumpForce));
                _canJump = false;
                _audioSource.PlayOneShot(jumpSound);
                StartCoroutine(ResumeBackgroundMusic(jumpSound.length));
            }
        }
        transform.Translate(new Vector2(playerSpeed, 0) * Time.deltaTime);
    }

    /*
     * Poll keyboard for when the up arrow is pressed. If the player can jump
     * (is on the ground) then add force to the cached Rigidbody2D component.
     * Finally unset the canJump flag so the player has to wait to land before
     * another jump can be triggered.
     */
    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    

    /*
     * If the player has collided with the ground, set the canJump flag so that
     * the player can trigger another jump.
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        var coinObject = other.gameObject.GetComponent<CoinCollider>();
        if (coinObject != null)
        {
            return;
        }
        _canJump = true;
    }

    /*
     * Remove one health unit from player and if health becomes 0, change
     * scene to the end game scene.
     */
    public void Damage()
    {
        health -= 1;
        _audioSource.PlayOneShot(damageSound);
        score -= 100;
        score = Mathf.Clamp(score, 0, int.MaxValue);
        if (health < 1) SceneManager.LoadScene("EndGame");
    }

    /*
     * Accessor for health variable, used by he HUD to display health.
     */
    public int GetHealth()
    {
        return health;
    }
    
    IEnumerator ResumeBackgroundMusic(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.UnPause();
    }

    void GetDifficulty()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            var difficulty = PlayerPrefs.GetInt("Difficulty");
            UnityEngine.Debug.Log("Difficulty: " + difficulty);
            if (difficulty == 0) // easy
            {
                playerSpeed = 10f;
                health = 10;
                jumpForce = 500f;
            }
            else if (difficulty == 1) // normal
            {
                playerSpeed = 10f;
                health = 6;
                jumpForce = 500f;
            }
            else if (difficulty == 2) // hard
            {
                playerSpeed = 14f;
                health = 3;
                jumpForce = 550f;
            }
        }
    }
    void GetVolume()
    {
        if (PlayerPrefs.HasKey("GameVolume"))
        {
            _audioSource.volume= PlayerPrefs.GetFloat("GameVolume");
        }
    }

    public int GetScore()
    {
        return score;
    }
    public void Win()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("WinScene");
    }
    public void PickUpCoin()
    {
        score += 200;
        _audioSource.PlayOneShot(coinSound);
    }
}