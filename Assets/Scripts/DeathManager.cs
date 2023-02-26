using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public TMP_Text scoreUI;
    public Canvas endScreen;
    private GameController gameController;
    private Planet planet;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        planet = FindObjectOfType<Planet>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(planet == null) {
            planet = FindObjectOfType<Planet>();
        }
        if(gameController.getWarmth() >= 1f || planet.health <= 0) {
            endScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
            scoreUI.text = "Survived for " + scoreManager.GetScore() + " secs";
        }

        if(endScreen.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(0);
        }
    }
}
