using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text GomiText;
    public Text GoalText;
    public Text KeikokuText;
    public Slider HPslider;
    public BlackHolePanel blackHolePanel;
    public BlackHole blackHole;
    static int i = 0;
    float maxHp = 100;
    float a = 100;
    float j = 0;
    static int c = 0;
    static int d = 0;

    // Start is called before the first frame update
    public void Start()
    {
        // 充電量をMAXからスタート
        HPslider.value = 1;

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public void Update()
    {
        // ごみ量を更新
        int score = Ascore();
        GomiText.text = "ごみ量 : " + i + "点";

        // ゴミをスタックしている数が2個以上の時
        if (i >= 2)
        {
            KeikokuText.text = "ゴミを捨てよう";

        // ゴミをスタックしている数が1個以上の時
        }else if(i <= 1)
        {
            KeikokuText.text = " ";
        }

        // 充電量を減らす
        a -= Time.deltaTime;
        j = Mathf.Floor(a);
        HPslider.value = j / maxHp;

        // 掃除率
        int Clear = AreaClear();
        GoalText.text = "掃除率 : " + d + "%";

        blackHolePanel.UpdateBlackHole(blackHole.BlackHoleCount());

    }

    public void OnCollisionEnter(Collision collision)
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        // ゴミタグに接触したとき
        if (other.gameObject.tag == "Gomi")
        {
            // ごみ量が1増える
            i += 1;
        }

        // 処理ポイントタグに接触した時
        else if (other.gameObject.tag == "ShoriPoint")
        {
            // 進捗率の計算
            c = c + i;
            c = c * 5;

            // ゴミスタックを初期化
            i = 0;

            // 進捗率
            d = d + c;

            // 進捗率の計算を初期化
            c = 0;


        }else if( other.gameObject.tag == "Heal")
        {
            // Healタグに接触すると充電量が5回復する
            a += 5;
        }


        
    }

    // 以下は関数
    public static int Ascore()
    {
        return (int)i;
    }

    public static int AreaClear()
    {
        return (int)c;
    }

    public void Shinchoku(int amount)
    {
        d += amount;
    }
}
