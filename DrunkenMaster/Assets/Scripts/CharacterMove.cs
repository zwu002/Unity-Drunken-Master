using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    Vector3 position;

    public float minPosX;
    public float maxPosX;
    public float speed;

    bool currentPlatformAndroid = false;

    // swipe control for Android
    public float maxTime;
    public float minSwipeDist;

    float startTime;
    float endTime;

    Vector3 startPos;
    Vector3 endPos;
    float swipeDistance;
    float swipeTime;

    void Awake()
    {

#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif
    }

    void Start()
    {
        position = transform.position;

        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        }
        else
        {
            Debug.Log("Windows");
        }
    }

    void Update()
    {
        if (currentPlatformAndroid == false)
        {
            if (Input.GetKeyDown("d"))
            {
                position.x += 0.5f * Time.timeScale;
            }

            if (Input.GetKeyDown("a"))
            {
                position.x -= 0.5f * Time.timeScale;
            }

            position.x = Mathf.Clamp(position.x, minPosX, maxPosX);

            transform.position = position;
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;
                    startPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    endTime = Time.time;
                    endPos = touch.position;

                    swipeDistance = (endPos - startPos).magnitude;
                    swipeTime = endTime - startTime;

                    if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                    {
                        Swipe();
                    }
                }

                position.x = Mathf.Clamp(position.x, minPosX, maxPosX);

                transform.position = position;

            }
        }
    }

    void Swipe()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            Debug.Log("Horizontal Swipe");

            if (distance.x > 0)
            {
                position.x += 0.5f * Time.timeScale;
            }
            else if (distance.x < 0)
            {
                position.x -= 0.5f * Time.timeScale;
            }
        }
    }
}
