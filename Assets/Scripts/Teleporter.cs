using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [Header("Centang jika ini Portal Terakhir (Menang)")]
    public bool isPortalMenang = false;

    [Header("Tujuan Teleport (Jika Bukan Portal Menang)")]
    public Transform tujuanPosisi;
    public string namaSceneTujuan;
    public ArenaManager arenaMapBerikutnya;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPortalMenang)
            {
                UIManager ui = FindFirstObjectByType<UIManager>();
                if (ui != null)
                {
                    ui.TampilkanMenang();
                }
                return;
            }

            if (tujuanPosisi != null)
            {
                other.transform.position = tujuanPosisi.position;

                if (arenaMapBerikutnya != null)
                {
                    arenaMapBerikutnya.ResetArena();
                }
                else
                {
                    ArenaManager manager = FindFirstObjectByType<ArenaManager>();
                    if (manager != null) manager.ResetArena();
                }
            }
            else if (!string.IsNullOrEmpty(namaSceneTujuan))
            {
                SceneManager.LoadScene(namaSceneTujuan);
            }
        }
    }
}