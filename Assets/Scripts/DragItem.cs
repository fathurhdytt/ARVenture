using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    public GameObject item;      // Objek yang akan di-drag
    public GameObject itemDrop; // Area drop

    Vector2 itemPos; // Posisi awal objek
    public int jarak; // Jarak maksimum untuk drop

    void Start()
    {
        itemPos = item.transform.position; // Simpan posisi awal item
        Debug.Log("Posisi awal item: " + itemPos); // Debug untuk cek posisi awal
        Debug.Log("Script DragItem sudah aktif.");
    }

    // Dipanggil saat item di-drag
    public void ItemDrag()
    {
        Debug.Log("Item sedang di-drag."); // Debug log
        item.transform.position = Input.mousePosition; // Pindahkan ke posisi mouse
    }

    // Dipanggil saat drag selesai
    public void EndDrag()
    {
        float distance = Vector3.Distance(item.transform.localPosition, itemDrop.transform.localPosition);

        if (distance < jarak)
        {
            Debug.Log("Item berhasil ditempatkan di area drop.");
            item.transform.localPosition = itemDrop.transform.localPosition;
        }
        else
        {
            Debug.Log("Item kembali ke posisi awal.");
            item.transform.localPosition = itemPos;
        }
    }
}
