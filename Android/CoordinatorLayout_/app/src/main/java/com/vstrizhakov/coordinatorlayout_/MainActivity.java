package com.vstrizhakov.coordinatorlayout_;

import android.support.design.widget.CoordinatorLayout;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AbsListView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
//		findViewById(R.id.fab).setOnClickListener(new View.OnClickListener()
//		{
//			@Override
//			public void onClick(View v)
//			{
//				Snackbar.make(findViewById(R.id.clMain), "Android Forever!", Snackbar.LENGTH_INDEFINITE)
//						.setAction("OK", new View.OnClickListener()
//						{
//							@Override
//							public void onClick(View v)
//							{
//								Toast.makeText(MainActivity.this, "OK Button Pressed", Toast.LENGTH_LONG).show();
//							}
//						}).show();
//			}
//		});
	
		final ListView listView = findViewById(R.id.tvListTwo);
		ArrayList<String> arr = new ArrayList<>();
		for (int i = 0; i < 150; i++)
		{
			arr.add("Hello, Man#" + (i + 1));
		}
		ArrayAdapter<String> adapter = new ArrayAdapter<>(
				this,
				android.R.layout.simple_list_item_1,
				arr);
		listView.setAdapter(adapter);
		
		if (listView.getParent() instanceof CoordinatorLayout)
		{
			final CoordinatorLayout coordinatorLayout = (CoordinatorLayout) listView.getParent();
			listView.setOnScrollListener(new AbsListView.OnScrollListener()
			{
				private int prevFirstVisible = 0;
				@Override
				public void onScrollStateChanged(AbsListView view, int scrollState)
				{
					switch (scrollState)
					{
						case 1:
							coordinatorLayout.onStartNestedScroll(listView, coordinatorLayout, 0);
							break;
						case 0:
							coordinatorLayout.onStopNestedScroll(coordinatorLayout);
							break;
					}
				}
				
				@Override
				public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
				{
					
					coordinatorLayout.onNestedScroll(listView, 0, (firstVisibleItem - prevFirstVisible), 0, 0);
					prevFirstVisible = firstVisibleItem;
				}
			});
		}
	}
}
