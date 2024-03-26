using UnityEngine;
using UnityEngine.UI; // This is necessary for UI components like Button
using UnityEngine.Video; // This is necessary for VideoPlayer

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Drag your VideoPlayer component here in the Inspector
    public VideoClip[] videoClips;  // Populate this array with your VideoClips in the Inspector

    // This method will be called by UI Buttons
    public void ChangeVideoClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < videoClips.Length)
        {
            videoPlayer.clip = videoClips[clipIndex];
            videoPlayer.Play();
        }
    }
}
