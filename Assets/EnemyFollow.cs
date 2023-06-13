using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;  // Reference to the player object
    public float moveSpeed = 5f;  // Speed at which the enemy moves

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Move the enemy towards the player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
