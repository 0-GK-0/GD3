using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public SceneController sceneController;

    private void Start()
    {
        if(sceneController == null) sceneController = GameObject.FindWithTag("SceneController").GetComponent<SceneController>();
    } 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) LoadScene(sceneToLoad);
    }
    public void LoadScene(string scene)
    {
        sceneController.LoadScene(scene);
    }
}
