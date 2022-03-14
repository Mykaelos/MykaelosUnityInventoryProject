using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour {
    private ItemModel ItemModel;


    public void Setup(ItemModel itemModel) {
        ItemModel = itemModel;

        UpdateSprite();
    }

    private void UpdateSprite() {
        GetComponent<Image>().sprite = ItemModel?.GetSprite();
    }
}
