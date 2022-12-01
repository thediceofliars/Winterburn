using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticleEffect : MonoBehaviour
{
    ParticleSystem snowParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        snowParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CrashDetection.isGameOver)
        {
            snowParticleEffect.Stop();
        }
    }

        /// <summary>
    /// Sent each frame where a collider on another object is touching
    /// this object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.tag == "Ground")
        {
            snowParticleEffect.Play();
            Debug.Log("Staring the snow show!");
        }

    }

    /// <summary>
    /// Sent when a collider on another object stops touching this
    /// object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "Ground")
        {
            snowParticleEffect.Stop();
            Debug.Log("We're airborne!");
        }
    }
}
