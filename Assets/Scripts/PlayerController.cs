using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rickeesBody;
    [SerializeField] float spinFactor = 0.18f;
    [SerializeField] float spinDirection = 0f;
    [SerializeField] float boostedSpeed = 20f;
    [SerializeField] float baseSpeed = 10f;
    SurfaceEffector2D surfaceEffector2D;
    PolygonCollider2D rickeesCollider;
    EdgeCollider2D surfaceCollider;
    Collider2D[] contacts;
    ContactFilter2D contactFilter;
    // Start is called before the first frame update
    void Start()
    {
        rickeesBody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        rickeesCollider = GetComponent<PolygonCollider2D>();
        surfaceCollider = surfaceEffector2D.GetComponent<EdgeCollider2D>();
        contactFilter = new ContactFilter2D();
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
        PreventStick();

    }

    private void PreventStick()
    {
        surfaceCollider.GetContacts(contacts);
        contactFilter.NoFilter();
        int numberOfContacts = surfaceCollider.OverlapCollider(contactFilter, contacts);
        if(numberOfContacts > 0)
        {
            rickeesBody.transform.position = surfaceCollider.ClosestPoint(new Vector2(rickeesBody.transform.position.x, rickeesBody.transform.position.y));
        }
    }

    void RotatePlayer()
    {
        spinDirection = Input.GetAxis("Horizontal");
        if (spinDirection != 0)
        {
            rickeesBody.AddTorque(spinFactor * -spinDirection);
        }
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
           surfaceEffector2D.speed = boostedSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
