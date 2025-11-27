using UnityEngine;

public class TogglePause : MonoBehaviour
{
    public CanvasGroup pauseCanvas;
    private bool pauseOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("TogglePause"))
        {
            if (pauseOpen)
            {
                Time.timeScale = 1;
                pauseCanvas.alpha = 0;
                pauseCanvas.blocksRaycasts = false;
                pauseOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseCanvas.alpha = 1;
                pauseOpen = true;
                pauseCanvas.blocksRaycasts = true;
            }
        }
    }
}
