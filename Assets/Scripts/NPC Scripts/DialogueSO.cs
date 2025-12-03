using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject
{
    public DialogueLine[] lines;
    public DialogueOption[] options;
    [Header("Conditional Requirements (Optional)")]
    public ActorSO[] requireNPCs;
    public LocationSO[] requiredLocations;
    public ItemSO[] requiredItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsConditionMet()
    {
        if (requireNPCs.Length > 0)
        {
            foreach (var reqNPC in requireNPCs) 
            {
                bool hasSpoken = DialogueHistoryTracker.Instance.HasSpokenWith(reqNPC);
                if (!hasSpoken) 
                    return false;
            }
        }
        if (requiredLocations.Length > 0)
        {
            foreach (var location in requiredLocations)
            {
                if (!LocationHistoryTracker.Instance.HasVisited(location))
                    return false;
            }
        }
        if (requiredItems.Length > 0)
        {
            foreach (var item in requiredItems)
            {
                if (!InventoryManager.Instance.HasItem(item))
                    return false;
            }
        }
        return true;
    }
}

[System.Serializable]
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(3,5)] public string text;
}

[System.Serializable]
public class DialogueOption
{
    public string optionText;
    public DialogueSO nextDialogue;
}