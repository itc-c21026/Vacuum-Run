using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDown : MonoBehaviour
{
    public ScoreManager scoreManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Down")//�^�O���m�ŃX�R�A���������
        {
            scoreManager.DownScore();
        }
    }
}
