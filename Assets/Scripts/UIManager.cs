using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Panel UI")]
    public GameObject panelStart;
    public GameObject panelRespawn;
    public GameObject panelWin;

    public static bool sudahMulai = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatic()
    {
        sudahMulai = false;
    }

    void Start()
    {
        if (panelRespawn != null) panelRespawn.SetActive(false);
        if (panelWin != null) panelWin.SetActive(false);

        if (!sudahMulai)
        {
            if (panelStart != null) panelStart.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
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
        if (panelRespawn != null)
        {
            panelRespawn.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void TampilkanMenang()
    {
        if (panelWin != null)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("Panel Win belum dimasukkan ke slot Panel Win di UIManager!");
        }
    }

    public void RespawnGame()
    {
        sudahMulai = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainLagiDariAwal()
    {
        sudahMulai = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}