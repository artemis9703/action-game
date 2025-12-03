using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DialogueHistoryTracker : MonoBehaviour
{
    public static DialogueHistoryTracker Instance;
    private readonly HashSet<ActorSO> spokenNPCs = new HashSet<ActorSO>();

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
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RecordNPC(ActorSO npc)
    {
        if (npc == null) 
        { 
            return; 
        } 
        spokenNPCs.Add(npc);
    }

    public bool HasSpokenWith(ActorSO actorSO)
    {
        return spokenNPCs.Contains(actorSO);
    }
}