using UnityEngine.Audio;
using UnityEngine;
//using UnityEngine.UI;
/// <summary>
/// Interactible item class.
/// </summary>


public class Interactible : MonoBehaviour
{
    //Audio Source variable
    public AudioSource activeSound;
    //bool to check if object is interactible
    public bool isInteractive;
    //bool to check if interaction is on
    public bool isActive;
    //bool to check if object is pickable
    public bool isPickable;
    //bool to check if object is a dialogue trigger
    public bool isDialogueTrigger;
    //bool to check if interaction is possible more than one time
    public bool allowsMultipleInteractions;
    //Inventary object sprite variable
    public Sprite inventoryIcon;
    //Text to apear if object needs requirement
    public string requirementText;
    //Text to apear on object interaction
    public string interactionText;
    //bool to check if object consumes requirements
    public bool consumesRequirements;
    //object array of requirements
    public Interactible[] inventoryRequirements;
    //object array of other interactibles
    public Interactible[] indirectInteractibles;
    //object array of indirect object activations
    public Interactible[] indirectActivations;
    //Dialogue instance
    public Dialogue dialogue;

    //Activate the object to be interactible
    public void Activate()
    {
        //Set isActive to true
        isActive = true;

        //Play active animation
        PlayAnimation("Activate");
    }

    //Interact with the object
    public void Interact()
    {
        //If is active
        if (isActive)
        {
            InteractActive();
        }
        else
        {
            InteractInactive();
        }
    }

    //Interact with the object on click
    private void InteractActive()
    {
        //Play Interaction animation
        PlayAnimation("InteractActive");

        //Interact with indirects
        InteractIndirects();

        //Activate indirect objects
        ActivateIndirects();

        //Trigger dialogue if exists
        TriggerDialogueCondition();

        //if allow more than one interaction is not possible
        if (!allowsMultipleInteractions)
        {
            //Set active to false
            isActive = false;
            //Set Dialogue trigger to false
            isDialogueTrigger = false;
            //Set is interactive to false
            isInteractive = false;
        }
        //play interaction sound
        activeSound.Play();
    }

    //Play inactive animation
    private void InteractInactive()
    {
        //Play inactive animation
        PlayAnimation("InteractInactive");
    }

    // look for animator and triggers
    private void PlayAnimation(string animationName)
    {
        //animator variable 
        Animator animator = GetComponent<Animator>();

        //if animator exists
        if (animator != null)
            animator.SetTrigger(animationName);
    }

    //Interact with indirects
    private void InteractIndirects()
    {
        //if indirect interactible exist
        if (indirectInteractibles != null)
        {
            //go through the array and interact with the objects
            for (int i = 0; i < indirectInteractibles.Length; ++i)
                indirectInteractibles[i].Interact();
        }
    }
    //Activate indirects
    private void ActivateIndirects()
    {
        //if indirect activations exist
        if (indirectActivations != null)
        {
            //go through the array and activate the objects
            for (int i = 0; i < indirectActivations.Length; ++i)
                indirectActivations[i].Activate();
        }
    }

    //trigger dialogues
    public void TriggerDialogueCondition()
    {
        //if the object is a diallogue trigger
        if (isDialogueTrigger)
        {
            //trigger dialogue
            TriggerDialogue();
        }

    }
    //Trigger dialogue
    public void TriggerDialogue()
    {
        //Start object Dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    //Go next sentense on the dialogue
    public void GoNextSentense() 
    {
        //Go next sentense on the object dialogue
        FindObjectOfType<DialogueManager>().DisplayNextSentense();
    }

}
