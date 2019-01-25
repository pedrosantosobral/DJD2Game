using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialogue manager class.
/// </summary>
public class DialogueManager : MonoBehaviour {

    /// <summary>
    /// The dialogue trigger name variable
    /// </summary>
    public Text nameText;
    /// <summary>
    /// The dialogue text.
    /// </summary>
    public Text dialogueText;

    /// <summary>
    /// The animator.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// The sentenses queue.
    /// </summary>
    private Queue<string> sentenses;

    void Start () {

        sentenses = new Queue<string>();
    
    }
    /// <summary>
    /// Starts the dialogue.
    /// </summary>
    /// <param name="dialogue">Dialogue.</param>
    public void StartDialogue(Dialogue dialogue)
    {
        //Open dialogue box
        animator.SetBool("IsOpen", true);
        //set dialogue trigger name
        nameText.text = dialogue.name;
        //clear sentenses
        sentenses.Clear();

        //enqueue sentenses
        foreach(string sentense in dialogue.sentenses) 
        {
            sentenses.Enqueue(sentense);
        }

        //Display next sentense
        DisplayNextSentense();
    }

    /// <summary>
    /// Display the next sentense.
    /// </summary>
    public void DisplayNextSentense()
    {
        //end dialogue if sentenses = 0
        if(sentenses.Count == 0)
        {
            EndDialogue();
            return;
        }
        //dequeue sentenses
        string sentense = sentenses.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentense));
    }
    /// <summary>
    /// Types the sentense.
    /// </summary>
    /// <returns>The sentense printer char one by one.</returns>
    /// <param name="sentense">Sentense.</param>
    IEnumerator TypeSentense(string sentense)
    {
        dialogueText.text = "";
        //Go through all the chars in the sentense
        foreach(char character in sentense.ToCharArray())
        {
            //add char
            dialogueText.text += character;
            yield return null;
        }
    }
    //end dialogue
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}






