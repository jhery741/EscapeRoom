
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private const string MovementVersion = "Caso03";

    private void Update()
    {
        Move();
        Debug.Log("Movement system active");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction key pressed");
        }
    }


    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0f, v);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
