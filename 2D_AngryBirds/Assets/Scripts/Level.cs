using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private static int nextLevel=1;
    private Enemy[] enemies;
    private void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in enemies)
        {
            if (enemy != null)
                return;
        }

        nextLevel = nextLevel == 1 ? 2 : 1;
        string levelName = "Level" + nextLevel;
        SceneManager.LoadScene(levelName);

    }
}
