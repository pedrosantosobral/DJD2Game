using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Player class.
/// </summary>
public class Player : MonoBehaviour
{
    // variable to define the max distance to chec for interactible object
    public float maxInteractionDistance;
    // define the max inventory size
    public int   inventorySize;

    //Canvas manager variable
    private CanvasManager       _canvasManager;
    //Camera variable
    private Camera              _camera;
    //Raycast of look direction
    private RaycastHit          _raycastHit;
    //Variable to save the current looking interactible to interact with
    private Interactible        _currentInteractible;
    //List of inventory interactible items
    private List<Interactible>  _inventory;

    //Start method to initalize variables
    private void Start()
    {
        _canvasManager = CanvasManager.instance;
        
        _camera = GetComponentInChildren<Camera>();

        _currentInteractible = null;

        _inventory = new List<Interactible>(inventorySize);
    }

    //Method to update 
    void Update()
    {
        CheckForInteractible();
        CheckForInteractionClick();
        CheckForContinueDialogueClick();
    }

    //Checks for presence of interactible object
    private void CheckForInteractible()
    {
        //Check for interactible 
        if (Physics.Raycast(_camera.transform.position,
            _camera.transform.forward, out _raycastHit,
            maxInteractionDistance))
        {
            //Set found interactible to current interactible to interact with
            Interactible newInteractible = _raycastHit.collider.GetComponent<Interactible>();

            //Set interactible if interactible property is on
            if (newInteractible != null && newInteractible.isInteractive)
                SetInteractible(newInteractible);
            else
                //Clear current interactible
                ClearInteractible();
        }
        else
            //Clear current interactible
            ClearInteractible();
    }

    //Checks fo interaction click
    private void CheckForInteractionClick()
    {
        //If mouse click is detected and the current interactible is found
        if (Input.GetMouseButtonDown(0) && _currentInteractible != null)
        {
            //If interactible is pickable (inventory item) 
            if (_currentInteractible.isPickable)
                //Add interactible to inventory
                AddToInventory(_currentInteractible);
            //If the player has the requeired inventory items to the current interactible
            else if (HasRequirements(_currentInteractible))
                //Interact with the current interactible
                Interact(_currentInteractible);
        }
    }

    //Checks for continue dialogue click 
    private void CheckForContinueDialogueClick()
    {
        //If Key C is pressed 
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Find the current interactible dialogue and go next sentense
            FindObjectOfType<Interactible>().GoNextSentense();
        }
    }

    //
    private void SetInteractible(Interactible newInteractible)
    {
        _currentInteractible = newInteractible;

        if (HasRequirements(_currentInteractible))
            _canvasManager.ShowInteractionPanel(_currentInteractible.interactionText);
        else
            _canvasManager.ShowInteractionPanel(_currentInteractible.requirementText);
    }
    //Clear the current interactible variable
    private void ClearInteractible()
    {
        //Set the current interactible to null
        _currentInteractible = null;
        //Hide interactible interaction panel
        _canvasManager.HideInteractionPanel();
    }

    //Checks for inventory requirements avaliability
    private bool HasRequirements(Interactible interactible)
    {
        //go trough current interactible inventory requirements array and check
        //for needed requirements
        for (int i = 0; i < interactible.inventoryRequirements.Length; ++i)
            if (!HasInInventory(interactible.inventoryRequirements[i]))
                return false;

        return true;
    }
    //Interact with current interactible
    private void Interact(Interactible interactible)
    {
        //If the current interactible has requirements
        if (interactible.consumesRequirements)
        {
            //go though interactible requirements array and remove the pickable 
            //objects from the inventory
            for (int i = 0; i < interactible.inventoryRequirements.Length; ++i)
                RemoveFromInventory(interactible.inventoryRequirements[i]);
        }
        //Do this until there are no more requirements in inventory
        interactible.Interact();
    }

    //Add interactible pickable to inventory
    private void AddToInventory(Interactible pickable)
    {
        //If inventory still has space
        if (_inventory.Count < inventorySize)
        {
            //Add pickable to inventory
            _inventory.Add(pickable);
            //Disable object (errase from game world, colect)
            pickable.gameObject.SetActive(false);
            //Update Inventory Icons
            //UpdateInventoryIcons();
            
        }
    }
    //Checks for pickable present in inventory
    private bool HasInInventory(Interactible pickable)
    {
        return _inventory.Contains(pickable);
    }
    //Remove items from inventory
    private void RemoveFromInventory(Interactible pickable)
    {
        //Remove pickable from inventory
        _inventory.Remove(pickable);
        //Update Inventory Icons(need fix)
        UpdateInventoryIcons();
    }
    //Update Inventory Icons
    private void UpdateInventoryIcons()
    {
    //go though the inventory slots  
        for (int i = 0; i < inventorySize; ++i)
        {
            if (i < _inventory.Count)
                _canvasManager.SetInventorySlotIcon(i, _inventory[i].inventoryIcon);
            else
                _canvasManager.ClearInventorySlotIcon(i);
        }
    }
}
