using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGet : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int score;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")//当たり判定のタグ検知してポイント増やすっす
        {
            scoreManager.AddScore(score);
        }
    }
}
