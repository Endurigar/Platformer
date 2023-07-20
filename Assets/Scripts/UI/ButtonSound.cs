using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : Button
{
    protected override void Start()
    {
        base.Start();
        onClick.AddListener((() => ButtonClickHandler.Instance.OnClickHandler()));
    }
}
