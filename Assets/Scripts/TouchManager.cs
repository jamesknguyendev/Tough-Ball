using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchManager : MonoBehaviour
{
    Rigidbody2D ballRb;
    //private Ball ball;
    private Touch touch;

    private SoundManager soundManager;

    private float speed = 3f;
    //private Vector2 startPos;
    //private Vector2 movingPos;
    //private Vector2 endPos;
    //private float initialVelocity;
    //private float percent;

    private bool isUp;
    
    void Awake()
    {
        ballRb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
       //ball = ballRb.gameObject.GetComponent<Ball>();
        isUp = false;
        ballRb.velocity = Vector2.down * 5f;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        Touch();
    }

    void Touch()
    {
       
//        if (ball.IsOnTheGround() && Input.touchCount>0)
//        {
//            touch = Input.GetTouch(0);
//            switch (touch.phase)
//            {
//                case TouchPhase.Began:
//                    startPos = touch.position;
//                    percentUI.SetActive(true);
//                    break;
//                    case TouchPhase.Moved:
//                        movingPos = touch.position;
//                        initialVelocity = Vector2.Distance(startPos, movingPos);
//                        UpdatePercent(initialVelocity);
//                        break;
//                        case TouchPhase.Ended:
//                            percentUI.SetActive(false);
//                            endPos = touch.position;
//                            initialVelocity = Vector2.Distance(startPos, endPos);
//                            if (initialVelocity >= MAX_VELOCITY)
//                                initialVelocity = MAX_VELOCITY;
//                            ballRb.velocity = new Vector2(0f,initialVelocity/10f);
//                            
//                            break;
//            }
//        }
        #if UNITY_ANDROID 
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Ended:
                    soundManager.PlayJump();
                    if (isUp)
                    {
                        
                        ballRb.velocity = Vector2.down * speed;
                        
                    }
                    else
                    {
                        ballRb.velocity = Vector2.up * speed;
                    }
                    isUp = !isUp;
                    break;
            }
        }
        #endif
        
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            soundManager.PlayJump();
            if (isUp)
            {
                ballRb.velocity = Vector2.down * speed;
                        
            }
            else
            {
                ballRb.velocity = Vector2.up * speed;
            }
            isUp = !isUp;
        }
        #endif
       
    }
//
//    void UpdatePercent(float measuredVelocity)
//    {
//        percent = (measuredVelocity / MAX_VELOCITY);
//        if (percent >= 1f)
//            percentText.text = 1f.ToString("p1");
//        else
//        {
//            percentText.text = percent.ToString("p1");
//        }
//    }
}
