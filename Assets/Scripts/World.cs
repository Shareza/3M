using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public void Freeze()
    {
        Time.timeScale = 0;
    }

}
