using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInstantiate : MonoBehaviour
{
    public GameObject SoundPrefab;
    void Update()
    {
        if (Input.GetKeyDown("s"))//����if���̒��g�Ƃ��ς�����AInstantiate�̂Ƃ������Ƃ���������R�s�y���Ďg���Ă�
        {
            Instantiate(SoundPrefab, new Vector3(0, 0, 0),
                    Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
