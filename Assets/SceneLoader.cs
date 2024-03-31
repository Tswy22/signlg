using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This public variable will be set from the inspector to determine which scene to load.
    public string sceneToLoad;

    public void LoadScene()
    {
        // Load the scene with the name specified in the sceneToLoad variable.
        SceneManager.LoadScene(sceneToLoad);
    }
}
