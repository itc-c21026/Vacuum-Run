using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        // �X�y�[�X�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.A))
        {
            // �X�N���[���V���b�g��ۑ�
            CaptureScreenShot("ScreenShot.png");
        }
    }

    // ��ʑS�̂̃X�N���[���V���b�g��ۑ�����
    private void CaptureScreenShot(string filePath)
    {
        ScreenCapture.CaptureScreenshot(filePath);
    }
}