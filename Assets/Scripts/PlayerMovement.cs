using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform PlayerDetector;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject player;
    [SerializeField] float radius;
    [SerializeField] float velocity;
    [SerializeField] float velocitY;
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;
    float Hmovement;
    float Vmovement;
    float normalvelocity;
    Collider2D colider;
    Collider2D hideout;
    bool hide;
    // Start is called before the first frame update

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        normalvelocity = velocity;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<GameObject>();
        colider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hideout = Physics2D.OverlapCircle(PlayerDetector.position, radius, layerMask);

        Hmovement = (Input.GetAxis("Horizontal") * velocity);
        Vmovement = (Input.GetAxis("Vertical") * velocity);
        if (hide != true)
        {
            Move();
        }
        Run();
        Hide();

        velocitY = Rigidbody.velocity.y;
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
    public void Hide()
    {
        if (hideout != null && Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.enabled = false;
            hide = true;
            Rigidbody.velocity = new Vector2(0, 0);
            gameObject.layer = LayerMask.GetMask("default");
            colider.enabled = false;
            Debug.Log(gameObject.layer);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spriteRenderer.enabled = true;
            hide = false;
            gameObject.layer = LayerMask.GetMask("TransparentFX");
            colider.enabled = true;
            Debug.Log(gameObject.layer);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PlayerDetector.position, radius);
    }
}
