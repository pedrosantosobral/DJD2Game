using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Canvas manager class.
/// </summary>
public class CanvasManager : MonoBehaviour
{
    private static CanvasManager _instance;

    //Interaction object text variable
    public GameObject   interactionPanel;
    //Text variable
    public Text         interactionText;
    //inventory panel variable
    public GameObject   inventoryPanel;
    //Inventory Icon variable
    public Image[]      inventoryIcons;

    //Canvas manager instance
    public static CanvasManager instance
    {
        get { return _instance; }
    }

    //Awake method
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (_instance == null)
            _instance = this;
    }

    //Start Method
    void Start()
    {
        //if the cursor is not over a interactible object
        Cursor.lockState = CursorLockMode.Confined;
        HideInteractionPanel();

        ClearAllInventorySlotIcons();
	}
    //Hide inventory panel
    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    //Show interaction panel
    public void ShowInteractionPanel(string text)
    {
        interactionText.text = text;
        interactionPanel.SetActive(true);
    }

    //Clear all inventory icons panel
    private void ClearAllInventorySlotIcons()
    {
        //Clear every inventory icon
        for (int i = 0; i < inventoryIcons.Length; ++i)
            ClearInventorySlotIcon(i);
    }

    //Clear certain inventory icon 
    public void ClearInventorySlotIcon(int slotIndex)
    {
        inventoryIcons[slotIndex].enabled   = false;
        inventoryIcons[slotIndex].sprite    = null;
    }
    //Set a inventory icon to a interactible on the UI
    public void SetInventorySlotIcon(int slotIndex, Sprite icon)
    {
        inventoryIcons[slotIndex].sprite    = icon;
        inventoryIcons[slotIndex].enabled   = true;
    }

}
