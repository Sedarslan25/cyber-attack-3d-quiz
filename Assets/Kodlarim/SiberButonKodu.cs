using UnityEngine;

public class SiberButonKodu : MonoBehaviour
{
    [Header("Soru Ayarları")]
    public int soruID = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Unity 6 için en güncel ve hızlı arama yöntemi:
            OdaYoneticisi yonetici = FindFirstObjectByType<OdaYoneticisi>();
            
            if (yonetici != null)
            {
                yonetici.SoruTetikle(soruID);
            }

            // Buton havada yok olsun
            gameObject.SetActive(false);
        }
    }
}