package com.vstrizhakov.tablayout_;

import android.graphics.Color;
import android.support.design.widget.TabLayout;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;

public class MainActivity extends AppCompatActivity
{
	private ViewPager _viewPager;
	private PagerAdapter _adapter;
	
	static private final String TAG = "===";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		Toolbar toolbar = findViewById(R.id.toolbar);
		setSupportActionBar(toolbar);
		toolbar.setTitle(R.string.app_name);
		toolbar.setSubtitle("TabLayout");
		toolbar.setTitleTextColor(Color.WHITE);
		toolbar.setSubtitleTextColor(Color.WHITE);
	
		_viewPager = findViewById(R.id.vpContent);
		_adapter = new MyFragmentStatePagerAdapter(getSupportFragmentManager());
		_viewPager.setAdapter(_adapter);
		
		final TabLayout tabLayout = findViewById(R.id.tabLayout);
		tabLayout.addTab(tabLayout.newTab().setText("First page"));
		tabLayout.addTab(tabLayout.newTab().setText("Second page"));
		tabLayout.addTab(tabLayout.newTab().setText("Third page"));
		tabLayout.addOnTabSelectedListener(new TabLayout.OnTabSelectedListener()
		{
			@Override
			public void onTabSelected(TabLayout.Tab tab)
			{
				Log.d(TAG, "onTabSelected: ");
				_viewPager.setCurrentItem(tab.getPosition(), true);
			}
			
			@Override
			public void onTabUnselected(TabLayout.Tab tab)
			{
				Log.d(TAG, "onTabUnselected: ");
			}
			
			@Override
			public void onTabReselected(TabLayout.Tab tab)
			{
				Log.d(TAG, "onTabReselected: ");
			}
		});
		
		_viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener()
		{
			@Override
			public void onPageScrolled(int i, float v, int i1)
			{
			
			}
			
			@Override
			public void onPageSelected(int i)
			{
				tabLayout.getTabAt(i).select();
			}
			
			@Override
			public void onPageScrollStateChanged(int i)
			{
			
			}
		});
	}
}
