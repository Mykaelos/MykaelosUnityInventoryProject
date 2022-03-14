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
            Key = "Mushroom",
            Name = "Mushroom"
        };

        invenBagData.InventorySlotDatas[3].ItemData = new ItemData {
            Key = "Skeleton",
            Name = "Skeleton"
        };

        Setup(new InventoryBagModel(invenBagData));
    }

    private void SetupViews() {
        transform.RemoveAll();
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform); // Because the GridLayoutGroup hasn't positioned the slots yet...

        foreach (var inventorySlotModel in InventoryBagModel.InventorySlotModels) {
            var slot = GameObject.Instantiate<GameObject>(InventorySlotPrefab);
            slot.transform.SetParent(transform);
        }

        // Spawn itemViews
    }
}
