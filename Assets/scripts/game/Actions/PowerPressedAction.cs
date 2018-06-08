using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPressedAction : Action {

    private Enums.Power power;

    public PowerPressedAction(Enums.Power power)
    {
        this.power = power;
    }

    public override void execute()
    {
        switch (power)
        {
            case Enums.Power.FIRE:
                CharacterManager.instance.shootFireBall();
                break;
            case Enums.Power.JUMP:
                CharacterManager.instance.jump();
                break;
            case Enums.Power.ENTER:
                GameManager.instance.enterPipe();
                break;
            default:
                throw new System.Exception("This should never happen!");


        }
    }

    public override bool triggersIteration()
    {
        return false;
    }
}
