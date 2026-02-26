using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public SceneController sceneController;
    public void Play()
    {
        LoadScene(sceneToLoad);
    }

    public void LoadScene(string scene)
    {
        sceneController.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
