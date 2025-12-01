using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NPC_Talk : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Animator interactAnim;
    public List<DialogueSO> conversation;
    public DialogueSO currentConversation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (DialogueManager.Instance.isDialogueActive)
            {
                DialogueManager.Instance.AdvanceDialogue();
            }
            else
            {
                CheckForNewConversation();
                DialogueManager.Instance.StartDialogue(currentConversation);
            }
        }
    }

    private void CheckForNewConversation() 
    {
        for (int i = conversation.Count - 1; i >= 0; i--) 
        {  
            var convo = conversation[i];
            if (convo != null && convo.IsConditionMet()) 
            {
                conversation.RemoveAt(i);
                currentConversation = convo;
                return;
            }
        }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        anim.Play("Idle");
        interactAnim.Play("Open");
    }

    private void OnDisable()
    {
        interactAnim.Play("Close");
        rb.isKinematic = false;
    }
}