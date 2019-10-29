package com.example.android_31_2_appbarlayout;

import android.content.Context;
import android.support.design.widget.CoordinatorLayout;
import android.util.AttributeSet;
import android.view.View;
import android.widget.TextView;

public class InfoBehavior extends CoordinatorLayout.Behavior<TextView>
{
    private int curScrollY = 0;
    public InfoBehavior(){}
    public InfoBehavior(Context context, AttributeSet attrs)
    {
        super(context, attrs);
    }
    @Override
    public boolean layoutDependsOn(CoordinatorLayout parent, TextView child, View dependency)
    {
        return dependency instanceof android.support.v4.widget.NestedScrollView;
    }
    @Override
    public boolean onStartNestedScroll(CoordinatorLayout coordinatorLayout, TextView child,
                                       View directTargetChild, View target, int axes, int type)
    {
        return directTargetChild instanceof android.support.v4.widget.NestedScrollView;
    }
    @Override
    public boolean onDependentViewChanged(CoordinatorLayout parent, TextView child, View dependency)
    {
        String str = "Scrollad: "+this.curScrollY;
        child.setText(str);
        return true;
    }
    @Override
    public void onNestedScroll(CoordinatorLayout coordinatorLayout, TextView child, View target,
                               int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int type)
    {
        this.curScrollY+=dyConsumed;
        String str = "Scrolled: "+this.curScrollY;
        child.setText(str);
    }
}
