using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public struct SceneTransitionInfo
{
    public string tag;
    public string sceneName;
    public Vector2 spawnPosition;
}

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private SceneTransitionInfo[] transitions;

    // Static variables to retain the spawn position between scenes
    public static Vector2 nextSpawnPosition;
    private static bool shouldSpawnAtPosition = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var transition in transitions)
            {
                if (this.CompareTag(transition.tag))
                {
                    // Set the static variables
                    nextSpawnPosition = transition.spawnPosition;
                    shouldSpawnAtPosition = true;

                    // Load the new scene
                    SceneManager.LoadScene(transition.sceneName);
                    break;
                }
            }
        }
    }

    public static void SpawnPlayerAtPosition(GameObject player)
    {
        if (shouldSpawnAtPosition)
        {
            player.transform.position = nextSpawnPosition;
            shouldSpawnAtPosition = false;
        }
    }
}
