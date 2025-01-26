using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Additive); //garde la scene déja chargé et charge la nouvelle scene

    }
}
