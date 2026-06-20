using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [Header("DragAndDrop")]
    public KeyCode rotKeyD = KeyCode.E;
    public KeyCode rotKeyA = KeyCode.Q;

    [Header("References")]
    [SerializeField] private PlayerItems pItems;
    [SerializeField] private Transform upgradesParent;
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        upgradesParent = transform.parent;
        canvas = transform.root.gameObject.transform.GetChild(0).GetComponent<Canvas>();
        pItems = GameObject.FindWithTag("EventSystem").GetComponent<PlayerItems>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        //Instantiate(gameObject, gameObject.transform.position, Quaternion.identity, upgradesParent);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Rotate
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(rotKeyD))
        {
            gameObject.transform.Rotate(0, 0, -90);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(rotKeyA))
        {
            gameObject.transform.Rotate(0, 0, 90);
        }

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
