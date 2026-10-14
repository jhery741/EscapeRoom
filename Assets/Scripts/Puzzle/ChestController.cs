
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Transform player;
    public OldDoorController door;
    public float interactionDistance = 2.5f;
    public string correctCode = "1234";

    private bool showCodeInput = false;
    private bool chestOpened = false;
    private string enteredCode = "";

    void Update()
    {
        if (player == null || chestOpened)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(
                transform.position, player.position
            );

            if (distance <= interactionDistance)
            {
                showCodeInput = !showCodeInput;
                enteredCode = "";
                Cursor.lockState = showCodeInput
                    ? CursorLockMode.None
                    : CursorLockMode.Locked;
                Cursor.visible = showCodeInput;
            }
        }
    }

    void OnGUI()
    {
        if (!showCodeInput)
            return;

        float x = Screen.width / 2f - 150f;
        float y = Screen.height / 2f - 75f;

        GUI.Box(new Rect(x, y, 300, 150), "Cofre cerrado");

        GUI.Label(
            new Rect(x + 20, y + 35, 260, 25),
            "Introduce el codigo secreto:"
        );

        enteredCode = GUI.TextField(
            new Rect(x + 20, y + 65, 260, 25),
            enteredCode, 4
        );

        if (GUI.Button(new Rect(x + 20, y + 105, 125, 30), "Abrir"))
        {
            TryOpenChest();
        }

        if (GUI.Button(new Rect(x + 155, y + 105, 125, 30), "Cerrar"))
        {
            CloseInput();
        }
    }

    void TryOpenChest()
    {
        if (enteredCode == correctCode)
        {
            chestOpened = true;
            Debug.Log("Codigo correcto. Has conseguido la llave.");

            if (door != null)
                door.isLocked = false;

            CloseInput();
        }
        else
        {
            Debug.Log("Codigo incorrecto. Intentalo otra vez.");
            enteredCode = "";
        }
    }

    void CloseInput()
    {
        showCodeInput = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
