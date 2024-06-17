using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLvl2 : Spawn
{
    protected override void Start()
    {
        for (int i = 0; i < GameManager.Instance.maxscore; i++)
        {
            var data = sampahdata.GetSampah("Organik");
            var obj = Instantiate(sampah, parent).GetComponent<DragSoil>();
            obj.transform.position = new Vector3(Random.Range(lefTop.position.x, rightBottom.position.x), Random.Range(lefTop.position.y, rightBottom.position.y));
            obj.SetGambar(data.image);
        }
    }
}
