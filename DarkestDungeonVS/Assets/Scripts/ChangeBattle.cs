using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChangeBattle : BattleSystem
{
  
    public void ChangeState()
    {
        state = BattleState.ALLY2;
    }
}
