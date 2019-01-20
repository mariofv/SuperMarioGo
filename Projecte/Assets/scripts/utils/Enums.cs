using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums  {
    public enum Direction
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        NODE
    }

    public enum Power
    {
        FIRE,
        JUMP,
        ENTER
    }

    public enum CollectibleType
    {
        MUSHROOM,
        YOSHI,
        STAR,
        COIN,
        STARCHIP,
        STARBIT
    };
    public enum MoveType
    {
        X,
        Y,
        Z
    };

}
