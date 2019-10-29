package com.vstrizhakov.recyclerview_;

import android.graphics.Color;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	private RecyclerView _recyclerView;
	private RecyclerView.Adapter _adapter;
	private RecyclerView.LayoutManager _layoutManager;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		Toolbar toolbar = findViewById(R.id.toolbar);
		setSupportActionBar(toolbar);
		toolbar.setTitle(R.string.app_name);
		toolbar.setSubtitle("Recycler View");
		toolbar.setTitleTextColor(Color.WHITE);
		toolbar.setSubtitleTextColor(Color.WHITE);
		
		CollapsingToolbarLayout collapsingToolbarLayout =
				findViewById(R.id.collapsingToolbar);
		collapsingToolbarLayout.setExpandedTitleColor(Color.rgb(0x00, 0x33, 0x66));
		collapsingToolbarLayout.setCollapsedTitleTextColor((Color.WHITE));
		
		_recyclerView = findViewById(R.id.rvPersons);
		_recyclerView.setHasFixedSize(true);
		_layoutManager = new LinearLayoutManager(this);
		_recyclerView.setLayoutManager(_layoutManager);
		
		ArrayList<Person> persons = new ArrayList<Person>();
		persons.add(new Person("William Blake", "Android Programmer", 15, true));
		persons.add(new Person("Mark Crosberg", "PHP Programmer", 25, false));
		persons.add(new Person("Bill Gates", "Product Manager", 42, false));
		persons.add(new Person("Steve Brown", "Sales Manager", 31, true));
		
		_adapter = new MyRecycleAdapter(this, persons);
		_recyclerView.setAdapter(_adapter);
	}
}
