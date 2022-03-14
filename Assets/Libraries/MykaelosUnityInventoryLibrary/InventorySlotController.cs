using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotController : MonoBehaviour {
    private InventorySlotModel InventorySlotModel;


    public void Setup(InventorySlotModel inventorySlotModel) {
        InventorySlotModel = inventorySlotModel;
    }

    public void Awake() {
        GetComponent<DragSlotController>().On(DragSlotController.EVENT_HOLD_VIEW, OnHoldView);
    }

    private void OnHoldView(object[] args) {
        var dragView = (DragViewController)args[1];
        var itemModel = dragView.GetComponent<InventoryItemController>().GetItemModel();

        InventorySlotModel.SetItemModel(itemModel);
    }
}
