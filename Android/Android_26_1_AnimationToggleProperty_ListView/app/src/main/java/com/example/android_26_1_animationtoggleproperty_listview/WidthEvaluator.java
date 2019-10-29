package com.example.android_26_1_animationtoggleproperty_listview;

import android.view.View;
import android.view.ViewGroup;

/**
 * Вспомогательный класс для "Property Animation" помогающий применить анимацию к свойству width виджетов
 */
public class WidthEvaluator
{
    private View v; //Виджет ширина которого будет изменяться
    public WidthEvaluator(View v)
    {
        this.v = v;
    }
    /**
     * Метод который будет вызываться объектом android.animation.ObjectAnimator для изменения ширины виджета v
     */
    public void setWidth(float w)
    {
        ViewGroup.LayoutParams params = v.getLayoutParams();
        params.width = (int) w;
        v.setLayoutParams(params);
    }

}
