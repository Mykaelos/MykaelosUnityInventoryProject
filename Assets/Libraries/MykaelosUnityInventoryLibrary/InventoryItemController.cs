using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour {
    private ItemModel ItemModel;


    public void Setup(ItemModel itemModel) {
        ItemModel = itemModel;
    }

    public ItemModel GetItemModel() {
        return ItemModel;
    }
}
