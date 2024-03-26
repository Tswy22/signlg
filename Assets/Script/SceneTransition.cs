using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string[] transitionScenes;
    [SerializeField] private Vector2[] playerPositionsAfterTransition;
    [SerializeField] private string doorIdentifier; // Add an identifier for the door

    private GameObject player;

    private void Awake()
    {
        // Find the player in the scene and cache it
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int doorIndex = GetDoorIndex(doorIdentifier);
            if (doorIndex >= 0)
            {
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene(transitionScenes[doorIndex]);
            }
        }
    }

    private int GetDoorIndex(string identifier)
    {
        for (int i = 0; i < transitionScenes.Length; i++)
        {
            if (transitionScenes[i].Contains(identifier))
            {
                return i;
            }
        }
        return -1; // Return -1 if the identifier is not found
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the event

        int sceneIndex = GetSceneIndex(scene.name);
        if (sceneIndex >= 0)
        {
            player.transform.position = playerPositionsAfterTransition[sceneIndex];
        }
    }

    private int GetSceneIndex(string sceneName)
    {
        for (int i = 0; i < transitionScenes.Length; i++)
        {
            if (transitionScenes[i] == sceneName)
            {
                return i;
            }
        }
        return -1; // Return -1 if the scene name is not found
    }
}
