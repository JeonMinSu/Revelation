using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 파티클이 슬로우에 안걸리게 해주는 코드
/// Time.sclae값에 영향을 안받게 해준다.
/// </summary>
public class UnScaleTimeParticle : MonoBehaviour {

    ParticleSystem particle;
    float lastTime;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        lastTime = Time.realtimeSinceStartup;
    }


    // Update is called once per frame
    void Update ()
    {
        float deltaTime = Time.realtimeSinceStartup - lastTime;
        particle.Simulate(deltaTime, true, true);
        lastTime = Time.realtimeSinceStartup;

        //particle.Simulate(Time.unscaledDeltaTime, true);
	}
}
