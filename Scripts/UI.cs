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

        // �[�d�ʂ�MAX����X�^�[�g
        HPslider.value = 1;

        //�X�g�b�N�ƒB�������J�n����0��
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
        
        // ���ݗʂ��X�V
        int score = Ascore();
        GomiText.text = "���ݗ� : " + i + "�_";

        // �S�~���X�^�b�N���Ă��鐔��5�ȏ�̎�
        if (i >= 5)
        {
            KeikokuText.text = "�S�~���̂Ă悤";

        // �S�~���X�^�b�N���Ă��鐔��1�ȏ�̎�
        }else if(i <= 1)
        {
            KeikokuText.text = " ";
        }

        // �[�d�ʂ����炷
        a -= Time.deltaTime * 2.0f;
        j = Mathf.Floor(a);
        HPslider.value = j / maxHp;

        //GameOver
        if ( HPslider.value <= 0)
        {
            SceneManager.LoadScene("Result");
        }

        // �|����
        int Clear = AreaClear();
        GoalText.text = "�|���� : " + d + "%";

        //�u���b�N�z�[���̃J�E���g
        blackHolePanel.UpdateBlackHole(blackHole.BlackHoleCount());

    }

    public void OnCollisionEnter(Collision collision)
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        //�����|�C���g�ڐG���S�~�̃X�g�b�N������Ƃ��������炷
        if (other.gameObject.tag == "ShoriPoint" && i >= 1)
        {
            audioSource.PlayOneShot(sound2);
        }

        // �S�~�^�O�ɐڐG�����Ƃ�
        if (other.gameObject.tag == "Gomi")
        {
            // ���ݗʂ�1������
            i += 1;

            audioSource.PlayOneShot(sound);
        }

        // �����|�C���g�^�O�ɐڐG������
        else if (other.gameObject.tag == "ShoriPoint")
        {
            // �i�����̌v�Z
            c = c + i;
            c = c * 2;

            // �S�~�X�^�b�N��������
            i = 0;

            // �i����
            d = d + c;

            // �i�����̌v�Z��������
            c = 0;
        }
        else if( other.gameObject.tag == "Heal")
        {
            audioSource.PlayOneShot(sound4);

            // Heal�^�O�ɐڐG����Ə[�d�ʂ�5�񕜂���
            a += 5;
        }
        else if(other.gameObject.tag == "Syougaibutu")
        {
            //Syougaibutu�^�O�ɐڐG����ƃS�~�����ׂēf���o��(i��0��)
            audioSource.PlayOneShot(sound5);
            i = 0;
        }
        //�u���b�N�z�[���̉񕜂���͍��͂Ƃ肠�����Ȃ��������Ƃ�
        /*else if(other.gameObject.tag == "BlackHoleHeal")
        {
            cnt++;
        }*/
    }

    // �ȉ��͊֐�
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