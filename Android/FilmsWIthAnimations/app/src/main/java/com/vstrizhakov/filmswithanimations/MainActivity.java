package com.vstrizhakov.filmswithanimations;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.animation.AnimatorSet;
import android.animation.ValueAnimator;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.animation.AnimationSet;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TableLayout;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	private Toolbar _toolbar;
	private FrameLayout _addPanel;
	private TableLayout _addTable;
	private ListView _filmsListView;
	private boolean _isAddPanelOpened;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		_toolbar = findViewById(R.id.toolbar);
		_toolbar.setTitle(R.string.title);
		_toolbar.setSubtitle(R.string.subtitle);
		_toolbar.setNavigationIcon(R.drawable.plus_outline);
		_toolbar.setNavigationOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				toggleAnimationOfAddPanel();
			}
		});
		
		_addPanel = findViewById(R.id.flAddPanel);
		_addTable = findViewById(R.id.table);
	}
	
	private void toggleAnimationOfAddPanel()
	{
		AnimatorSet set;
		if (!_isAddPanelOpened)
		{
			set = (AnimatorSet)AnimatorInflater.loadAnimator(this, R.animator.fade_in_animation);
		}
		else
		{
			set = (AnimatorSet)AnimatorInflater.loadAnimator(this, R.animator.fade_out_animation);
		}
		_isAddPanelOpened = !_isAddPanelOpened;
		ArrayList<Animator> animators = set.getChildAnimations();
		ValueAnimator heightAnimator = (ValueAnimator)animators.get(0);
		heightAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
		{
			@Override
			public void onAnimationUpdate(ValueAnimator animation)
			{
				int currentHeight = (int)animation.getAnimatedValue();
				Log.d("===", "Current Height: " + currentHeight);
				LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(FrameLayout.LayoutParams.MATCH_PARENT, currentHeight);
				_addPanel.setLayoutParams(layoutParams);
			}
		});
		set.setTarget(_addTable);
		set.start();
	}
}
