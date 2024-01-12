using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{

    public float speed;
    public Vector3 movementDirection;
    public float moveDuration;

    public AudioSource audio;

    private bool isMoving;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Apply movement.
            transform.position += movementDirection * speed * Time.fixedDeltaTime;
        }
        
    }

    public void StartMove()
    {
        audio.Play();
        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        isMoving = true;

        yield return new WaitForSeconds(moveDuration);

        isMoving = false;
    }
}
