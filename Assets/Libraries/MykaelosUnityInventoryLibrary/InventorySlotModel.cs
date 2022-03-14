using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotModel {
    private InventorySlotData InventorySlotData;
    private ItemModel ItemModel;


    public InventorySlotModel(InventorySlotData inventorySlotData) {
        InventorySlotData = inventorySlotData;

        if (InventorySlotData.ItemData != null) {
            ItemModel = new ItemModel(InventorySlotData.ItemData);
        }
    }

    public ItemModel GetItemModel() {
        return ItemModel;
    }

    public void SetItemModel(ItemModel itemModel) {
        ItemModel = itemModel;
        InventorySlotData.ItemData = ItemModel.ItemData;
    }
}
