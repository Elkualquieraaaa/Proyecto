using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    [SerializeField] Transform PlayerDetector;
    float Hmovement;
    float Vmovement;
    [SerializeField] float radius;
    [SerializeField] float velocity;
    float normalvelocity;
    Collider2D hideout;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        normalvelocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        hideout = Physics2D.OverlapCircle(PlayerDetector.position, radius);

        Hmovement = (Input.GetAxis("Horizontal") * velocity);
        Vmovement = (Input.GetAxis("Vertical") * velocity);

        Move();
        Run();
    }

    public void Move()
    {
        Rigidbody.velocity = new Vector2(Hmovement * Time.deltaTime, Vmovement * Time.deltaTime);
    }

    public void Run()
    {
        float newvelocity = (velocity / 1.2f + velocity);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocity = newvelocity;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocity = normalvelocity;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PlayerDetector.position, radius);
    }
}
