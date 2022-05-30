using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotchSousa : MonoBehaviour
{

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    public AutoRun autoRun;
    public BlackHole blackHole;

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            GetDirection();
        }
    }
    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "";

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //�E�����Ƀt���b�N
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //�������Ƀt���b�N
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //������Ƀt���b�N
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //�������̃t���b�N
                Direction = "down";
            }
            else
            {
                //�^�b�`�����o
                Direction = "touch";
            }
        }

        switch (Direction)
        {
            case "up":
                //��t���b�N���ꂽ���̏���
                autoRun.Jump();
                break;

            case "right":
                //�E�t���b�N���ꂽ���̏���
                autoRun.MoveToRight();
                break;

            case "left":
                //���t���b�N���ꂽ���̏���
                autoRun.MoveToLeft();
                break;

            case "touch":
                //�^�b�`���ꂽ���̏���
                blackHole.Shot();
                break;
        }
    }
}
