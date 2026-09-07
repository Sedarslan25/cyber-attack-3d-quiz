using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GirisEkraniYoneticisi : MonoBehaviour
{
    void Start()
    {
        // Kod sahnedeki butonları isimlerine göre kendi buluyor, sürüklemeye SON!
        GameObject baslaObjesi = GameObject.Find("BaslaButonu");
        GameObject cikisObjesi = GameObject.Find("CikisButonu");

        if (baslaObjesi != null)
        {
            Button btnBasla = baslaObjesi.GetComponent<Button>();
            if (btnBasla != null) btnBasla.onClick.AddListener(OyunaBasla);
            else Debug.LogError("HATA: 'BaslaButonu' isimli nesnenin üzerinde 'Button' bileşeni yok!");
        }
        else Debug.LogError("HATA: Sahnede 'BaslaButonu' adında bir nesne bulunamadı!");

        if (cikisObjesi != null)
        {
            Button btnCikis = cikisObjesi.GetComponent<Button>();
            if (btnCikis != null) btnCikis.onClick.AddListener(OyunuKapat);
            else Debug.LogError("HATA: 'CikisButonu' isimli nesnenin üzerinde 'Button' bileşeni yok!");
        }
        else Debug.LogError("HATA: Sahnede 'CikisButonu' adında bir nesne bulunamadı!");

        // Menüde fareyi serbest bırak
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OyunaBasla()
    {
        SceneManager.LoadScene("outpost with snow"); 
    }

    void OyunuKapat()
    {
        Application.Quit();
        Debug.Log("Giriş ekranından çıkış yapıldı!");
    }
}