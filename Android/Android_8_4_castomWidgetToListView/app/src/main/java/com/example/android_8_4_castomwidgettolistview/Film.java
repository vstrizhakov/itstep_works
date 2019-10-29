package com.example.android_8_4_castomwidgettolistview;

public class Film
{
    public  String title;
    public  String genre;
    public  int year;
    public  Film(String title, String genre, int year)
    {
        this.title = title;
        this.genre = genre;
        this.year = year;
    }
    @Override
    public String toString()
    {
        return  "Title: "+this.title+", Genre: "+this.genre+", Year: "+this.year;
    }

}
