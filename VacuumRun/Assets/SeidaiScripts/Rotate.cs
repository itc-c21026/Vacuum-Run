using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateX;
    public float RotateY;
    public float RotateZ;
    void Update()
    {
        transform.Rotate(new Vector3(RotateX, RotateY, RotateZ) * Time.deltaTime, Space.World);//�I�u�W�F�N�g����]�����邱�Ƃ��ł��܂��I�@
                                                                                               //�J�b�R���̐�����M�邱�Ƃň�b�����艽�x��]�����邩���߂邱�Ƃ��ł��܂��I�I
                                                                                               //Space.world = ���[���h���ŉ�]
    }
}
