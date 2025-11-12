using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
        public TMP_Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
