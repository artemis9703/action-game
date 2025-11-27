using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public StatsUI statsUI;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_Text speedText;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
    
    public void UpdateDamage(int amount)
    {
        damage += amount;
        damageText.text = "DAMAGE: " + damage; 
    }

    public void UpdateSpeed(int amount)
    {
        speed += amount;
        speedText.text = "SPEED: " + speed;
        statsUI.UpdateAllStats();
    }
    public void UpdateHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}
