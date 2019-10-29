package com.example.android_25_1_animation_listview;

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
