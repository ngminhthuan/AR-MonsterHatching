using UnityEngine;

public abstract class APlayerComponent : MonoBehaviour
{
    PlayerManager playerManager;
    public void SetPlayerManager(PlayerManager playerManager)
    {
        this.playerManager = playerManager;
    }
}
