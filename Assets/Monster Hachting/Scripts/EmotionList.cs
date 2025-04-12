using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmotionList : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button DanceBtn;
    [SerializeField] Button WaveBtn;
    [SerializeField] Button YesBtn;
    [SerializeField] Button NoBtn;

    public void Awake()
    {
        RegisterBtnActions();
    }
    public void RegisterBtnActions()
    {
        DanceBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.DANCE));
        WaveBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.WAVE));
        YesBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.YES));
        NoBtn.onClick.AddListener(() => PlayerAnimation(PlayerAnimationType.NO));
    }

    public void PlayerAnimation(PlayerAnimationType playerAnimationType)
    {
        PlayerManager.Instance.PlayAnimation(playerAnimationType);
    }
}
