using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadInsideHouseScene()
    {
        SceneManager.LoadScene("InsideHouseScene");
    }

    public void LoadInsideHouseScene2()
    {
        SceneManager.LoadScene("InsideHouseScene2");
    }

    // ... additional methods or functionality
}
