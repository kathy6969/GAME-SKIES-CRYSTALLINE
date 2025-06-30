using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject targetObject;  // Khối cần bật/tắt
    private bool isToggled = false;

    private void Start()
    {
        // Ẩn khối ngay khi bắt đầu game
        if (targetObject != null)
            targetObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isToggled = !isToggled;
            targetObject.SetActive(isToggled);
        }
    }
}
