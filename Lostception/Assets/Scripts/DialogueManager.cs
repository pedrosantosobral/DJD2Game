using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentenses;

    void Start () {

        sentenses = new Queue<string>();
    
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentenses.Clear();

        foreach(string sentense in dialogue.sentenses) 
        {
            sentenses.Enqueue(sentense);
        }

        Debug.Log("Start Conversation with " + dialogue.name);

        DisplayNextSentense();
    }

    public void DisplayNextSentense()
    {
        if(sentenses.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentense = sentenses.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentense));
    }

    IEnumerator TypeSentense(string sentense)
    {
        dialogueText.text = "";
        foreach(char character in sentense.ToCharArray())
        {
            dialogueText.text += character;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("end conversation");
    }

}






