using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioTag
{
    ZA_WORLD,
    DA_WEI, 
    SUS
}

public class SoundManager : MonoBehaviour
{
    public static AudioClip ZA_WORLD, DA_WEI, SUS;

    static AudioSource audioSource;

    void Start()
    {
        ZA_WORLD = Resources.Load<AudioClip>("Audio/ZaWorld");
        DA_WEI = Resources.Load<AudioClip>("Audio/DaWei");
        SUS = Resources.Load<AudioClip>("Audio/Amongus");

        audioSource = GetComponent<AudioSource>();
    }

    public static void playSound(AudioTag tag)
    {
        switch (tag)
        {
            case AudioTag.ZA_WORLD:
                audioSource.PlayOneShot(ZA_WORLD);
                break;
            case AudioTag.DA_WEI:
                Debug.Log("ZA WORLD");
                audioSource.PlayOneShot(DA_WEI);
                break;
            case AudioTag.SUS:
                audioSource.PlayOneShot(SUS);
                break;
            default:
                break;
        }
    }
}
