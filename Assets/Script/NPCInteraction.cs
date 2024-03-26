using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject popupPanel;
    public float interactionRange = 3f;
    public Transform playerTransform;

    void Update()
    {
        // Check if the player is in range and presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            TogglePopup();
        }
    }

    bool IsPlayerInRange()
    {
        // Check if the player is within the interaction range of the NPC
        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform not assigned!");
            return false;
        }

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance <= interactionRange;
    }

    void TogglePopup()
    {
        // Toggle the active state of the popup panel
        popupPanel.SetActive(!popupPanel.activeSelf);
    }
}
