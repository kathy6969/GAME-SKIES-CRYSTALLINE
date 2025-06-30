using UnityEngine;
using UnityEngine.UI;

public class MobileInputUI : MonoBehaviour
{
    private BlockController blockController;
    public RawImage targetRawImage;
    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (blockController == null)
            FindPlayer();  // Khi load lại level, tìm lại player mới
    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            blockController = player.GetComponent<BlockController>();
    }

    public void MoveLeft()
    {
        blockController?.Move(Vector3.left);
    }

    public void MoveRight()
    {
        blockController?.Move(Vector3.right);
    }

    public void MoveUp()
    {
        blockController?.Move(Vector3.forward);
    }

    public void MoveDown()
    {
        blockController?.Move(Vector3.back);
    }
    public void ToggleRawImage()
    {
        if (targetRawImage != null)
            targetRawImage.enabled = !targetRawImage.enabled;
    }
    void Awake()
    {
        if (targetRawImage != null)
            targetRawImage.enabled = false;  
    }
}
