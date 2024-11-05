using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemSlot : MonoBehaviour
{
    [SerializeField] EquipmentSlot equipmentSlot;

    InventoryItem itemInSlot;

    RectTransform slotRectTransform;
    private void Awake()
    {
        slotRectTransform = GetComponent<RectTransform>();
    }
    public bool Check(InventoryItem itemToPlace)
    {
        return equipmentSlot == itemToPlace.itemData.equipmentSlot;
    }


    public InventoryItem ReplaceItem(InventoryItem itemToPlace)
    {
        InventoryItem replaceItem = itemInSlot;

        PlaceItem(itemToPlace);

        return replaceItem;
    }


    internal void PlaceItem(InventoryItem itemToPlace)
    {
        itemInSlot = itemToPlace;
        RectTransform rt = itemToPlace.GetComponent<RectTransform>();
        rt.SetParent(slotRectTransform);
        rt.position = slotRectTransform.position;
    }
}
