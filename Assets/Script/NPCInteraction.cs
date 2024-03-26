using UnityEngine;
using UnityEngine.Video; // ต้องใช้สำหรับ VideoPlayer

public class NPCInteraction : MonoBehaviour
{
    public GameObject popupPanel;
    public VideoPlayer videoPlayer; // อ้างอิงถึง VideoPlayer ที่อยู่ใน Popup
    public float interactionRange = 3f;
    public Transform playerTransform;
    private WebCamTexture webcamTexture;
    public WebcamController webcamController;

    void Start()
    {
        // Initialize the WebCamTexture without starting it.
        webcamTexture = new WebCamTexture();
        // เพิ่ม VideoPlayer หากจำเป็น
    }

    void Update()
    {
        // Check if the player is in range and presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            // Toggle the popup panel's active state
            popupPanel.SetActive(!popupPanel.activeSelf);
            
            // If the popup panel is now inactive, stop the webcam and the video
            if (!popupPanel.activeSelf)
            {

                if (videoPlayer.isPlaying)
                {
                    videoPlayer.Stop();
                    Debug.Log("Video stopped because the popup is closed.");
                }
            }
        }
    }

    bool IsPlayerInRange()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform not assigned!");
            return false;
        }
        return Vector3.Distance(transform.position, playerTransform.position) <= interactionRange;
    }
    void TogglePopup()
{
    bool isPopupActive = popupPanel.activeSelf;
    popupPanel.SetActive(!isPopupActive);

    // When the popup is deactivated, also stop the webcam.
    if (!isPopupActive)
    {
        webcamController.StopWebcam();
    }
}

}
