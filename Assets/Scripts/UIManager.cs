using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class UIManager : MonoBehaviour
{
    [Header("Panel UI")]
    public GameObject panelStart;
    public GameObject panelRespawn;
    public GameObject panelWin;

    [Header("HUD Teks (HP & Damage)")]
    public Text textHP;
    public Text textDamage;

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

    public void UpdateUIStatus(int hpSekarang, int maxHp, int damageSekarang)
    {
        if (textHP != null) textHP.text = "HP: " + hpSekarang + "/" + maxHp;
        if (textDamage != null) textDamage.text = "Damage: " + damageSekarang;
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