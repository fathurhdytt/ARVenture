using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public string targetID; // ID unik untuk target drop
    public RectTransform dropArea; // Tempat tujuan untuk drop item
    public float tolerance = 50f; // Toleransi untuk mengecek apakah posisi drop sudah benar

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragDropHandler dragHandler = eventData.pointerDrag.GetComponent<DragDropHandler>();

            if (dragHandler != null && dragHandler.itemID == targetID)
            {
                Vector3 dropPosition = eventData.pointerDrag.transform.position;

                if (Vector3.Distance(dropPosition, dropArea.position) < tolerance)
                {
                    // Posisikan item tepat di tengah drop area
                    eventData.pointerDrag.transform.position = dropArea.position;
                    
                    // Sesuaikan ukuran item agar sesuai dengan drop area
                    dragHandler.SetDroppedCorrectly(true, dropArea.sizeDelta);
                }
                else
                {
                    dragHandler.SetDroppedCorrectly(false, Vector2.zero);
                }
            }
            else
            {
                dragHandler.SetDroppedCorrectly(false, Vector2.zero);
            }
        }
    }
}
