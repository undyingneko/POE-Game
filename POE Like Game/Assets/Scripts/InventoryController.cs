using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector] public ItemGrid selectedItemGrid;
    Vector2Int positionOnGrid;
    InventoryItem selectedItem;
    RectTransform selectedItemRectTransform;

    private void Update()
    {
        // Update the position of the selected item to follow the mouse
        if (selectedItem != null)
        {
            if (selectedItemRectTransform == null)
            {
                selectedItemRectTransform = selectedItem.GetComponent<RectTransform>();
            }
            selectedItemRectTransform.position = Input.mousePosition;
        }

        // If there's no grid selected, exit the Update loop
        if (selectedItemGrid == null) { return; }

        // Handle mouse click for picking up or placing items
        if (Input.GetMouseButtonDown(0))
        {
            positionOnGrid = selectedItemGrid.GetTileGridPosition(Input.mousePosition);

            // If no item is selected, attempt to pick up an item
            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(positionOnGrid);
                if (selectedItem != null)
                {
                    selectedItemRectTransform = selectedItem.GetComponent<RectTransform>();
                }
                else
                {
                    Debug.LogWarning("No item found at the grid position to pick up.");
                }
            }
            else
            {
                // If an item is selected, attempt to place it in the grid
                selectedItemGrid.PlaceItem(selectedItem, positionOnGrid.x, positionOnGrid.y);
                selectedItem = null;
                selectedItemRectTransform = null;
            }
        }
    }
}
