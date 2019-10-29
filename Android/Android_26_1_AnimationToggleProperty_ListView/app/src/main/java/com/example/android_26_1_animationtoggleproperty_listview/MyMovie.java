package com.example.android_26_1_animationtoggleproperty_listview;

import android.text.Editable;

public class MyMovie
{
    public String title;
    public String genre;
    public int year;

    public MyMovie(String title, String genre, int year)
    {
        this.genre = genre;
        this.title = title;
        this.year = year;
    }

    @Override
    public  String toString()
    {
        return "Title: "+this.title+", Genre: "+this.genre+", Year: "+this.year;
    }
}
