using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition; // Menyimpan posisi awal objek
    private Vector2 initialSize; // Menyimpan ukuran awal objek
    private bool isDroppedCorrectly = false; // Untuk mengecek apakah objek di-drop di posisi yang benar
    private RectTransform rectTransform;
    public string itemID; // ID unik untuk item ini

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialSize = rectTransform.sizeDelta; // Simpan ukuran awal
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().alpha = 0.6f;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().alpha = 1f;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (!isDroppedCorrectly)
        {
            // Jika gagal, kembali ke posisi awal saat drag dimulai
            transform.position = initialPosition;
            rectTransform.sizeDelta = initialSize;
        }
    }

    public void SetDroppedCorrectly(bool value, Vector2 newSize)
    {
        isDroppedCorrectly = value;
        if (value)
        {
            rectTransform.sizeDelta = newSize*90/100; // Sesuaikan ukuran dengan drop target
        }
    }

    // Method untuk mengembalikan posisi awal
    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    // Method untuk mengatur posisi awal
    public void SetInitialPosition(Vector3 position)
    {
        initialPosition = position;
    }
}