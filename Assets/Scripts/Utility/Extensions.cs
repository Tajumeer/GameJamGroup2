using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{

    public static class Extensions
    {
        public static T Random<T>(this List<T> _list)
        {
            return _list[UnityEngine.Random.Range(0, _list.Count)];
        }
    }
}
