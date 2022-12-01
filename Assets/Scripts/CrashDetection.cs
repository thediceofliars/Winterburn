using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] Canvas gameOverTextCanvas;
    public static bool isGameOver = false;
    [SerializeField] TMP_Text gameOverText;

        Scene currentLevel;
    [SerializeField] string currentLevelName;
    [SerializeField] ParticleSystem crashParticles;

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        isGameOver = false;
        currentLevel = SceneManager.GetActiveScene();
        currentLevelName = currentLevel.name;
        
        gameOverTextCanvas = GameObject.Find("GameOverText").GetComponent<Canvas>();
        gameOverText = GameObject.Find("Text").GetComponent<TMP_Text>();
        gameOverTextCanvas.enabled = false;
        crashParticles = GameObject.Find("Rickee").GetComponentsInChildren<ParticleSystem>()[1];
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGameOver = true;
            crashParticles.Play();
            Debug.Log("OWCH!");
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(isGameOver)
        {
            
            Invoke("ReloadScene", 5f);

            gameOverTextCanvas.enabled = true;

            gameOverText.transform.Rotate(0, 0, 100 * Time.deltaTime);

        }
         
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(currentLevelName);
    }
}
