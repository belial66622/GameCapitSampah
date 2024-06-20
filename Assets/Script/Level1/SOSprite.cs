using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoDataSampah", menuName = "GameSampah/Data")]
public class SOSprite : ScriptableObject
{
    [SerializeField]
    private Sampah[] JenisSampah;

    private int organik = 0;
    private int nonorganik = 0;

    public Sampahindi GetSampah(string jenis)
    {
        foreach (var item in JenisSampah)
        {
            if (item.name == jenis)
            {
                return new Sampahindi
                {
                    name = item.name,
                    image = item.imageList[Random.Range(0, item.imageList.Length)]
                };
            }

        }

        return new Sampahindi();
    }


    public Sampahindi GetRandom()
    {
        var random = Random.Range(0, JenisSampah.Length);

        return new Sampahindi
        {
            name = JenisSampah[random].name,
            image = JenisSampah[random].imageList[Random.Range(0, JenisSampah[random].imageList.Length)]
        };
    }

    public Sampahindi GetByOrder()
    {
        var random = Random.Range(0, JenisSampah.Length);

        Sampahindi sampah = new Sampahindi();
        switch (random) 
        {
            case 0:
                sampah = new Sampahindi
                {
                    name = JenisSampah[random].name,
                    image = JenisSampah[random].imageList[organik <  JenisSampah[random].imageList.Length ? organik : 0]
                    
                };
                organik++;
                break;
            case 1:
                sampah = new Sampahindi
                {
                    name = JenisSampah[random].name,
                    image = JenisSampah[random].imageList[nonorganik < JenisSampah[random].imageList.Length ? nonorganik : 0]
                };
                nonorganik++;
                break;
        }

        return sampah;
    }

    public void Reset()
    {
        organik = 0;
        nonorganik = 0;
    }


}


