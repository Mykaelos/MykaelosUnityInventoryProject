﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
 * 
 * Start Drag - OnBeginDrag, view starts moving.
 * Dragging - OnDrag, view is being moved around.
 * End Drag over new empty slot - slot.OnDrop, assign DragSlot.
 * End Drag out of inventory - OnEndDrag, reassign DragSlot.
 * Other view ends drag on this view - OnDrop, swap items.
 */
[RequireComponent(typeof(CanvasGroup))] // Needed for ignoring raycasts when moving.
[RequireComponent(typeof(Canvas))] // Needed for layer sorting. Set order to 1.
[RequireComponent(typeof(GraphicRaycaster))] // Must be added when Canvas is used.
public class DraggableViewController : MonoBehaviour, 
    IBeginDragHandler, IDragHandler, IEndDragHandler, 
    IPointerClickHandler, IDropHandler {

    //public static DraggableViewController CurrentlyDraggedItem; //TODO remove me!
    public DragSlotController PreviousDragSlot;
    public DragSlotController DragSlot;
    //public IInventoryUnit InventoryUnit;


    //public void Setup(IInventoryUnit inventoryUnit) {
    //    InventoryUnit = inventoryUnit;
    //}

    // IBeginDragHandler Unity Method
    public void OnBeginDrag(PointerEventData eventData) {
        //CurrentlyDraggedItem = this;
        PreviousDragSlot = DragSlot;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<Canvas>().sortingOrder = 2;
        ////DragSlot.OnBeginDragView(this);
    }

    // IDragHandler Unity Method
    public void OnDrag(PointerEventData eventData) {
        // Assumes Canvas - Screen Space Camera, otherwise the eventData.position will not match UI position.
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y));
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    // IEndDragHandler Unity Method
    public void OnEndDrag(PointerEventData eventData) {
        //CurrentlyDraggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        GetComponent<Canvas>().sortingOrder = 1;

        // If slot wasn't changed, then either item was dropped on the same slot (no op), or dropped out of bounds and should be returned to previous slot.
        if (DragSlot == PreviousDragSlot) {
            DragSlot.HoldView(this);
        }
    }

    // IDropHandler Unity Method - When an another DragView is dropped on this one.
    public void OnDrop(PointerEventData eventData) {
        var dragView = eventData?.pointerDrag?.GetComponent<DraggableViewController>();

        //Switch locations of itemViews
        var tempPreviousItemSlot = dragView.DragSlot;
        DragSlot.HoldView(dragView);

        DragSlot = tempPreviousItemSlot;
        DragSlot.HoldView(this);

        ////Switch locations of itemViews
        //var tempPreviousItemSlot = CurrentlyDraggedItem.DragSlot;
        //DragSlot.HoldView(CurrentlyDraggedItem);

        //DragSlot = tempPreviousItemSlot;
        //DragSlot.HoldView(this);
    }

    // IPointerClickHandler Unity Method - When this view is clicked.
    public void OnPointerClick(PointerEventData eventData) {
        //DragSlot.OnClickView(this);
    }


    //TODO move events over here

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
