using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;
    public int playerScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        PlayerHealth.OnUpdateHealth += UpdateHealthBar;
        PlayerScore.OnUpdateScore += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerHealth.OnUpdateHealth -= UpdateHealthBar;
        PlayerScore.OnUpdateScore -= UpdateScore;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {
        Debug.Log("Score Up");
        scoreText.text = "Treasure: " + theScore.ToString();
    }
}
