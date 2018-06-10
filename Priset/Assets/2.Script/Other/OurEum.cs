using System.Collections;
using System.Collections.Generic;

namespace Sang
{
    public enum CharacterAttackType {SHORT, LONG}
    public enum HomeActNum {RightWalk,LeftWalk, Idle}
    public enum DeadorLive { LIVE, DEAD }
    public delegate void voiddelgate();
    
    public delegate void tdelgate<T>(T value);
    
}


