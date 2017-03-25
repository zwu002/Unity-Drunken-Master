using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    Vector3 position;

    public float minPosX;
    public float maxPosX;
    public float speed;

    bool currentPlatformAndroid = false;

    Rigidbody2D rb;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

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
            position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, minPosX, maxPosX);

            transform.position = position;
        }
    }
}
