using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;

    int index;

    private void OnEnable()
    {
        index = 0;
    }

    public void change(int i)
    {
        if (index + i < 0 || index + i > 2)
        {
            return;
        }

        index += i;
        switch (index)
        {
            case 0:
                disableall();
                one.SetActive(true);
                break;
            case 1:
                disableall();
                two.SetActive(true);
                break;
            case 2:
                disableall();
                three.SetActive(true);
                break;
        }
    }

    private void disableall()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
    }

}
