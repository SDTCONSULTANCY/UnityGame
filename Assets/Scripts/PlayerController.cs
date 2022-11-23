using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, limitX, xSpeed;
    [SerializeField] DynamicJoystick dynamicJoystick;
    private void Start()
    {
        dynamicJoystick = FindObjectOfType<DynamicJoystick>();

    }
    void Update()
    {
        float newX = 0;
        float touchXDelta = 0;
        touchXDelta = dynamicJoystick.Horizontal;

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
