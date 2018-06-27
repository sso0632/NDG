using System.Collections;
using System.Collections.Generic;

namespace Sang
{
    public enum CharacterAttackType {SHORT, ARROW, FIREBULL,MANABALL, BOLT, SKULL, SLIMEBALL}
    public enum HomeActNum {RightWalk,LeftWalk, Idle}
    public enum DeadorLive { LIVE, DEAD }
    public enum PartyPos { LEFT_UP, RIGHT_UP, LEFT_DOWN, RIGHT_DOWN}
    public enum SceneNum {Home, War};


    public delegate void voiddelgate();
    public delegate void tdelgate<T>(T value);
    public delegate void SkillDelgate<T>(Skill self, T value);
}


