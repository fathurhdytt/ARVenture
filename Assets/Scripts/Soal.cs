using System.Collections.Generic;
using UnityEngine;

public class Soal
{
    private string[] soal;
    private string[,] soalBag;
    private int maxSoal;

    public Soal(TextAsset assetSoal)
    {
        soal = assetSoal.ToString().Split('#');
        soalBag = new string[soal.Length, 7];
        maxSoal = soal.Length;

        OlahSoal();
    }

    public void OlahSoal()
    {
        for (int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                soalBag[i, j] = tempSoal[j];
            }
        }
    }

    public string GetSoal(int index)
    {
        return soalBag[index, 0];
    }

    public string GetOpsi(int index, int opsiIndex)
    {
        return soalBag[index, opsiIndex + 1]; // Menambahkan 1 karena opsi dimulai dari indeks 1
    }

    public char GetKunciJawaban(int index)
    {
        return soalBag[index, 6][0];
    }

    public int GetMaxSoal()
    {
        return maxSoal;
    }
}
