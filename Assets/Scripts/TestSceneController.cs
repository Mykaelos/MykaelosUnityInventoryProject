using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneController : MonoBehaviour {


    private void Start() {
        var bagController = GameObject.Find("InventoryBag")?.GetComponent<InventoryBagController>();
        var inventoryBagData = FileSaveManager.GetOrLoadOrCreate("InventoryBagData", DefaultData());

        bagController.Setup(new InventoryBagModel(inventoryBagData));
    }

    private InventoryBagData DefaultData() {
        int slots = 16;

        var invenBagData = new InventoryBagData();
        for (int i = 0; i < slots; i++) {
            invenBagData.InventorySlotDatas.Add(new InventorySlotData());
        }

        invenBagData.InventorySlotDatas[2].ItemData = new ItemData {
            Key = "Sword",
            Name = "Sword",
            SpriteName = "oryx_16bit_fantasy_items_200"
        };

        invenBagData.InventorySlotDatas[3].ItemData = new ItemData {
            Key = "Gloves",
            Name = "Gloves",
            SpriteName = "oryx_16bit_fantasy_items_259"
        };

        return invenBagData;
    }
}
