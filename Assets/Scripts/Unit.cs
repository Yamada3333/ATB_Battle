using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public bool isMe;
//a
    public ReactiveProperty<float> maxHp;
    public ReactiveProperty<float> currentHp;
    public float attack;
    public float speed;
    public ReactiveProperty<float> maxAtb;
    public ReactiveProperty<float> currentAtb;

    public Unit target;

    public Slider hpSlider;
    public Slider atbSlider;

    private void Start()
    {
        maxHp.Subscribe(_ => SetSlider(hpSlider, maxHp.Value, currentHp.Value));
        currentHp.Subscribe(_ => SetSlider(hpSlider, maxHp.Value, currentHp.Value));
        maxAtb.Subscribe(_ => SetSlider(atbSlider, maxAtb.Value, currentAtb.Value));
        currentAtb.Subscribe(_ => SetSlider(atbSlider, maxAtb.Value, currentAtb.Value));
    }

    public void Action()
    {
        if (currentAtb.Value > maxAtb.Value)
        {
            if (isMe)
            {
                GameManager.instance.GamePose();
            }
            else
            {
                Attack();
            }
        }
        else
        {
            currentAtb.Value += speed;
        }
    }

    public void Attack()
    {
        target.currentHp.Value = Mathf.Clamp(target.currentHp.Value - attack, 0, target.maxHp.Value);
        currentAtb.Value = 0;
    }

    private void SetSlider(Slider slider, float max, float current)
    {
        slider.maxValue = max;
        slider.value = current;
    }
}