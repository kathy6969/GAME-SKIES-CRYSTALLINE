using UnityEngine;

public class WinBlockTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Đã chạm khối WIN → chuyển màn!");
            LevelManager.Instance.LoadNextLevel();
        }
    }
}
