
#if UNITY_EDITOR
using UnityEditor; 
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class ReloadCurentScene
{ 
    // Update is called once per frame
    [MenuItem("Tools/Reload Scene #r")] //  Shift+R   
    private static void ReloadScene()
    {
        if (!EditorApplication.isPlaying)
            return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
#endif