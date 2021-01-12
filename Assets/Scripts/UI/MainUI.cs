using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Slider playerHealth;
    public GameObject gameOverPanel;
    //TODO Ppublic Image playerPortrait; 

    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();

        player.OnHealthChange += UpdateHealth;
        player.OnDeath += ShowGameOver;

        playerHealth.maxValue = player.health;
        playerHealth.value = player.health;
    }

    private void ShowGameOver()
    {
        StartCoroutine(ShowGameOverWithDelay(1)); //TODO 1 to field
    }

    IEnumerator ShowGameOverWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverPanel.SetActive(true);
    }

    private void UpdateHealth()
    {
        playerHealth.value = player.health;
    }
}
