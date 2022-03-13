using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlotController : MonoBehaviour, IDropHandler {
    //public int SlotIndex; // Used for knowing what slot was dropped on (Inventory, equipment, etc...)


    // IDropHandler Unity Method - When DragViewController is dropped on this empty slot.
    public void OnDrop(PointerEventData eventData) {
        //eventData.pointerDrag


        //bool isDragView = eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<DraggableViewController>() != null;
        //if (!isDragView) {
        //    return;
        //}
        var dragView = eventData?.pointerDrag?.GetComponent<DraggableViewController>();
        if (dragView == null) {
            return;
        }
        HoldView(dragView);

        //Debug.Log("Dropped {0} from {1} to {2}".FormatWith(dragView.name, "?", SlotIndex));


        //DraggableViewController dragView = DraggableViewController.CurrentlyDraggedItem; //TODO make sure DraggableViewController doesn't null this...
        //DragSlotController dragSlot = dragView.DragSlot.GetComponent<DragSlotController>();
        //int previousSlotIndex = dragSlot.SlotIndex;

        //HoldView(dragView);
        //LocalMessenger.Fire(EVENT_ON_DROP, new object[] { dragView, previousSlotIndex, dragSlot });

        //Debug.Log("Dropped {0} from {1} to {2}".FormatWith(dragView.name, previousSlotIndex, SlotIndex));
    }

    // For DraggableViewController
    public void HoldView(DraggableViewController dragView) {
        dragView.DragSlot = this;
        dragView.transform.SetParent(transform, false);
        dragView.transform.localPosition = Vector2.zero;

        //dragView.InventoryUnit.SetSlot(SlotIndex);
    }

    //TODO remove/replace OnClickView and OnBeginDragView

    //// For DraggableViewController
    //public void OnClickView(DraggableViewController draggableViewController) {
    //    //LocalMessenger.Fire(EVENT_ON_CLICK_VIEW, new object[] { this, SlotIndex, draggableViewController });
    //}

    //// For DraggableViewController
    //public void OnBeginDragView(DraggableViewController draggableViewController) {
    //    //LocalMessenger.Fire(EVENT_ON_BEGIN_DRAG_VIEW, new object[] { this, SlotIndex, draggableViewController });
    //}


    #region LocalMessenger EVENTS
    public const string EVENT_ON_BEGIN_DRAG_VIEW = "EVENT_ON_BEGIN_DRAG_VIEW";
    public const string EVENT_ON_DROP = "EVENT_ON_DROP";
    public const string EVENT_ON_CLICK_VIEW = "EVENT_ON_CLICK_VIEW";

    private LocalMessenger LocalMessenger = new LocalMessenger();

    public void On(string message, Action callback) {
        LocalMessenger.On(message, callback);
    }

    public void Un(string message, Action callback) {
        LocalMessenger.Un(message, callback);
    }
    #endregion
}
