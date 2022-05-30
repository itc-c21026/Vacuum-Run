using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MonoBehaviour
{
    //�������s�A�ǖʁA�V��ړ��S�����i�����
    const int MinLaneX = -3;
    const int MaxLaneX = 3;
    const float LaneWidthX = 1.5f;

    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;
    int targetLaneX;

    public GameObject Stage;
    public float gravity;
    public float speedZ;
    public float speedY;
    public float speedX;
    public float speedJump;
    public float accelerationZ;
    bool coroutineBool = false;

    const float StunDuration = 0.5f;
    float recoverTime = 0.0f;

    public UI ui;
    public int score;

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    public BlackHole blackHole;


    bool IsStun()
    {
        return recoverTime > 0.0f;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (Input.GetKeyDown("left")) MoveToLeft();
        if (Input.GetKeyDown("right")) MoveToRight();
        if (Input.GetKeyDown("space")) Jump();

        if (IsStun())
        {

            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            float ratioX = (targetLaneX * LaneWidthX - transform.position.x) / LaneWidthX;
            moveDirection.x = ratioX * speedX;

            score = UI.Ascore();//���\�ቺ
            if (score >= 5)
            {
                moveDirection.x *= 0.4f;
            }

        }

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        moveDirection.y -= gravity * Time.deltaTime;

        if (controller.isGrounded) moveDirection.y = 0;
    }

    public void MoveToLeft()
    {
        if (IsStun()) return;

        if (targetLaneX > MinLaneX)
            targetLaneX--;
        else
        {
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("LeftRotation");
            }
            targetLaneX = MaxLaneX;
        }
    }
    public void MoveToRight()
    {
        if (IsStun()) return;

        if (targetLaneX < MaxLaneX)
            targetLaneX++;
        else
        {
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightRotation");
            }
            targetLaneX = MinLaneX;
        }
    }
    public void Jump()
    {
        if (IsStun()) return;

        if (!coroutineBool && controller.isGrounded)
        {
            moveDirection.y = speedJump;
            targetLaneX = -targetLaneX;
            coroutineBool = true;
            StartCoroutine("JumpRotation");
        }
    }
    IEnumerator JumpRotation()
    {
        for (int turn = 0; turn < 30; turn++)
        {
            Stage.transform.Rotate(0, 0, 6);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
    }
    IEnumerator LeftRotation()
    {
        moveDirection.y = speedJump * -3.0f;
        for (int turn = 0; turn < 15; turn++)
        {
            Stage.transform.Rotate(0, 0, 6);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
    }
    IEnumerator RightRotation()
    {
        moveDirection.y = speedJump * -3.0f;
        for (int turn = 0; turn < 15; turn++)
        {
            Stage.transform.Rotate(0, 0, -6);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (IsStun()) return;

        if (other.gameObject.tag == "Syougaibutu")
        {
            recoverTime = StunDuration;
            Destroy(other.gameObject, 0.5f);
        }
    }
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
                Jump();
                break;

            case "right":
                //�E�t���b�N���ꂽ���̏���
                MoveToRight();
                break;

            case "left":
                //���t���b�N���ꂽ���̏���
                MoveToLeft();
                break;

            case "touch":
                //�^�b�`���ꂽ���̏���
                blackHole.Shot();
                break;
        }
    }
}