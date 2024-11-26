using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject loseTab;
    public TMP_Text timeText;
    public TMP_Text loseText;
    float elapsedTime;
    // Define the screen boundary (you can adjust this based on your game)
    float minX, maxX, minY, maxY;

    void Start()
    {
        // Calculate screen boundaries based on camera view
        AudioManager.instance.PlayMusic("Theme1");
        Camera mainCamera = Camera.main;
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        minX = -screenBounds.x;
        maxX = screenBounds.x;
        minY = -screenBounds.y;
        maxY = screenBounds.y;
    }

    void Update()
    {
        Time.timeScale = 1;
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        Vector2 playerPos = player.transform.position;
        if (playerPos.x < minX || playerPos.x > maxX || playerPos.y < minY || playerPos.y > maxY)
        {
            Lose();
        }
        if (player.health >= 5)
        {
            Lose();
        }
    }

    void Lose()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlaySFX("GameOver");
        Time.timeScale = 0;
        loseTab.SetActive(true);
        loseText.text = "Score : " + timeText.text.ToString();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.musicSource.Stop();
            Destroy(AudioManager.instance.gameObject);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
