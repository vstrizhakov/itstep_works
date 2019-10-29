package com.vstrizhakov.coordinatorlayout_;

import android.content.Context;
import android.support.design.widget.CoordinatorLayout;
import android.util.AttributeSet;
import android.util.Log;
import android.view.View;
import android.widget.ListView;

import java.util.List;

public class ProgressBehaviour<V extends View> extends CoordinatorLayout.Behavior<V>
{
	private final static String TAG = "===";
	
	private int _firstVisibleItem;
	private int _totalItems;
	
	public ProgressBehaviour()
	{
	
	}
	
	public ProgressBehaviour(Context context, AttributeSet attrs)
	{
		super(context, attrs);
	}
	
	@Override
	public boolean layoutDependsOn(CoordinatorLayout parent, V child, View dependency)
	{
		Log.d(TAG, "layoutDependsOn: ");
		
		return dependency instanceof ListView;
	}
	
	@Override
	public boolean onDependentViewChanged(CoordinatorLayout parent, V child, View dependency)
	{
		Log.d(TAG, "onDependentViewChanged: ");
		
		ListView listView = (ListView) dependency;
		_totalItems = listView.getAdapter().getCount();
		_firstVisibleItem = listView.getFirstVisiblePosition();
		
		CoordinatorLayout.LayoutParams layoutParams = (CoordinatorLayout.LayoutParams) child.getLayoutParams();
		layoutParams.width = calculateWidth(_firstVisibleItem, _totalItems, parent.getWidth());
		child.setLayoutParams(layoutParams);
		
		return true;
	}
	
	/**
	 * @param firstVisibleItem - текущее количество прокрученных элементов в списке ListView
	 * @param count            - общее количество элементов в списке ListView
	 * @param widgetWidth      - ширан родительского контейнера
	 * @return - ширина прогресс бара относительно ширины родительского контейнера
	 */
	private int calculateWidth(int firstVisibleItem, int count, int widgetWidth)
	{
		int width = (_firstVisibleItem * widgetWidth) / count;
		if (width < 4)
		{
			width = 4;
		}
		return width;
	}
	
	@Override
	public boolean onStartNestedScroll(CoordinatorLayout parent, V child, View directTargetChild, View target, int axes, int type)
	{
		Log.d(TAG, "onStartNestedScroll: ");
		
		return directTargetChild instanceof ListView;
	}
	
	@Override
	public void onNestedScroll(CoordinatorLayout coordinatorLayout, V child, View target, int dvConsumed, int dyConsumed,
							   int dxUnconsumed, int dyUnconsumed, int type)
	{
		Log.d(TAG, "onNestedScroll: ");
		
		CoordinatorLayout.LayoutParams layoutParams = (CoordinatorLayout.LayoutParams) child.getLayoutParams();
		
		_firstVisibleItem += dyConsumed;
		layoutParams.width = calculateWidth(_firstVisibleItem, _totalItems, coordinatorLayout.getWidth());
		child.setLayoutParams(layoutParams);
	}
}
