using UnityEngine;
using UnityEngine.UI;

public class Webcamgame : MonoBehaviour
{
    public RawImage rawImage; // Assign this in the inspector

    private WebCamTexture webcamTexture;

    public void StartWebcam()
    {
        // This will start the webcam if it's not already playing
        if (webcamTexture != null && !webcamTexture.isPlaying)
        {
            webcamTexture = new WebCamTexture();

            rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
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
