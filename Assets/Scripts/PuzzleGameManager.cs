using UnityEngine;
using System.Collections.Generic;

public class PuzzleGameManager : MonoBehaviour
{
    public List<DragDropHandler> draggableItems; // Daftar item yang bisa di-drag

    private List<Vector3> defaultPositions; // Menyimpan posisi default setiap draggableItem

    void Start()
    {
        // Simpan posisi default setiap draggableItem
        defaultPositions = new List<Vector3>();
        foreach (var item in draggableItems)
        {
            defaultPositions.Add(item.transform.position);
        }

        RandomizePositions(); // Acak posisi saat permainan dimulai
    }

    void RandomizePositions()
    {
        // Acak urutan posisi default menggunakan Fisher-Yates Shuffle
        Shuffle(defaultPositions);

        // Atur posisi gambar sesuai dengan posisi default yang diacak
        for (int i = 0; i < draggableItems.Count; i++)
        {
            draggableItems[i].transform.position = defaultPositions[i];
            // Set posisi awal setelah diacak
            draggableItems[i].SetInitialPosition(defaultPositions[i]);
        }
    }

    void Shuffle<T>(List<T> list)
    {
        // Implementasi Fisher-Yates Shuffle
        for (int i = list.Count - 1; i > 0; i--)
        {
            // Pilih indeks acak antara 0 dan i (inklusif)
            int j = Random.Range(0, i + 1);

            // Tukar elemen di indeks i dan j
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}