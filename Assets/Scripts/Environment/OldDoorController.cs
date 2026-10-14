
using UnityEngine;

public class OldDoorController : MonoBehaviour
{
    public bool isLocked = true;
    public float interactionDistance = 2.5f;
    public Transform player;

    void Update()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(
                transform.position,
                player.position
            );

            if (distance <= interactionDistance)
            {
                TryOpenDoor();
            }
        }
    }

    void TryOpenDoor()
    {
        if (isLocked)
        {
            Debug.Log("La puerta está cerrada. Necesitas una llave.");
        }
        else
        {
            Debug.Log("Puerta abierta. ¡Has escapado!");
            gameObject.SetActive(false);
        }
    }
}
