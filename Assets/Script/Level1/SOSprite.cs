using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoDataSampah", menuName = "GameSampah/Data")]
public class SOSprite : ScriptableObject
{
    [SerializeField]
    private Sampah[] JenisSampah;


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

}


