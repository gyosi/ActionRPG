using UnityEngine;
using System.Collections;

public class CameraMoving : MonoBehaviour {

    public GameObject Player;

    public float offsetX = 0f;
    public float offsetY = 2f;
    public float offsetZ = -3f;
    public float followSpeed = 2;

    Vector3 cameraPosition;

    void LateUpdate()
    {
        cameraPosition.x = Player.transform.position.x + offsetX;
        cameraPosition.y = Player.transform.position.y + offsetY;
        cameraPosition.z = Player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }

}
