using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    bool isCollectable { get; set; }

    void ICollectable_Subscripe();
    void ICollectable_UnSubscripe();
    void Collected(int pIndex);
}
