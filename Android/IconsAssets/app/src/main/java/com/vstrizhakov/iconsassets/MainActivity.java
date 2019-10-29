package com.vstrizhakov.iconsassets;

import android.content.res.AssetManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.InputStream;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		ArrayList<GridViewItem> items = new ArrayList<>();
		GridView gridView = findViewById(R.id.gvOne);
		AssetManager assetManager = getAssets();
		try
		{
			String[] files = assetManager.list("icons");
			for (String file : files)
			{
				Log.d("===File", file);
				try
				{
					InputStream IS = assetManager.open("icons/" + file);
					Bitmap bmp = BitmapFactory.decodeStream(IS);
					IS.close();
					items.add(new GridViewItem(bmp, file));
				}
				catch (Exception ex)
				{
					Log.d("===ISException", ex.getMessage());
				}
			}
		}
		catch (Exception ex)
		{
			Log.d("===Exception", ex.getMessage());
		}
		
		ArrayAdapter<GridViewItem> adapter = new ArrayAdapter<GridViewItem>(this, R.layout.my_gridview_item, R.id.tvTitle, items)
		{
			@Override
			public View getView(int position, View convertView, ViewGroup parent)
			{
				View view = super.getView(position, convertView, parent);
				GridViewItem result = getItem(position);
				ImageView ivImg = view.findViewById(R.id.ivImg);
				ivImg.setImageBitmap(result._bmp);
				TextView title = view.findViewById(R.id.tvTitle);
				title.setText(result._title);
				return view;
			}
		};
		gridView.setAdapter(adapter);
		gridView.setOnItemClickListener(new AdapterView.OnItemClickListener()
		{
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id)
			{
				GridViewItem item = (GridViewItem)parent.getAdapter().getItem(position);
				Toast.makeText(MainActivity.this, "Выбран: " + item._title, Toast.LENGTH_LONG).show();
			}
		});
	}
}
