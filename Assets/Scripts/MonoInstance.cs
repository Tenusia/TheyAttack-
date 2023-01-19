using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoInstance : MonoBehaviour
{
    public static MonoInstance instance;

    private void Awake()
    {
        MonoInstance.instance = this;
    }
}
