using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;
    public Image skillIcon;
    public int currentLevel;
    public bool isUnlocked;
    public TMP_Text skillLevelText;
    public Button skillButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryUpgradeSkill()
    {
        if (isUnlocked && currentLevel < skillSO.maxLevel)
        {
            currentLevel++;
            UpdateUI();
        }
    }

    private void OnValidate()
    {
        if (skillSO != null && skillLevelText != null)
        {
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        skillIcon.sprite = skillSO.skillIcon;

        if (isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = currentLevel.ToString() + "/" + skillSO.maxLevel.ToString();
            skillIcon.color = Color.white;
        }
        else
        {
            skillButton.interactable = false;
            skillLevelText.text = "Locked";
            skillIcon.color = Color.grey;
        }
    }
}