using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePanel : MonoBehaviour
{
    public GameObject[] icons;

    public void UpdateBlackHole(int blackhole)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < blackhole) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
