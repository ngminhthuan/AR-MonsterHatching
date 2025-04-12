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
                _playerAnimator.SetTrigger(AnimationActiveKey.DanceTrigger);
                break;
            case PlayerAnimationType.WAVE:
                _playerAnimator.SetTrigger(AnimationActiveKey.WaveTrigger);
                break;
            case PlayerAnimationType.YES:
                _playerAnimator.SetTrigger(AnimationActiveKey.YesTrigger);
                break;
            case PlayerAnimationType.NO:
                _playerAnimator.SetTrigger(AnimationActiveKey.NoTrigger);
                break;
        }
    }
    
    public void PlayAnimation(PlayerAnimationType playerAnimationType, bool isActive)
    {
        switch (playerAnimationType)
        {
            case PlayerAnimationType.RUNNING:
                _playerAnimator.SetBool(AnimationActiveKey.RunningActive, isActive);
                break;
        }
    }

    public void PlayerAttack()
    {
        _playerAnimator.SetTrigger(AnimationActiveKey.AttackTrigger);
    }

    public void LoadPlayerData()
    {

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

public class AnimationActiveKey
{
    public static string AttackTrigger = "isAttack";
    public static string WaveTrigger = "isWave";
    public static string DanceTrigger = "isDance";
    public static string NoTrigger = "isNo";
    public static string YesTrigger = "isYes";
    public static string RunningActive = "isRunning";
}