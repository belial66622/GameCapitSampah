using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField]
    protected LayerMask sampah;
    [SerializeField]
    private string jenis;
    [SerializeField]
    protected SpriteRenderer gambar;

    protected virtual void OnMouseUp()
    {
        var test = Physics2D.BoxCast(transform.position, new Vector2 (.7f,.7f),0, Vector2.zero,1,sampah);
        if (test)
        {
            if (test.transform.TryGetComponent<TempatSampah>(out TempatSampah sampah))
            {
                if (sampah.jenisSampah == jenis)
                {
                    GameManager.Instance.AddScore(1);
                    gameObject.SetActive(false);
                    Debug.Log($"tps {sampah.jenisSampah} dan sampah {jenis}");
                }
                else
                {
                    GameManager.Instance.AddScore(0);
                    gameObject.SetActive(false);
                    Debug.Log($"tps {sampah.jenisSampah} dan sampah {jenis}");
                }
            }
        }
    }

    protected virtual void OnMouseDrag()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    public virtual void SetGambar(string nama, Sprite image)
    {
        jenis = nama;
        gambar.sprite = image;
    }
}
