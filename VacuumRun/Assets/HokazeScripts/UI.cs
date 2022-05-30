using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public static int Score;
    public AudioClip sound;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    AudioSource audioSource;
    int cnt = 3;

    public static int GetScore()
    {
        return Score;
    }

    // Start is called before the first frame update
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 充電量をMAXからスタート
        HPslider.value = 1;

        //ストックと達成率を開始時に0に
        i = 0;
        d = 0;

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ( cnt > 0)
            {
                cnt--;
                audioSource.PlayOneShot(sound3);
            }
        }


        Score = d;
        
        // ごみ量を更新
        int score = Ascore();
        GomiText.text = "ごみ量 : " + i + "点";

        // ゴミをスタックしている数が5個以上の時
        if (i >= 5)
        {
            KeikokuText.text = "ゴミを捨てよう";

        // ゴミをスタックしている数が1個以上の時
        }else if(i <= 1)
        {
            KeikokuText.text = " ";
        }

        // 充電量を減らす
        a -= Time.deltaTime * 2.0f;
        j = Mathf.Floor(a);
        HPslider.value = j / maxHp;

        //GameOver
        if ( HPslider.value <= 0)
        {
            SceneManager.LoadScene("Result");
        }

        // 掃除率
        int Clear = AreaClear();
        GoalText.text = "掃除率 : " + d + "%";

        //ブラックホールのカウント
        blackHolePanel.UpdateBlackHole(blackHole.BlackHoleCount());

    }

    public void OnCollisionEnter(Collision collision)
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        //処理ポイント接触かつゴミのストックがあるときだけ音鳴らす
        if (other.gameObject.tag == "ShoriPoint" && i >= 1)
        {
            audioSource.PlayOneShot(sound2);
        }

        // ゴミタグに接触したとき
        if (other.gameObject.tag == "Gomi")
        {
            // ごみ量が1増える
            i += 1;

            audioSource.PlayOneShot(sound);
        }

        // 処理ポイントタグに接触した時
        else if (other.gameObject.tag == "ShoriPoint")
        {
            // 進捗率の計算
            c = c + i;
            c = c * 2;

            // ゴミスタックを初期化
            i = 0;

            // 進捗率
            d = d + c;

            // 進捗率の計算を初期化
            c = 0;
        }
        else if( other.gameObject.tag == "Heal")
        {
            audioSource.PlayOneShot(sound4);

            // Healタグに接触すると充電量が5回復する
            a += 5;
        }
        else if(other.gameObject.tag == "Syougaibutu")
        {
            //Syougaibutuタグに接触するとゴミをすべて吐き出す(iを0に)
            audioSource.PlayOneShot(sound5);
            i = 0;
        }
        //ブラックホールの回復くんは今はとりあえずなかったことに
        /*else if(other.gameObject.tag == "BlackHoleHeal")
        {
            cnt++;
        }*/
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