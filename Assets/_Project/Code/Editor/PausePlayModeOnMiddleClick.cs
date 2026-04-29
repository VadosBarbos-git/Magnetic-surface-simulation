
#if UNITY_EDITOR
using UnityEditor; 
using System.Runtime.InteropServices;

[InitializeOnLoad]
public static class PausePlayModeOnMiddleClick
{
    // Windows API для глобального клавишного/мышиного отслеживания
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    private const int VK_MBUTTON = 0x04; // средняя кнопка мыши


    private static bool waiting = false;

    static PausePlayModeOnMiddleClick()
    {
        EditorApplication.update += Update;
    }

    private static void Update()
    {
        if (!EditorApplication.isPlaying) return;

        bool middle = (GetAsyncKeyState(VK_MBUTTON) & 0x8000) != 0;

        if (middle)
        {
            if (!waiting)
            {
                // Toggle Play Mode pause
                EditorApplication.isPaused = !EditorApplication.isPaused;
                waiting = true; // чтобы не зацепило несколько кадров подряд
            }
        }
        else
        {
            waiting = false;
        }
    }
}
#endif
