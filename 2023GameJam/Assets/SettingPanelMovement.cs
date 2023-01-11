using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanelMovement : MonoBehaviour
{
    RectTransform rect;
    private void Awake() {
        rect = GetComponent<RectTransform>();
    }
    public void SettingPanel(){
        rect.anchoredPosition = new Vector2(-1000, 0);
    }
}
