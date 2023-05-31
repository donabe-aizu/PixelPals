using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace System
{
    public class DestroyObject : MonoBehaviour
    {
        public void DestroyObjectByTime(float time)
        {
            StartCoroutine(Life(time));
        }
        
        private IEnumerator Life(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(this.gameObject);
        }
    }
}