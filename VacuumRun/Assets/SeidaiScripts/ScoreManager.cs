using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    const int DefaultScore = 0;
    public static int score = DefaultScore;
    public void Start()
    {
        score = 0; //スコア変数の初期化
    }
    public void AddScore(int amount)
    {
            score += amount;
    }
    public void DownScore()
    {
        score = 0;
    }
    public static int GetScore()//他スクリプトでスコアの変数を読み取るのに使うよ
    {
        return score;
    }
    void OnGUI() //GUIでスコアを表示
    {
        GUI.color = Color.yellow;
        GUI.skin.label.fontSize = 24;

        string label = "SCORE :" + score;

        GUI.Label(new Rect(780, 10, 200, 30), label);
    }
}
