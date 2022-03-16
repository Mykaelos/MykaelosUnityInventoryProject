using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBagController : MonoBehaviour {
    public GameObject ItemViewPrefab;
    public GameObject InventorySlotPrefab;

    private InventoryBagModel InventoryBagModel;


    public void Setup(InventoryBagModel inventoryBagModel) {
        InventoryBagModel = inventoryBagModel;

        SetupViews();
    }

    private void SetupViews() {
        transform.RemoveAll();
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform); // So GridLayoutGroup will position the slots right away.

        var inventorySlotModels = InventoryBagModel.GetInventorySlotModels();

        foreach (var inventorySlotModel in inventorySlotModels) {
            var slot = GameObject.Instantiate<GameObject>(InventorySlotPrefab);
            slot.transform.SetParent(transform, false);
            slot.GetComponent<InventorySlotController>().Setup(inventorySlotModel);

            var itemModel = inventorySlotModel.GetItemModel();
            if (itemModel != null) {
                var item = GameObject.Instantiate<GameObject>(ItemViewPrefab);
                item.transform.SetParent(slot.transform, false);

                item.GetComponent<InventoryItemView>().Setup(itemModel);
                item.GetComponent<InventoryItemController>().Setup(itemModel);
                
                slot.GetComponent<DragSlotController>().HoldView(item.GetComponent<DragViewController>());
            }
        }
    }
}
