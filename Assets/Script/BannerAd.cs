using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
 
public class BannerAd : MonoBehaviour
{
    public string gameId = "4707053";
    public string placementId = "BannerAd";


    void Start() 
    {
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenInitialized());    
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
}