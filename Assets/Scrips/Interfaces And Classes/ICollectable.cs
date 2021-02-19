using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    bool isCollectable { get; set; }
    int index { get; set; }

    void Subscripe();
    void UnSubscripe();
    void Collected(int pIndex);
}
