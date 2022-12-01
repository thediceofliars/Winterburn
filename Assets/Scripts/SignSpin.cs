using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSpin : MonoBehaviour
{
    SpriteRenderer signSprite;
    [SerializeField] bool isTouched;
    // Start is called before the first frame update
    void Start()
    {   
        GameObject signpostObject = GameObject.Find("Signpost");
        signSprite = signpostObject.GetComponent<SpriteRenderer>();
    }

 /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Rickee")
        {
            isTouched = true;
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        
        if(isTouched)
        {
            signSprite.transform.Rotate(new Vector3(0,1,0),Space.Self);
        }
    }
}
