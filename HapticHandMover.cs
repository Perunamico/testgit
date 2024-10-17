using UnityEngine;
using System.Collections;

public class HapticHandMover : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(10f, 10f, 10f);
    public float springStiffness = 0.5f;
    public float maxForce = 1.0f;
    public float moveTime = 5f; // 移動にかかる時間（秒）

    private HapticPlugin[] devices;
    private int[] effectIds;
    private float elapsedTime = 0f;
    private Vector3 startPosition = Vector3.zero;

    void Start()
    {
        // ハプティックデバイスを見つける
        devices = (HapticPlugin[])Object.FindObjectsOfType(typeof(HapticPlugin));
        effectIds = new int[devices.Length];

        // 各デバイスに対してエフェクトを割り当てる
        for (int i = 0; i < devices.Length; i++)
        {
            effectIds[i] = HapticPlugin.effects_assignEffect(devices[i].configName);
        }

        // 開始位置を記録
        if (devices.Length > 0)
        {
            startPosition = devices[0].stylusPositionWorld;
        }

        // 移動を開始
        StartCoroutine(MoveHand());
    }

    IEnumerator MoveHand()
    {
        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveTime);
            Vector3 currentTarget = Vector3.Lerp(startPosition, targetPosition, t);

            for (int i = 0; i < devices.Length; i++)
            {
                HapticPlugin device = devices[i];
                int effectId = effectIds[i];

                if (effectId == -1)
                    continue;

                // デバイスのローカル座標系でのターゲット位置を計算
                Vector3 localTargetPos = device.transform.InverseTransformPoint(currentTarget);

                // エフェクト設定を更新
                double[] pos = { localTargetPos.x, localTargetPos.y, localTargetPos.z };
                double[] dir = { 0, 1, 0 }; // 方向は重要ではないのでデフォルト値を使用

                HapticPlugin.effects_settings(
                    device.configName,
                    effectId,
                    springStiffness,
                    maxForce,
                    0, // 周波数は使用しない
                    pos,
                    dir
                );

                HapticPlugin.effects_type(
                    device.configName,
                    effectId,
                    (int)HapticEffect.EFFECT_TYPE.SPRING
                );

                // エフェクトを開始
                HapticPlugin.effects_startEffect(device.configName, effectId);
            }

            yield return null;
        }

        // 移動完了後、エフェクトを停止
        StopHapticEffect();
    }

    void StopHapticEffect()
    {
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i] != null && effectIds[i] != -1)
            {
                HapticPlugin.effects_stopEffect(devices[i].configName, effectIds[i]);
            }
        }
    }

    void OnDisable()
    {
        StopHapticEffect();
    }

    void OnDrawGizmos()
    {
        // 目標位置を視覚化
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.1f);

        // 現在の手の位置を視覚化（デバイスが存在する場合）
        if (devices != null && devices.Length > 0 && devices[0] != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(devices[0].stylusPositionWorld, 0.05f);
        }
    }
}