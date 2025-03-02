using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler
{
    // Dipanggil saat pointer (mouse atau sentuhan) menekan objek ini
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Script DragItem sudah aktif.");
    }
}
