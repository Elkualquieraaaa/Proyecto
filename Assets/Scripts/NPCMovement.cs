using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] List<Transform> points = new List<Transform>();
    [SerializeField] float speed;
    private int movement = 0;
    [SerializeField] float pauseTime;
    private float timer = 0;
    private bool isPaused = false;

    void Update()
    {

        MovementPoints();
    }

    public void MovementPoints()
    {
        if (!isPaused)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[movement].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[movement].position) < 0.1f)
            {
                isPaused = true;
                timer = Time.time;
            }
        }
        else if (Time.time - timer >= pauseTime)
        {
            isPaused = false;
            movement++;
            movement %= points.Count;
        }


    }
}
