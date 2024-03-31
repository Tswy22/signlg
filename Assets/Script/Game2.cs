using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    public VideoPlayer[] videoPlayers; // Array to hold multiple VideoPlayers
    public Button hellobutton;       // Assign your Button in the Inspector
    public VideoClip[] newClips;       // Assign the new VideoClips in the Inspector
    public GameObject popupPanel; // Assign your popupPanel in the Inspector

    void Start()
    {
        // Register the onClick event on the button
        hellobutton.onClick.AddListener(ChangeVideos);
    }

    void ChangeVideos()
    {
        // Check if there are enough VideoPlayers and VideoClips
        if (videoPlayers.Length == newClips.Length)
        {
            // Iterate through each VideoPlayer and assign VideoClip to play
            for (int i = 0; i < videoPlayers.Length; i++)
            {
                if (videoPlayers[i] != null && newClips[i] != null)
                {
                    videoPlayers[i].clip = newClips[i];
                    videoPlayers[i].Play();
                }
            }

            // Open the popupPanel
            if(popupPanel != null)
            {
                popupPanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Number of VideoPlayers does not match number of VideoClips.");
        }
    }
}
