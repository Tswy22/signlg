using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoToRawImage : MonoBehaviour
{
public RawImage rawImage; // Assign this in the inspector
private VideoPlayer videoPlayer;

void Start()
{
    // Get the VideoPlayer component
    videoPlayer = GetComponent<VideoPlayer>();

    // Set the video to play. URL or path can be set here for external videos
    //videoPlayer.url = "Path to your video file here";

    // Set VideoPlayer event to call PrepareCompleted when video is prepared
    videoPlayer.prepareCompleted += PrepareCompleted;

    // Prepare the video
    videoPlayer.Prepare();
}

void PrepareCompleted(VideoPlayer vp)
{
    // Assign the Texture from Video to RawImage to be displayed
    rawImage.texture = vp.texture;

    // Play the video
    vp.Play();
}
}