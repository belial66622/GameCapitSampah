using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSoil : MonoBehaviour
{
    [SerializeField]
    private LayerMask sampah;

    [SerializeField]
    private GameObject dragGameobject;

    [SerializeField]
    private int jenis;

    private Vector3 startingPos;

    [SerializeField]
    SpriteRenderer gambar;


    private void Start()
    {
        startingPos = transform.position;
    }

    protected void OnMouseUp()
    {
       // dragGameobject.SetActive(false);
        var test = Physics2D.BoxCast(dragGameobject.transform.position, new Vector2(.7f, .7f), 0, Vector2.zero, 1, sampah);
        if (test)
        {
            if (test.transform.TryGetComponent<Bucket>(out Bucket sampah))
            {
                var condition = sampah.CheckObject(jenis);
                if (!condition)
                {
                    StartCoroutine(Slide(dragGameobject, startingPos));
                }
                else 
                {
                    dragGameobject.SetActive(false);
                }
                return;
            }
        }

        StartCoroutine(Slide(dragGameobject, startingPos));
    }

    protected  void OnMouseDrag()
    {
        StopAllCoroutines();
        dragGameobject.SetActive(true);
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        dragGameobject.transform.position = pos;
    }



    IEnumerator Slide(GameObject from, Vector3 to)
    {

        float t = 0;
        while (t <= 1)
        {
            yield return null;
            t += Time.deltaTime;
            from.transform.position = Vector2.Lerp(from.transform.position, to, t);
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public virtual void SetGambar(Sprite image)
    {
        gambar.sprite = image;
    }
}
