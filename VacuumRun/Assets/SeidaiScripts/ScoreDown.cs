using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDown : MonoBehaviour
{
    public ScoreManager scoreManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Down")//タグ検知でスコア下げるっす
        {
            scoreManager.DownScore();
        }
    }
}
