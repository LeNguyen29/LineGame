using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAbility : MonoBehaviour
{
    private BallSpawner spawner;

    public void useAbility(BallType ballType)
    {
        switch (ballType)
        {
            case BallType.UKNUCKLE:
                Debug.Log("da wei");
                SoundManager.playSound(AudioTag.DA_WEI);
                spawner.spawnObjectAtRandom();
                break;
            case BallType.DIO:
                SoundManager.playSound(AudioTag.ZA_WORLD);
                break;
            case BallType.SUS:
                break;
            default:
                break;
        }
    }
}
