using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;

    private int health;

    public Text scoreDisplayText;

    private void Start()
    {
        health = maxHealth;
        scoreDisplayText.text = health.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseHealth();
        }
    }

    public void DecreaseHealth()
    {
        if (health == 0)
            return;

        health -= 10;
        if (PlayerController.instance.gameObject.activeInHierarchy)
            PlayerController.instance.CheckForHealth(health);
        scoreDisplayText.text = health.ToString();
    }
}
