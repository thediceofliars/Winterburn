using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    Scene currentLevel;
    [SerializeField] string currentLevelName;
    ParticleSystem finishParticles;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene();
        currentLevelName = currentLevel.name;
        finishParticles = GameObject.Find("Finish Line").GetComponentInChildren<ParticleSystem>();
        
    }

    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Rickee")
        {
            finishParticles.Play();
            Invoke("ReloadScene", 5f);
            //StartCoroutine("ReloadScene", currentLevelName);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(currentLevelName);
    }
}
