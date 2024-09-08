﻿using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Infrastructure {
    public interface ICoroutineRunner {
        public Coroutine StartCoroutine(IEnumerator routine);
    }
}