using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAbility : MonoBehaviour
{
    public GrayOutScript grayOut;
    public BlackPassByScript blackPass;
    public BlueCircleExpand blueOut;

    public void useAbility(BallType ballType)
    {
        switch (ballType)
        {
            case BallType.UKNUCKLE:
                Debug.Log("da wei");
                SoundManager.playSound(AudioTag.DA_WEI);
                SoundManager.playSound(AudioTag.SPIT);
                blueOut.changeAnimationState(BlueExpandAnimState.BLUEOUT);
                break;
            case BallType.DIO:
                SoundManager.playSound(AudioTag.ZA_WORLD);
                grayOut.changeAnimationState(GrayOutAnimState.GRAYOUT);
                break;
            case BallType.SUS:
                SoundManager.playSound(AudioTag.SUS);
                blackPass.changeAnimationState(BlackPassByAnimState.PASSBY);
                break;
            default:
                SoundManager.playSound(AudioTag.DING);
                break;
        }

        grayOut.changeAnimationState(GrayOutAnimState.STANDBY);
        blackPass.changeAnimationState(BlackPassByAnimState.STANDBY);
    }
}
