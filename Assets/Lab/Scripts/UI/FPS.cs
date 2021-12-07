using UnityEngine;

namespace Lab.Scripts.UI {
public class FPS : MonoBehaviour {
    // FROM http://wiki.unity3d.com/index.php?title=FramesPerSecond
    private float _deltaTime;

    private void Update() {
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
    }

    private void OnGUI() {
        int w = Screen.width, h = Screen.height;

        var style = new GUIStyle();

        var rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        var msCs = _deltaTime * 1000.0f;
        var fps = 1.0f / _deltaTime;
        var text = $"{msCs:0.0} ms ({fps:0.} fps)";
        GUI.Label(rect, text, style);
    }
}
}