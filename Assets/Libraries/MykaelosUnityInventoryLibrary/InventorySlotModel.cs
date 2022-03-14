using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotModel {
    private InventorySlotData InventorySlotData;
    private ItemModel ItemModel;


    public InventorySlotModel(InventorySlotData inventorySlotData) {
        InventorySlotData = inventorySlotData;

        ItemModel = new ItemModel(InventorySlotData.ItemData);
    }
}
