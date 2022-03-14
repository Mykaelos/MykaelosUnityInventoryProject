using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlotController : MonoBehaviour, IDropHandler {

    // IDropHandler Unity Method - When DragViewController is dropped on this empty slot.
    public void OnDrop(PointerEventData eventData) {
        var dragView = eventData?.pointerDrag?.GetComponent<DragViewController>();
        if (dragView == null) {
            return;
        }

        HoldView(dragView);
    }

    // For DraggableViewController
    public void HoldView(DragViewController dragView) {
        dragView.DragSlot = this;
        dragView.transform.SetParent(transform, false);
        dragView.transform.localPosition = Vector2.zero;

        LocalMessenger.Fire(EVENT_HOLD_VIEW, new object[] { this, dragView });
    }

    #region LocalMessenger EVENTS
    public const string EVENT_HOLD_VIEW = "EVENT_HOLD_VIEW";

    private LocalMessenger LocalMessenger = new LocalMessenger();

    public void On(string message, Action<object[]> callback) {
        LocalMessenger.On(message, callback);
    }

    public void Un(string message, Action<object[]> callback) {
        LocalMessenger.Un(message, callback);
    }
    #endregion
}
