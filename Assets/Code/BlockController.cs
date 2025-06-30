using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour
{
    public float speed = 300f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            StartCoroutine(Roll(Vector3.right));
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            StartCoroutine(Roll(Vector3.left));
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            StartCoroutine(Roll(Vector3.forward));
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            StartCoroutine(Roll(Vector3.back));
    }

    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;

        float angle = 90f;
        Vector3 rotationCenter = GetRotationCenter(direction);
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (angle > 0)
        {
            float rotateAngle = Mathf.Min(Time.deltaTime * speed, angle);
            transform.RotateAround(rotationCenter, rotationAxis, rotateAngle);
            angle -= rotateAngle;
            yield return null;
        }

        // Fix rotation (làm tròn lại)
        transform.rotation = Quaternion.Euler(
            Mathf.Round(transform.rotation.eulerAngles.x / 90f) * 90f,
            Mathf.Round(transform.rotation.eulerAngles.y / 90f) * 90f,
            Mathf.Round(transform.rotation.eulerAngles.z / 90f) * 90f
        );

        // Fix vị trí (làm tròn)
        transform.position = new Vector3(
            Mathf.Round(transform.position.x * 2) / 2f,
            Mathf.Round(transform.position.y * 2) / 2f,
            Mathf.Round(transform.position.z * 2) / 2f
        );

        isMoving = false;
    }

    Vector3 GetRotationCenter(Vector3 dir)
    {
        Vector3 pos = transform.position;
        Vector3 down = Vector3.down;

       
        return pos + (dir + down) * 0.5f;
    }
}
