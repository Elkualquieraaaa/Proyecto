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
        // Detectar al jugador usando física 2D
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (hits.Length > 0)
        {
            // Si hay colisión, apuntar al jugador
            player = hits[0].transform;
        }
        else
        {
            // Si no hay colisión, deshabilitar seguimiento al jugador
            player = null;
        }

        // Movimiento del enemigo
        if (player != null)
        {
            // Seguir al jugador si está detectado
            transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        }
        else
        {
            // Moverse entre puntos (target1 y target2) si el jugador no está cerca
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
            // Cambiar a la escena de Game Over
            SceneManager.LoadScene("MainMenu");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualizar el radio de detección
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

