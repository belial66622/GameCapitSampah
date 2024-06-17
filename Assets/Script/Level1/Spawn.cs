using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] protected GameObject sampah;

    [SerializeField] protected Transform lefTop;

    [SerializeField] protected Transform rightBottom;

    [SerializeField] protected Transform parent;

    [SerializeField] protected SOSprite sampahdata;

    protected virtual void Start()
    {
        for (int i = 0; i < GameManager.Instance.maxscore; i++)
        {
            var data = sampahdata.GetRandom();
            var obj = Instantiate(sampah, parent).GetComponent<Drag>();
            obj.transform.position = new Vector3(Random.Range(lefTop.position.x, rightBottom.position.x), Random.Range(lefTop.position.y, rightBottom.position.y));
            obj.SetGambar(data.name, data.image);
        }
    }
}
