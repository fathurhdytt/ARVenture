using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TextAsset AssetSoal;

    private Soal soal; // Instance of Soal class
    private int[] urutanSoal;
    private int indexSoal;
    private int maxSoal;
    private bool ambilSoal;
    private char kunciJ;
    private int posisiBenar;

    // LCM generator for random sequence generation
    private LCMGenerator lcmGenerator;

    public TextMeshProUGUI txtSoal, txtOpsiA, txtOpsiB, txtOpsiC, txtOpsiD, txtOpsiE;

    void Start()
    {
        // Initialize Soal, LCM generator, and setup questions
        soal = new Soal(AssetSoal);
        maxSoal = soal.GetMaxSoal();
        
        lcmGenerator = new LCMGenerator(System.Guid.NewGuid().GetHashCode());

        // Generate random sequence for questions
        urutanSoal = lcmGenerator.GenerateSequence(maxSoal);
        indexSoal = 0;
        ambilSoal = true;

        TampilkanSoal();
    }

    private void TampilkanSoal()
    {
        if (indexSoal < maxSoal)
        {
            if (ambilSoal)
            {
                int soalIndex = urutanSoal[indexSoal];
                txtSoal.text = soal.GetSoal(soalIndex);

                string[] opsi = new string[5];
                opsi[0] = soal.GetOpsi(soalIndex, 0);
                opsi[1] = soal.GetOpsi(soalIndex, 1);
                opsi[2] = soal.GetOpsi(soalIndex, 2);
                opsi[3] = soal.GetOpsi(soalIndex, 3);
                opsi[4] = soal.GetOpsi(soalIndex, 4);

                kunciJ = soal.GetKunciJawaban(soalIndex);

                // Determine correct answer index before shuffle
                int indeksAwalJawabanBenar = kunciJ - 'A';

                // Shuffle the answer options
                FisherYatesShuffle.Shuffle(opsi);

                // Find new position of correct answer
                for (int i = 0; i < opsi.Length; i++)
                {
                    if (opsi[i] == soal.GetOpsi(soalIndex, indeksAwalJawabanBenar))
                    {
                        posisiBenar = i;
                        break;
                    }
                }

                // Display shuffled options
                txtOpsiA.text = opsi[0];
                txtOpsiB.text = opsi[1];
                txtOpsiC.text = opsi[2];
                txtOpsiD.text = opsi[3];
                txtOpsiE.text = opsi[4];

                ambilSoal = false;
            }
        }
    }

    public void Opsi(string opsiHuruf)
    {
        int indeksPilihan = opsiHuruf[0] - 'A';
        CheckJawaban(indeksPilihan);

        indexSoal++;
        ambilSoal = true;
        TampilkanSoal();
    }

    private void CheckJawaban(int indeks)
    {
        if (indeks == posisiBenar)
        {
            print("Benar!");
        }
        else
        {
            print("Salah!");
        }
    }
}
