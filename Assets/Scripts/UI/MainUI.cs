using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Slider playerHealth;
    public GameObject gameOverPanel;
    //TODO public Image playerPortrait; 

    //private Player player;

    void Start()
    {
        //player = Player.Instance;
        Player.Instance.OnHealthChange += UpdateHealth;
        Player.Instance.OnDeath += ShowGameOver;

        playerHealth.maxValue = Player.Instance.Health;
        playerHealth.value = Player.Instance.Health;
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
        playerHealth.value = Player.Instance.Health;
    }
}
