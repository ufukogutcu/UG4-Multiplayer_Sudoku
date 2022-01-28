﻿using UnityEngine;
using UnityEngine.EventSystems;

public class SingleDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int number;
    public Vector3 position;
    public GameObject prefab;

    public static GameObject DraggedInstance;

    public GameObject summonprefab;
    private GameObject lastcoll;

    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    float _zDistanceToCamera;

    #region Interface Implementations

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedInstance = gameObject;
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
            ) + _offsetToMouse;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance = null;
        _offsetToMouse = Vector3.zero;

        if(lastcoll != null)
        {
            CellData data = lastcoll.GetComponent("CellData") as CellData;
            data.place_value(number,summonprefab);
        }

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        DestroyObject(gameObject);
        
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        lastcoll = coll.gameObject;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        lastcoll = null;
    }

    #endregion
}