using UnityEngine;
using UnityEngine.UI;

public class WebcamController : MonoBehaviour
{
    public RawImage rawImage; // Assign this in the inspector

    private WebCamTexture webcamTexture;

    void Start()
    {
        // Initialize the WebCamTexture, but don't start it yet
        webcamTexture = new WebCamTexture();

        // Assign the texture to the RawImage component for when it starts
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
    }

    public void StartWebcam()
    {
        // This will start the webcam if it's not already playing
        if (webcamTexture != null && !webcamTexture.isPlaying)
        {
            webcamTexture.Play();
            Debug.Log("Camera started");
        }
    }

    public void StopWebcam()
    {
        // This will stop the webcam if it's playing
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
            Debug.Log("Camera stopped");
        }
    }
}
