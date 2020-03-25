using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ElementHolder_Joseph
{

    #region Public
    int CurrentValue { get; set; }
    int MaxValue { get; set; }
    int MinValue { get; set; }
    int ElementUsed { get; set; }
    int ValueGiven { get; set; }
    #endregion

    void ElementAbsorbed();
    void ElementGiven();

}
