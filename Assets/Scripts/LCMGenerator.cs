using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCMGenerator
{
    private int seed;
    private const int a = 1103515245;
    private const int c = 12345;
    private const int m = 2147483647;

    public LCMGenerator(int initialSeed)
    {
        seed = initialSeed;
    }

    // Fungsi LCM
    public int Generate()
    {
        seed = (a * seed + c) % m;
        return Mathf.Abs(seed);
    }

    // Fungsi membuat urutan soal acak dengan LCM
    public int[] GenerateSequence(int length)
    {
        int[] sequence = new int[length];
        List<int> indices = new List<int>();

        for (int i = 0; i < length; i++)
            indices.Add(i);

        for (int i = 0; i < length; i++)
        {
            int randomIndex = Generate() % indices.Count;
            sequence[i] = indices[randomIndex];
            indices.RemoveAt(randomIndex);
        }
        return sequence;
    }
}
