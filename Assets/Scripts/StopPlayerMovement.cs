using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopPlayerMovement : MonoBehaviour
{
    SurfaceEffector2D snowSurfaceEffector;
    [SerializeField] GameObject snowSurface;
    // Start is called before the first frame update
    void Start()
    {
        snowSurface = GameObject.FindGameObjectWithTag("Ground");
        snowSurfaceEffector = snowSurface.GetComponent<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CrashDetection.isGameOver)
        {
            Debug.Log("Game is Over!");
            snowSurfaceEffector.forceScale = 0;
        }
    }
}
