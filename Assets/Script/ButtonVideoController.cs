using UnityEngine;
using UnityEngine.Video; // This is necessary for VideoPlayer
using UnityEngine.UI; // This is necessary for UI components like Button

public class ButtonVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign your VideoPlayer in the Inspector
    public Button hellobutton;       // Assign your Button in the Inspector
    public VideoClip newClip;       // Assign the new VideoClip in the Inspector
    private WebCamTexture webcamTexture;

    void Start()
    {
        if(WebCamTexture.devices.Length > 0)
        {
            webcamTexture = new WebCamTexture();
        }
        else
        {
            Debug.Log("No camera detected");
        }
        // Register the onClick event on the button
        hellobutton.onClick.AddListener(ChangeVideo);
        hellobutton.onClick.AddListener(ToggleWebcam);
    }

    void ChangeVideo()
    {
        if (videoPlayer != null && newClip != null)
        {
            videoPlayer.clip = newClip;
            videoPlayer.Play();
        }
    }
    void ToggleWebcam()
    {
        // This will either start or stop the webcam depending on its current state
        if (webcamTexture != null)
        {
            if (webcamTexture.isPlaying)
            {
                webcamTexture.Stop();
                Debug.Log("Camera stopped");
            }
            else
            {
                webcamTexture.Play();
                Debug.Log("Camera started");
            }
        }
    }
}
