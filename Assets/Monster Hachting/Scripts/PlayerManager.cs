using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public Animator _playerAnimator;

    [SerializeField] ImageTargetBehaviour _currentPlayerTarget;

    void Awake()
    {
        this.Init();
        this.LoadPlayerData();
    }
    private void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void PlayAnimation(PlayerAnimationType playerAnimationType)
    {
        switch (playerAnimationType)
        {
            case PlayerAnimationType.DANCE:
                _playerAnimator.SetTrigger(AnimationTriggerKey.DanceTrigger);
                break;
            case PlayerAnimationType.WAVE:
                _playerAnimator.SetTrigger(AnimationTriggerKey.WaveTrigger);
                break;
            case PlayerAnimationType.YES:
                _playerAnimator.SetTrigger(AnimationTriggerKey.YesTrigger);
                break;
            case PlayerAnimationType.NO:
                _playerAnimator.SetTrigger(AnimationTriggerKey.NoTrigger);
                break;
        }
    }

    public void PlayerAttack()
    {
        _playerAnimator.SetTrigger(AnimationTriggerKey.AttackTrigger);
    }

    public void LoadPlayerData()
    {
        Debug.Log(_currentPlayerTarget.ImageTargetType.ToString());
    }
}

public enum PlayerAnimationType
{
    RUNNING,
    DANCE,
    WAVE,
    YES,
    NO,
}

public class AnimationTriggerKey
{
    public static string AttackTrigger = "isAttack";
    public static string WaveTrigger = "isWave";
    public static string DanceTrigger = "isDance";
    public static string NoTrigger = "isNo";
    public static string YesTrigger = "isYes";
}