using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(slot.TryUpgradeSkill);
        }
        UpdateAbilityPoints(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAbilityPoints(int amount)
    {
        availablePoints += amount;
        pointsText.text = "Points: " + availablePoints;
    }
}
