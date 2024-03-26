using UnityEngine;
using UnityEngine.Video; // This is necessary for VideoPlayer
using UnityEngine.UI; // This is necessary for UI components like Button

public class ButtonVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign your VideoPlayer in the Inspector
    public Button hellobutton;       // Assign your Button in the Inspector
    public VideoClip newClip;       // Assign the new VideoClip in the Inspector

    void Start()
    {
        // Register the onClick event on the button
        hellobutton.onClick.AddListener(ChangeVideo);
    }

    void ChangeVideo()
    {
        if (videoPlayer != null && newClip != null)
        {
            videoPlayer.clip = newClip;
            videoPlayer.Play();
        }
    }
}
