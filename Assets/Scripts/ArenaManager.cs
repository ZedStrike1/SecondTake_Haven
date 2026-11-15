using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [Header("Pengaturan Arena")]
    public int totalMinions = 5;
    public GameObject bossObject;
    public GameObject portalOrDoor;
    public int bonusDamageReward = 15;

    private int killedMinions = 0;

    void Start()
    {
        ResetArena();
    }


    public void ResetArena()
    {
        killedMinions = 0;
        if (bossObject != null) bossObject.SetActive(false);
        if (portalOrDoor != null) portalOrDoor.SetActive(false);
        Debug.Log("Tracker Arena di-reset! Musuh mati: 0/" + totalMinions);
    }

    public void OnMinionKilled()
    {
        killedMinions++;
        Debug.Log("Musuh mati: " + killedMinions + "/" + totalMinions);

        if (killedMinions >= totalMinions)
        {
            if (bossObject != null) bossObject.SetActive(true);
        }
    }

    public void OnBossKilled()
    {
        Debug.Log("Boss Mati! Damage naik & Pintu terbuka!");
        PlayerCombat player = FindFirstObjectByType<PlayerCombat>();
        if (player != null)
        {
            player.IncreaseDamage(bonusDamageReward);
        }

        if (portalOrDoor != null) portalOrDoor.SetActive(true);
    }
}