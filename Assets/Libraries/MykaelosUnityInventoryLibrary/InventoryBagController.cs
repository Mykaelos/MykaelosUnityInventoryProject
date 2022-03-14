using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBagController : MonoBehaviour {
    public GameObject ItemViewPrefab;
    public GameObject InventorySlotPrefab;

    private InventoryBagModel InventoryBagModel;


    private void Setup(InventoryBagModel inventoryBagModel) {
        InventoryBagModel = inventoryBagModel;

        SetupViews();
    }


    private void Start() { // Temp, testing.
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

        Setup(new InventoryBagModel(invenBagData));
    }

    private void SetupViews() {
        transform.RemoveAll();
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform); // Because the GridLayoutGroup hasn't positioned the slots yet...

        var inventorySlotModels = InventoryBagModel.GetInventorySlotModels();

        foreach (var inventorySlotModel in inventorySlotModels) {
            var slot = GameObject.Instantiate<GameObject>(InventorySlotPrefab);
            slot.transform.SetParent(transform, false);
            slot.GetComponent<InventorySlotController>().Setup(inventorySlotModel);

            var itemModel = inventorySlotModel.GetItemModel();
            if (itemModel != null) {
                var item = GameObject.Instantiate<GameObject>(ItemViewPrefab);
                item.transform.SetParent(slot.transform, false);

                //item.GetComponent<Image>().sprite = itemModel.GetSprite();

                item.GetComponent<InventoryItemView>().Setup(itemModel);
                item.GetComponent<InventoryItemController>().Setup(itemModel);

                
                slot.GetComponent<DragSlotController>().HoldView(item.GetComponent<DragViewController>());
            }
        }
    }
}
