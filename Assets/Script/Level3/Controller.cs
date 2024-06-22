using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    SOSprite SOSprite;

    Sampahindi soal;

    [SerializeField]
    int JumlahSoal;

    [SerializeField]
    int minimalSoalBenar;

    [SerializeField]
    TextMeshProUGUI Soal;

    [SerializeField]
    TextMeshProUGUI score;

    int SoalBenar = 0;


    int soalke =0;
    [SerializeField]
    Image Gambar;

    [SerializeField]
    Sprite[] jawaban;

    [SerializeField]
    Image imagebenarsalah;

    [SerializeField]
    GameObject menang;

    [SerializeField]
    GameObject kalah;

    bool delay = false;

    string imagebefore;

    private void Start()
    {
        GetSoal();
    }


    public void CheckJawaban(string jawaban)
    {
        if (delay) return;
        StartCoroutine(next(soal.name == jawaban));

    }

    public void GetSoal()
    {
        if (soalke < JumlahSoal)
        {
            if (check(soal.image))
            { 
                check(soal.image);
            }
            Gambar.sprite = soal.image;
            delay = false;
        }
        else 
        {
            GameOver();
        }
    }

    public bool check(Sprite check)
    {
        soal =  SOSprite.GetRandom();
        return check == soal.image;
    }

    public void GameOver()
    {
        menang.SetActive(SoalBenar > minimalSoalBenar);
        kalah.SetActive(SoalBenar <= minimalSoalBenar);
    }

    IEnumerator next(bool condition)
    {
        SoalBenar += condition ? 1 : 0;
        score.SetText($"Score : {SoalBenar}");
        soalke++;
        delay = true;
        imagebenarsalah.gameObject.SetActive(true);
        imagebenarsalah.sprite = condition ? jawaban[1] : jawaban[0];
        yield return new WaitForSeconds(1);
        GetSoal();
        imagebenarsalah.gameObject.SetActive(false);

    }
}
