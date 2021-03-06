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
                //右向きにフリック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
            else
            {
                //タッチを検出
                Direction = "touch";
            }
        }

        switch (Direction)
        {
            case "up":
                //上フリックされた時の処理
                autoRun.Jump();
                break;

            case "right":
                //右フリックされた時の処理
                autoRun.MoveToRight();
                break;

            case "left":
                //左フリックされた時の処理
                autoRun.MoveToLeft();
                break;

            case "touch":
                //タッチされた時の処理
                blackHole.Shot();
                break;
        }
    }
}
