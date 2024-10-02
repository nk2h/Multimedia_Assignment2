using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameoverDistanceText;
    public TextMeshProUGUI gameoverFuelCollectedText;

    // Update is called once per frame
    private void Update()
    {
        gameoverDistanceText.text = HeroScript.distance.ToString() + "M";
        gameoverFuelCollectedText.text = HeroScript.fuelCollected.ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
