using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float minXClamp;
    [SerializeField] float maxXClamp;
    [SerializeField] float minYClamp;
    [SerializeField] float maxYClamp;

    [Range (0, 1)]
    public float smoothTime;

    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 cameraPos = transform.position;

        cameraPos.x = Mathf.Clamp(player.transform.position.x, minXClamp, maxXClamp);
        cameraPos.y = Mathf.Clamp(player.transform.position.y, minYClamp, maxYClamp);

        transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, smoothTime);
    }
}
