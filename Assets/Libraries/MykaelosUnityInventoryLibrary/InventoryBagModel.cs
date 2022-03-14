using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBagModel {
    private InventoryBagData InventoryBagData;
    private List<InventorySlotModel> InventorySlotModels = new List<InventorySlotModel>();


    public InventoryBagModel(InventoryBagData inventoryBagData) {
        InventoryBagData = inventoryBagData;

        for (int i = 0; i < InventoryBagData.InventorySlotDatas.Count; i++) {
            InventorySlotModels.Add(new InventorySlotModel(InventoryBagData.InventorySlotDatas[i]));
        }
    }

    public List<InventorySlotModel> GetInventorySlotModels() {
        return InventorySlotModels;
    }
}
