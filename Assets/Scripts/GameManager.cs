using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Touch tempTouch;
    private Vector3 touchedPos = new Vector3(0, 0, 0);
    private Vector2 startPos;
    private Vector2 currentPos;
    private float startPosX;
    private float startPosY;
    private float currentPosX;
    private float currentPosY;
    private float resultPosX;
    private float resultPosY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TouchCommand();
    }

    void TouchCommand()
    {
        if (Input.touchCount == 1)
        {
            tempTouch = Input.GetTouch(0);
            //터치 시작시
            if (tempTouch.phase == TouchPhase.Began)
            {
                touchedPos = Camera.main.ScreenToWorldPoint(tempTouch.position);
                startPos = touchedPos;
                startPosX = touchedPos.x;
                startPosY = touchedPos.y;
            }
            //터치 떼는 순간
            else if (tempTouch.phase == TouchPhase.Ended)
            {
                touchedPos = Camera.main.ScreenToWorldPoint(tempTouch.position);
                currentPos = touchedPos;
                currentPosX = touchedPos.x;
                currentPosY = touchedPos.y;
                resultPosX = currentPosX - startPosX;
                resultPosY = currentPosY - startPosY;
                //Debug.Log(resultPosX + ", " + resultPosY);
                float angle = Vector3.SignedAngle(Vector3.right, currentPos - startPos, transform.forward);
                //Vector2.Angle(Vector2.right,currentPos-startPos);
                //Debug.Log("각도 : " + angle);
                //Debug.Log("거리 : " + Vector3.Distance(startPos, currentPos));
                if (Vector3.Distance(startPos, currentPos) < 0.5f)
                {
                    Debug.Log("평타");
                    Player.instance.FlatHit();
                }
                //왼쪽에서 오른쪽
                else if (angle >= -20 && angle <= 20)
                {
                    Debug.Log("왼쪽에서 오른쪽으로");
                    Player.instance.LeftToRightSlide();
                }
                //위에서 아래
                else if (angle >= -110 && angle <= -70)
                {
                    Debug.Log("위에서 아래로");
                    Player.instance.UpToDownSlide();
                }

                //아래에서 위
                else if (angle >= 70 && angle <= 110)
                {
                    Debug.Log("아래에서 위로");
                    Player.instance.DonwToUpSlide();
                }

            }
        }
    }
}
