using System.Collections;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    public bool isPaused = false;
    [SerializeField] public GameObject pauseMenu;

    private bool waiting;

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (!isPaused) 
            {
                isPaused = true;
                Pausing();
            }
            else
            {
                isPaused = false;
                Unpausing();
            }
        }
    }

    //Pause
    public void Pausing()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }
    public void Unpausing()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
    
    //Hitstop
    public void Hitstop(float stopDuration)
    {
        if(waiting) return;
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(stopDuration));
    }

    IEnumerator Wait(float stopDuration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(stopDuration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
}
