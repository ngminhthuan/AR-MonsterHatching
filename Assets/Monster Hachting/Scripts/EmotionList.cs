using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmotionList : MonoBehaviour
{
    [SerializeField] Button DanceBtn;
    [SerializeField] Button WaveBtn;
    [SerializeField] Button YesBtn;
    [SerializeField] Button NoBtn;

    [Header("Joystick")]
    [SerializeField] Joystick _emotionJoystick;
    [SerializeField] RectTransform joystickCenter;
    [SerializeField] RectTransform joystickHandle;
    [SerializeField] float deadZone = 10f;

    private int currentEmoteIndex = -1;
    private Button[] emotionButtons;

    private void Awake()
    {
        emotionButtons = new Button[] { DanceBtn, WaveBtn, YesBtn, NoBtn };
        RegisterBtnActions();
    }

    private void Update()
    {
        Vector2 direction = joystickHandle.position - joystickCenter.position;

        if (direction.magnitude > deadZone)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle < 0) angle += 360;

            int total = emotionButtons.Length;
            float sectorSize = 360f / total;
            int index = Mathf.FloorToInt(angle / sectorSize);

            if (index != currentEmoteIndex)
            {
                Debug.Log(index);
                currentEmoteIndex = index;
                HighlightSelected(index);
            }
        }
        else
        {
            ClearHighlight();
            currentEmoteIndex = -1;
        }
    }

    private void HighlightSelected(int index)
    {
        ClearHighlight();
        var colors = emotionButtons[index].colors;
        colors.normalColor = Color.yellow;
        emotionButtons[index].colors = colors;
    }

    private void ClearHighlight()
    {
        foreach (var btn in emotionButtons)
        {
            var colors = btn.colors;
            colors.normalColor = Color.white;
            btn.colors = colors;
        }
    }

    public void RegisterBtnActions()
    {
        DanceBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.DANCE));
        WaveBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.WAVE));
        YesBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.YES));
        NoBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.NO));
        _emotionJoystick.ActionAfterDrag = () => ConfirmEmotion();
    }

    public void PlayerAnimation(PlayerAnimationType playerAnimationType)
    {
        PlayerManager.Instance.PlayAnimation(playerAnimationType);
    }

    // Call this when releasing joystick to play animation
    public void ConfirmEmotion()
    {
        if (currentEmoteIndex != -1)
        {
            emotionButtons[currentEmoteIndex].onClick.Invoke();
        }
    }
}
