using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform Player;
    Rigidbody2D Rigidbody;
    float Hmovement;
    float Vmovement;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Transform>(); 
        Rigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Hmovement = Input.GetAxis("Horizontal");
        Vmovement = Input.GetAxis("Vertical");

        Move();
    }

    public void Move()
    {
        Rigidbody.velocity = new Vector2(Hmovement,Vmovement);
    }
}
