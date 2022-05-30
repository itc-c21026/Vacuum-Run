using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    const int DefaultScore = 0;
    public static int score = DefaultScore;
    public void Start()
    {
        score = 0; //�X�R�A�ϐ��̏�����
    }
    public void AddScore(int amount)
    {
            score += amount;
    }
    public void DownScore()
    {
        score = 0;
    }
    public static int GetScore()//���X�N���v�g�ŃX�R�A�̕ϐ���ǂݎ��̂Ɏg����
    {
        return score;
    }
    void OnGUI() //GUI�ŃX�R�A��\��
    {
        GUI.color = Color.yellow;
        GUI.skin.label.fontSize = 24;

        string label = "SCORE :" + score;

        GUI.Label(new Rect(780, 10, 200, 30), label);
    }
}
