using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    public float ExitTime;
    void Start()
    {
        Destroy(this.gameObject, ExitTime);//オブジェクトやステージ消すのに使うっす
    }
}
