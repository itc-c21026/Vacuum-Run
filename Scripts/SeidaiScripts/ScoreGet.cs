using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGet : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int score;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")//�����蔻��̃^�O���m���ă|�C���g���₷����
        {
            scoreManager.AddScore(score);
        }
    }
}
