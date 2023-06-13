using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Update()
    {
        // Rotate the coin object around its own Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PackMan"))
        {
            // Coin collided with the player, delete the coin object
            Destroy(gameObject);
        }
    }
}