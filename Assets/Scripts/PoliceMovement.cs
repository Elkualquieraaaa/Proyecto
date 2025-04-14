using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PenduloEnemigo : MonoBehaviour
{
    [SerializeField] Transform target1, target2;
    [SerializeField] private Transform currentTarget;
    public float Speed;

    public float detectionRadius;
    public LayerMask playerLayer;
    private Transform player;

    public GameOverManager gameOverManager;

    NavMeshAgent agent;
    void Start()
    {
        currentTarget = target1;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {

        // Movimiento del enemigo
        if (PlayerIsNear())
        {
            // Seguir al jugador si está detectado
            agent.enabled = true;
            agent.SetDestination(player.position);
        }
        else
        {
            // Moverse entre puntos (target1 y target2) si el jugador no está cerca
            agent.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, currentTarget.position) <= 0.5f)
            {
                currentTarget = currentTarget == target1 ? target2 : target1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiar a la escena de Game Over
            gameOverManager.ShowGameOver();
        }
    }
    bool PlayerIsNear()
    {
        // Detectar al jugador usando física 2D
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (hit != null)
        {
            player = hit.transform;
            return true;
        }
        else
        {
            return false;
        }

    }

    void OnDrawGizmosSelected()
    {
        // Visualizar el radio de detección
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

