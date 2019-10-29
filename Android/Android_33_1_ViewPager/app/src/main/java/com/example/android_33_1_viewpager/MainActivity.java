package com.example.android_33_1_viewpager;

import android.graphics.Color;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;


public class MainActivity extends AppCompatActivity
{
    private ViewPager viewPager;
    private PagerAdapter adapter;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Toolbar toolbar = this.findViewById(R.id.toolbar);
        this.setSupportActionBar(toolbar);
        toolbar.setTitleTextColor(Color.WHITE);
        toolbar.setSubtitleTextColor(Color.WHITE);

        /**
         * PagerAdapter
         */
        this.viewPager = this.findViewById(R.id.vpContent);
        this.adapter = new MyFragmentStatePagerAdapter(this.getSupportFragmentManager());
        this.viewPager.setAdapter(this.adapter);
    }
}
