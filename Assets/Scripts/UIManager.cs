using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelRespawn;

    public static bool sudahMulai = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatic()
    {
        sudahMulai = false;
    }

    void Start()
    {
        if (panelRespawn != null) panelRespawn.SetActive(false);

        if (!sudahMulai)
        {
            // Baru pertama kali pencet Play -> tampilkan menu Play
            if (panelStart != null) panelStart.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            // Habis pencet Respawn di dalam game -> langsung main
            if (panelStart != null) panelStart.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MulaiGame()
    {
        sudahMulai = true;
        if (panelStart != null) panelStart.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TampilkanRespawn()
    {
        if (panelRespawn != null) panelRespawn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RespawnGame()
    {
        sudahMulai = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}