using Lab.Scripts.Util;
using UnityEngine;

namespace Lab.Scripts.UI {
public class Gauge : MonoBehaviour {
    private Stamina _stamina;
    private int _sp;

    private void Start() {
        _stamina = FindObjectOfType<Stamina>();
    }

    private void Update() {
        _sp = (int) _stamina.GetCurrentSp();
    }
    
    private void OnGUI() {
        int w = Screen.width, h = Screen.height;

        var style = new GUIStyle();

        var rect = new Rect(0, 525, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        var text = $"Stamina : {_sp}";
        GUI.Label(rect, text, style);
    }
}
}