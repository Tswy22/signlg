using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public Text indexText;
    public Text labelText;
    public Text amountText;
    public Text chanceText;
    public GameObject popupPanel; // Make sure to assign this in the inspector
    public RawImage rawImage;

     private WebCamTexture webcamTexture;

    // Call this method to show the popup with the given values
    public void ShowPopup(int index, string label, float amount, float chance)
    {
        indexText.text = "Index: " + index.ToString();
        labelText.text = " " + label;
        amountText.text = "Amount: " + amount.ToString();
        chanceText.text = "Chance: " + chance.ToString() + "%";

        if (webcamTexture == null)
        {
            webcamTexture = new WebCamTexture();
        }
        webcamTexture.Play();

        // Assign the webcam texture to a RawImage component on your popup if you want to display the webcam feed
        // Example:
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;

        popupPanel.SetActive(true); // Show the popup
    }

    // You can call this method from a button's OnClick event to close the popup
    public void ClosePopup()
    {   
        // Stop the webcam if it's running
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
        popupPanel.SetActive(false);
    }
}
