using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldAppear : MonoBehaviour
{
    public GameObject shield;

    void Start()
    {
        if (shield == null)
        {
            Debug.LogError("Inspector mo");
            return;
        }

        shield.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Input.GetButtonDown("s")) // Check Input System
        {
            shield.SetActive(true);
            Debug.Log("Shield Activated");
        }
        else
        {
            shield.SetActive(false);
            Debug.Log("Shield Deactivated");
        }
    }
}