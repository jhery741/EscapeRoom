
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
        Debug.Log("Puerta bloqueada. Busca la llave para escapar.");
    }
    else
    {
        Debug.Log("¡Felicidades! Has escapado de la habitación.");
        gameObject.SetActive(false);
    }
}

}
