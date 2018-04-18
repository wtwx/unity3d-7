using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PARTICLETYPE
{
    NULL,
    CONCRETE,
    WOOD,
    DIRT,
    METAL,
    BLOOD
}

public class ParticalType : MonoBehaviour {

    public PARTICLETYPE pt = PARTICLETYPE.NULL;
}
