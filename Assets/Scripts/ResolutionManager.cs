using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    
    void Start()
    {
        // Screen.SetResolution(610, 1000, false);
        int targetWidth = 610;
        int targetHeight = 1000;
        
        // Tính toán tỷ lệ DPI
        float dpi = (Screen.dpi == 0) ? 96 : Screen.dpi; // Nếu không có DPI, mặc định là 96
        float scaleFactor = dpi / 96.0f; // Windows mặc định 96 DPI là 100%
        
        // Chỉnh lại độ phân giải dựa trên DPI
        int adjustedWidth = Mathf.RoundToInt(targetWidth * scaleFactor);
        int adjustedHeight = Mathf.RoundToInt(targetHeight * scaleFactor);

        Screen.SetResolution(adjustedWidth, adjustedHeight, false);
    }
}
