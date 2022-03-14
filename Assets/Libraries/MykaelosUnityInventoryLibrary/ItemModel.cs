using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel {
    public ItemData ItemData;


    public ItemModel(ItemData itemData) {
        ItemData = itemData;
    }

    public Sprite GetSprite() {
        return Resources.Load<Sprite>(ItemData.SpriteName);
    }
}
