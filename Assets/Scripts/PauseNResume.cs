using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseNResume : MonoBehaviour
{
    //Pause & Resume
    [SerializeField] public GameObject pause;
    [SerializeField] public GameObject resume;
    public TextMeshProUGUI pauseText;

    private void Start()
    {
        //print("Start");
        pauseText.gameObject.SetActive(false);
        pauseText.text = "";
        resume.SetActive(false);
        pause.SetActive(true);
    }
    public void PauseGame()
    {
        //print("Pause");        
        pauseText.gameObject.SetActive(true);
        pauseText.text = "PAUSE";
        resume.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        //print("Resume");        
        pauseText.gameObject.SetActive(false);
        pauseText.text = "";
        resume.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
