using UnityEngine;

public class PlayerFallDetector : MonoBehaviour
{
    public float fallThreshold = -5f;

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Rơi khỏi map → chơi lại level!");
            LevelManager.Instance.RestartLevel();
        }
    }
}
