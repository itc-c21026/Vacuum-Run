using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleDestroy : MonoBehaviour
{
    public UI ui;
    public int score;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlackHole")
        {
            ui.Shinchoku(score);
            Destroy(this.gameObject,0.5f);//�^�O���肵�ăI�u�W�F�N�g��������
        }
    }
}
