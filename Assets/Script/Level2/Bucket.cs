using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bucket : MonoBehaviour
{
    [SerializeField]private State state;

    [SerializeField] private TextMeshProUGUI instruction;

    private int sampahmasuk = 0;

    [SerializeField] private Image sliderimage;

    [SerializeField] private TextMeshProUGUI text;

    private int proses;

    [SerializeField] private int minimalproses = 0;

    [SerializeField] private GameObject canvasparent;

    [SerializeField] private GameObject gambarsampah;

    public bool startCounting = false;

    private void Start()
    {
        minimalproses = Mathf.FloorToInt( GameManager.Instance.maxscore * 0.7f);
    }

    public bool CheckObject(int Progress)
    {
        if (state == State.empty && Progress == 0)
        {
            state = State.soiled;
            instruction.SetText($"Tambahkan Sampah Ke dalam Ember 0 / {GameManager.Instance.maxscore}");
            return true;
        }
        else if (state == State.soiled && Progress == 1)
        {
            sampahmasuk++;
            instruction.SetText($"Tambahkan Sampah Ke dalam Ember {sampahmasuk} / {GameManager.Instance.maxscore}");
            if (sampahmasuk >= GameManager.Instance.maxscore)
            {
                instruction.SetText($"Tutup Ember Dengan tanah");
                state = State.full;
            }
            return true;
        }
        else if (state == State.full && Progress == 0)
        {
            instruction.SetText($"Tekan Tombol Continue untuk menunggu berdasarkan hari yang dipilih");

            gambarsampah.SetActive(true);
            state = State.done;
            canvasparent.SetActive(true);
        
        return true;
        }

        return false;
    }

    IEnumerator StartSlider()
    {
        startCounting = true;
        bool naik = true;
        while (true)
        {
            yield return new WaitForSeconds(.1f);

            if (naik)
            {
                proses++;
                sliderimage.fillAmount = (float)proses / (float)GameManager.Instance.maxscore;
                text.SetText($"{proses}");
                if (proses == GameManager.Instance.maxscore) naik = !naik;
            }
            else
            {
                proses--;
                sliderimage.fillAmount = (float)proses / (float)GameManager.Instance.maxscore;
                text.SetText($"{proses}");
                if (proses == 0) naik = !naik;
            }
        }
    }

    public void StartWaiting()
    {
        if (!startCounting)
        {
            StartCoroutine(StartSlider());
        }
        else
        {
            StopAllCoroutines();
            canvasparent.SetActive(false);
            counting();
        }
    }


    public void counting()
    {
        if (proses >= minimalproses)
        {
            instruction.SetText($"Pupuk Berhasil setelah ditunggu selama {proses} hari");
        }
        else
        {
            instruction.SetText($"Pupuk Belum Berhasil dibuat setelah ditunggu selama {proses} hari. Coba pupuk ditunggu selama {minimalproses} hari");
        }
    }
}



public enum State
{ 
    empty,
    soiled,
    full,
    done,
}