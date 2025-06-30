using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject[] levelPrefabs;  // Danh sách prefab tất cả level
    public int currentLevelIndex = 0;

    public GameObject currentLevel;
    public GameObject currentLevelPrefab;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void LoadLevel(GameObject levelPrefab)
    {
        if (currentLevel != null) Destroy(currentLevel);

        currentLevelPrefab = levelPrefab;
        currentLevel = Instantiate(levelPrefab);
    }

    public void RestartLevel()
    {
        LoadLevel(currentLevelPrefab);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex < levelPrefabs.Length)
        {
            LoadLevel(levelPrefabs[currentLevelIndex]);
        }
        else
        {
            Debug.Log("🎉 Hết level rồi!");
            // Tuỳ bạn: load lại level 0, show win screen, v.v.
        }
    }
    void Start()
    {
        Debug.Log("Khởi động game, tải level...");
        LoadLevel(levelPrefabs[currentLevelIndex]);
    }
}
