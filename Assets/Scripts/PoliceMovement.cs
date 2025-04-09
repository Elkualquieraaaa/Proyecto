using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PenduloEnemigo : MonoBehaviour
{
    [SerializeField] Transform target1, target2; 
    private Transform currentTarget;
    public float Speed;

    public float detectionRadius; 
    public LayerMask playerLayer; 
    private Transform player;

    public string gameOverSceneName = "MainMenu"; 

    void Start()
    {
        currentTarget = target1; 
    }

    void Update()
    {
        
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (hits.Length > 0)
        {
            
            player = hits[0].transform;
        }
        else
        {
            
            player = null;
        }

        
        if (player != null)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Speed * Time.deltaTime);

            if (transform.position == currentTarget.position)
            {
                currentTarget = currentTarget == target1 ? target2 : target1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

