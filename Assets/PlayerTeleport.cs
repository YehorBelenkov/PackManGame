using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject teleport3;
    public GameObject teleport4;
    public float teleportCooldown = 10f;

    private bool canTeleport = true;
    private float lastTeleportTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (canTeleport)
        {
            if (collision.gameObject == teleport1)
            {
                TeleportTo(teleport2);
            }
            else if (collision.gameObject == teleport2)
            {
                TeleportTo(teleport1);
            }
            else if (collision.gameObject == teleport3)
            {
                TeleportTo(teleport4);
            }
            else if (collision.gameObject == teleport4)
            {
                TeleportTo(teleport3);
            }
        }
    }

    private void TeleportTo(GameObject targetTeleport)
    {
        lastTeleportTime = Time.time;
        Debug.Log($"Player teleported from {gameObject.name} to {targetTeleport.name}");
        transform.position = targetTeleport.transform.position;
        canTeleport = false;
        Invoke("ResetTeleportCooldown", teleportCooldown);
    }

    private void ResetTeleportCooldown()
    {
        canTeleport = true;
    }
}