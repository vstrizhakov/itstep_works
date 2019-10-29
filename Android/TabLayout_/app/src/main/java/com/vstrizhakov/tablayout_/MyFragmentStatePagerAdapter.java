package com.vstrizhakov.tablayout_;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

public class MyFragmentStatePagerAdapter extends FragmentStatePagerAdapter
{
    private Fragment[] pages = {new FragmentPageOne(), new FragmentPageTwo(), new FragmentPageThree()};

    public MyFragmentStatePagerAdapter(FragmentManager fm)
    {
        super(fm);
    }

    @Override
    public Fragment getItem(int i)
    {
        return this.pages[i];
    }

    @Override
    public int getCount()
    {
        return this.pages.length;
    }

    @Override
    public CharSequence getPageTitle(int position)
    {
        switch (position)
        {
            case 0:
                return "First";
            case 1:
                return "Second";
            case 2:
                return "Third";
            default:
                return "Unknown";
        }
    }
}
