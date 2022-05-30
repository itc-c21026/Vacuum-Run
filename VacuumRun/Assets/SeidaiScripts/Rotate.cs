using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateX;
    public float RotateY;
    public float RotateZ;
    void Update()
    {
        transform.Rotate(new Vector3(RotateX, RotateY, RotateZ) * Time.deltaTime, Space.World);//オブジェクトを回転させることができます！　
                                                                                               //カッコ内の数字を弄ることで一秒あたり何度回転させるか決めることができます！！
                                                                                               //Space.world = ワールド軸で回転
    }
}
