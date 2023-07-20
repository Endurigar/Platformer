using System;
using UnityEngine;

namespace Containers
{
    [BindClassMarker]
    public class ActionContainer : MonoBehaviour
    {
        public  Action OnLose;
        public  Action OnKey;
        public  Action OnWin;
        public  Action OnButtonClick;
    }   
}
