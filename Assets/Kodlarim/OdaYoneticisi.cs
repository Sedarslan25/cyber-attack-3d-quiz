using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OdaYoneticisi : MonoBehaviour
{
    [Header("Arayüz Elemanları")]
    public GameObject soruPaneli;
    public TextMeshProUGUI soruMetniYazisi;
    public TextMeshProUGUI skorYazisi;
    public TextMeshProUGUI virusYazisi;
    public Button butonA;
    public Button butonB;

    [Header("Bölüm Ayarları")]
    public string yuklenecekSahneAdi; 
    public bool sonOdaMi = false; // 3. odada buna Unity içinden tik atacaksın!

    private int cevaplananSoruSayisi = 0; 
    private int dogruCevapSayisi = 0;      
    private int toplamSoruSayisi = 10; 
    private int gecerliSoruID = 0;
    private int sistemVirusOrani = 100;

    // 30 sorunun tamamını tek hafızada tutmak için kapasiteyi 31 yapıyoruz
    private string[] sorular = new string[31];
    private string[] siklarA = new string[31];
    private string[] siklarB = new string[31];
    private string[] dogruCevaplar = new string[31];

    void Start()
    {
        SorulariHazirla();
        ArayuzGuncelle();
        if (butonA != null) butonA.onClick.AddListener(() => CevapKontrol("A"));
        if (butonB != null) butonB.onClick.AddListener(() => CevapKontrol("B"));
        if (soruPaneli != null) soruPaneli.SetActive(false);
    }

    void SorulariHazirla()
    {
        // ==================== 1. ODA SORULARI (1 - 10) ====================
        sorular[1] = "Soru 1: Fatih Sultan Mehmet'in İstanbul'u fethettiği tarihi yıl hangisidir?";
        siklarA[1] = "A) 1453"; siklarB[1] = "B) 1299"; dogruCevaplar[1] = "A";

        sorular[2] = "Soru 2: Dünyanın en uzun nehri olan ve Afrika kıtasında yer alan nehir hangisidir?";
        siklarA[2] = "A) Amazon Nehri"; siklarB[2] = "B) Nil Nehri"; dogruCevaplar[2] = "B";

        sorular[3] = "Soru 3: Cumhuriyetimizin kurucusu Mustafa Kemal Atatürk'ün nüfusa kayıtlı olduğu il hangisidir?";
        siklarA[3] = "A) Gaziantep"; siklarB[3] = "B) Selanik"; dogruCevaplar[3] = "A";

        sorular[4] = "Soru 4: Yüzölçümü bakımından dünyanın en büyük ülkesi hangisidir?";
        siklarA[4] = "A) Rusya"; siklarB[4] = "B) Kanada"; dogruCevaplar[4] = "A";

        sorular[5] = "Soru 5: İstiklal Marşı'mızın şairi Mehmet Akif Ersoy, şiiri hangi ordumuza ithaf etmiştir?";
        siklarA[5] = "A) Türk Ordusuna"; siklarB[5] = "B) Türk Milletine"; dogruCevaplar[5] = "A";

        sorular[6] = "Soru 6: Türkiye'nin coğrafi olarak en yüksek dağı hangisidir?";
        siklarA[6] = "A) Erciyes Dağı"; siklarB[6] = "B) Ağrı Dağı"; dogruCevaplar[6] = "B";

        sorular[7] = "Soru 7: Tarihte bilinen ilk yazılı antlaşma olan 'Kadeş Antlaşması' hangi iki devlet arasında imzalanmıştır?";
        siklarA[7] = "A) Mısır - Hitit"; siklarB[7] = "B) Sümer - Akad"; dogruCevaplar[7] = "A";

        sorular[8] = "Soru 8: Üç tarafı denizlerle çevrili olan ülkemizde, tamamen iç denizimiz olan deniz hangisidir?";
        siklarA[8] = "A) Marmara Denizi"; siklarB[8] = "B) Karadeniz"; dogruCevaplar[8] = "A";

        sorular[9] = "Soru 9: Pusulada 'Güney' yönünü gösteren harf hangisidir?";
        siklarA[9] = "A) N (North)"; siklarB[9] = "B) S (South)"; dogruCevaplar[9] = "B";

        sorular[10] = "Soru 10: 'Nutuk' adlı tarihi eserin telif gelirlerini Atatürk hangi kuruma bağışlamıştır?";
        siklarA[10] = "A) Türk Hava Kurumu"; siklarB[10] = "B) Türk Tarih Kurumu"; dogruCevaplar[10] = "A";

        // ==================== 2. ODA SORULARI (11 - 20) ====================
        sorular[11] = "Soru 11: Eyfel Kulesi hangi ülkenin başkentinde yer alan dünyaca ünlü bir yapıdır?";
        siklarA[11] = "A) İtalya"; siklarB[11] = "B) Fransa"; dogruCevaplar[11] = "B";

        sorular[12] = "Soru 12: Coğrafi olarak 'Yükselen Güneşin Ülkesi' olarak bilinen Asya ülkesi hangisidir?";
        siklarA[12] = "A) Japonya"; siklarB[12] = "B) Güney Kore"; dogruCevaplar[12] = "A";

        sorular[13] = "Soru 13: Tarihte inşa edilmiş en uzun savunma duvarı olan 'Çin Seddi' hangi ülkededir?";
        siklarA[13] = "A) Çin"; siklarB[13] = "B) Moğolistan"; dogruCevaplar[13] = "A";

        sorular[14] = "Soru 14: Güney Amerika kıtasında bulunan ve dünyanın en büyük yağmur ormanlarına ev sahipliği yapan orman hangisidir?";
        siklarA[14] = "A) Amazon Ormanları"; siklarB[14] = "B) Kongo Ormanları"; dogruCevaplar[14] = "A";

        sorular[15] = "Soru 15: Piramitleri ve Nil Nehri ile ünlü, Afrika'nın kuzeydoğusunda yer alan tarihi ülke hangisidir?";
        siklarA[15] = "A) Fas"; siklarB[15] = "B) Mısır"; dogruCevaplar[15] = "B";

        sorular[16] = "Soru 16: Dünyanın en geniş yüzölçümüne sahip ve hem Asya hem Avrupa kıtalarında toprağı bulunan ülke hangisidir?";
        siklarA[16] = "A) Rusya"; siklarB[16] = "B) Çin"; dogruCevaplar[16] = "A";

        sorular[17] = "Soru 17: İtalya'nın eğik durmasıyla ünlenmiş olan tarihi kulesinin adı nedir?";
        siklarA[17] = "A) Pisa Kulesi"; siklarB[17] = "B) Eyfel Kulesi"; dogruCevaplar[17] = "A";

        sorular[18] = "Soru 18: Dünyanın en büyük adası olma özelliğine sahip, üzeri buzullarla kaplı bölge hangisidir?";
        siklarA[18] = "A) İzlanda"; siklarB[18] = "B) Grönland"; dogruCevaplar[18] = "B";

        sorular[19] = "Soru 19: Avustralya kıtasının en bilinen ve simgesi haline gelmiş olan keseli hayvan hangisidir?";
        siklarA[19] = "A) Koala"; siklarB[19] = "B) Kanguru"; dogruCevaplar[19] = "B";

        sorular[20] = "Soru 20: Kristof Kolomb'un 1492 yılında keşfettiği, 'Yeni Dünya' olarak da adlandırılan kıta hangisidir?";
        siklarA[20] = "A) Amerika"; siklarB[20] = "B) Avustralya"; dogruCevaplar[20] = "A";

        // ==================== 3. ODA SORULARI (21 - 30) ====================
        sorular[21] = "Soru 21: Dünyanın en büyük okyanusu hangisidir?";
        siklarA[21] = "A) Büyük Okyanus (Pasifik)"; siklarB[21] = "B) Atlas Okyanusu"; dogruCevaplar[21] = "A";

        sorular[22] = "Soru 22: Telefonun mucidi olarak kabul edilen bilim insanı kimdir?";
        siklarA[22] = "A) Nikola Tesla"; siklarB[22] = "B) Alexander Graham Bell"; dogruCevaplar[22] = "B";

        sorular[23] = "Soru 23: Nobel ödülünü kazanan ilk Türk bilim insanı kimdir?";
        siklarA[23] = "A) Aziz Sancar"; siklarB[23] = "B) Cahit Arf"; dogruCevaplar[23] = "A";

        sorular[24] = "Soru 24: Ünlü 'Mona Lisa' tablosu hangi ressama aittir?";
        siklarA[24] = "A) Leonardo da Vinci"; siklarB[24] = "B) Pablo Picasso"; dogruCevaplar[24] = "A";

        sorular[25] = "Soru 25: Güneş sistemindeki en büyük gezegen hangisidir?";
        siklarA[25] = "A) Satürn"; siklarB[25] = "B) Jüpiter"; dogruCevaplar[25] = "B";

        sorular[26] = "Soru 26: İlk modern Olimpiyat Oyunları hangi şehirde düzenlenmiştir?";
        siklarA[26] = "A) Atina"; siklarB[26] = "B) Roma"; dogruCevaplar[26] = "A";

        sorular[27] = "Soru 27: Yerçekimi kanununu keşfeden bilim insanı kimdir?";
        siklarA[27] = "A) Isaac Newton"; siklarB[27] = "B) Albert Einstein"; dogruCevaplar[27] = "A";

        sorular[28] = "Soru 28: İnce belli bardağı ile ünlü, dünyada en çok çay tüketen ülke hangisidir?";
        siklarA[28] = "A) İngiltere"; siklarB[28] = "B) Türkiye"; dogruCevaplar[28] = "B";

        sorular[29] = "Soru 29: Kanarya Adaları hangi ülkeye bağlı bir bölgedir?";
        siklarA[29] = "A) İspanya"; siklarB[29] = "B) Portekiz"; dogruCevaplar[29] = "A";

        sorular[30] = "Soru 30: 'Kızıl Gezegen' olarak bilinen gezegen hangisidir?";
        siklarA[30] = "A) Venüs"; siklarB[30] = "B) Mars"; dogruCevaplar[30] = "B";
    }

    public void SoruTetikle(int soruID)
    {
        gecerliSoruID = soruID;
        soruMetniYazisi.text = sorular[soruID];
        butonA.GetComponentInChildren<TextMeshProUGUI>().text = siklarA[soruID];
        butonB.GetComponentInChildren<TextMeshProUGUI>().text = siklarB[soruID];
        butonA.gameObject.SetActive(true);
        butonB.gameObject.SetActive(true);
        soruPaneli.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    void CevapKontrol(string secilenSik)
    {
        cevaplananSoruSayisi++;
        if (secilenSik == dogruCevaplar[gecerliSoruID]) { dogruCevapSayisi++; sistemVirusOrani -= 10; }
        ArayuzGuncelle();
    }

    void ArayuzGuncelle()
    {
        skorYazisi.text = "Cevaplanan: " + cevaplananSoruSayisi + "/" + toplamSoruSayisi;
        virusYazisi.text = "Sistem Kilidi: %" + sistemVirusOrani;

        if (cevaplananSoruSayisi >= toplamSoruSayisi)
        {
            if (sistemVirusOrani <= 50)
            {
                if (sonOdaMi) // 3. ODADAYSAK VE BAŞARILIYSAK
                {
                    soruMetniYazisi.text = "TEBRİKLER KAZANDINIZ!\nTüm sistemleri başarıyla temizlediniz!";
                    butonA.GetComponentInChildren<TextMeshProUGUI>().text = "Oyundan Çık";
                    butonA.onClick.RemoveAllListeners();
                    butonA.onClick.AddListener(OyunuKapat);
                }
                else // 1. VEYA 2. ODADAYSAK VE BAŞARILIYSAK
                {
                    soruMetniYazisi.text = "TEBRİKLER!\nSonraki odaya geçmeye hazırsınız!";
                    butonA.GetComponentInChildren<TextMeshProUGUI>().text = "Sonraki Bölüm";
                    butonA.onClick.RemoveAllListeners();
                    butonA.onClick.AddListener(YeniSahneyeGec);
                }
                butonA.gameObject.SetActive(true);
                butonB.gameObject.SetActive(false);
            }
            else // BAŞARISIZLIK DURUMU
            {
                soruMetniYazisi.text = "BAŞARISIZ!\nSistem yeterince temizlenemedi.\n\nSoruları tekrar denemek için aşağıdaki butona basın!";
                butonA.GetComponentInChildren<TextMeshProUGUI>().text = "Yeniden Dene";
                butonA.onClick.RemoveAllListeners();
                butonA.onClick.AddListener(OdayiSifirla);
                butonB.gameObject.SetActive(false);
            }
        }
        else { PanelKapat(); }
    }

    void YeniSahneyeGec() { Time.timeScale = 1f; SceneManager.LoadScene(yuklenecekSahneAdi); }

   void OyunuKapat()
     {
    Time.timeScale = 1f; // Zamanı normale döndür
    SceneManager.LoadScene("GirisEkrani"); // Oyundan çıkınca Giriş Ekranına geri dön!
     }

    void OdayiSifirla() {
        cevaplananSoruSayisi = 0; dogruCevapSayisi = 0; sistemVirusOrani = 100;
        
        SiberButonKodu[] tumTabelalar = FindObjectsByType<SiberButonKodu>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (SiberButonKodu tabela in tumTabelalar)
        {
            tabela.gameObject.SetActive(true);
        }

        if (butonA != null)
        {
            butonA.onClick.RemoveAllListeners();
            butonA.onClick.AddListener(() => CevapKontrol("A"));
        }
        if (butonB != null) butonB.gameObject.SetActive(true);

        ArayuzGuncelle();
        soruPaneli.SetActive(false); Time.timeScale = 1f; Cursor.lockState = CursorLockMode.Locked;
    }

    void PanelKapat() { soruPaneli.SetActive(false); Time.timeScale = 1f; Cursor.lockState = CursorLockMode.Locked; }
}