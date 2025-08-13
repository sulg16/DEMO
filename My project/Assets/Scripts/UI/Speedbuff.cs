// UISpeedBuff.cs
using TMPro;
using UnityEngine;

public class UISpeedBuff : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;   // ���ǵ�����ؽ�Ʈ
    [SerializeField] GameObject panel;       // �г�

    PlayerController ctrl;

    void Start()
    {
        ctrl = CharacterManager.Instance.Player.controller;
        if (panel) panel.SetActive(false);
    }

    void Update()
    {
        if (ctrl == null) return;

        if (ctrl.IsSpeedBoostActive)
        {
            if (panel) panel.SetActive(true);
            text.text = $"Speed x{ctrl.CurrentSpeedMultiplier:F1}  {ctrl.SpeedBoostRemain:F1}s";
        }
        else
        {
            if (panel) panel.SetActive(false);
            text.text = "";
        }
    }
}
