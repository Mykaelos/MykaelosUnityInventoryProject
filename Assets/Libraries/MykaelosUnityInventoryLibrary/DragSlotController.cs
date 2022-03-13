using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlotController : MonoBehaviour, IDropHandler {

    // IDropHandler Unity Method - When DragViewController is dropped on this empty slot.
    public void OnDrop(PointerEventData eventData) {
        var dragView = eventData?.pointerDrag?.GetComponent<DraggableViewController>();
        if (dragView == null) {
            return;
        }

        HoldView(dragView);
    }

    // For DraggableViewController
    public void HoldView(DraggableViewController dragView) {
        dragView.DragSlot = this;
        dragView.transform.SetParent(transform, false);
        dragView.transform.localPosition = Vector2.zero;
    }

    //#region LocalMessenger EVENTS
    //public const string EVENT_ON_BEGIN_DRAG_VIEW = "EVENT_ON_BEGIN_DRAG_VIEW";
    //public const string EVENT_ON_DROP = "EVENT_ON_DROP";
    //public const string EVENT_ON_CLICK_VIEW = "EVENT_ON_CLICK_VIEW";

    //private LocalMessenger LocalMessenger = new LocalMessenger();

    //public void On(string message, Action callback) {
    //    LocalMessenger.On(message, callback);
    //}

    //public void Un(string message, Action callback) {
    //    LocalMessenger.Un(message, callback);
    //}
    //#endregion
}
