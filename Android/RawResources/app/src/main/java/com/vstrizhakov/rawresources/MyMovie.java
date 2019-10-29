package com.vstrizhakov.rawresources;

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
		return "Title: " + title + ", Genre: " + genre + ", Year: " + year;
	}
}
