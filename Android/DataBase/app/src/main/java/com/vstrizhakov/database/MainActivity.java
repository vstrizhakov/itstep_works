package com.vstrizhakov.database;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.icu.text.UnicodeSetSpanner;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Toast;

import java.io.File;

public class MainActivity extends AppCompatActivity
{
	private MySQLiteOpenHelper _dbHelper;
	private SQLiteDatabase _db;
	private SimpleCursorAdapter _adapter;
	
	private int _normalColor = Color.rgb(0xff, 0xff, 0xff);
	private int _selectColor = Color.rgb(0xb0, 0xff, 0xc0);
	private int _currentItem = -1;
	private View _currentView = null;
	
	private final static String TAG = "===";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		_dbHelper = new MySQLiteOpenHelper(this);
		_db = _dbHelper.getWritableDatabase();
		
//		for (int i = 0; i < 50; i++)
//		{
//			ContentValues row = new ContentValues();
//			row.put("name", "Snickers " + i);
//			row.put("price", 12.5 + i % 10);
//			row.put("weight", 45 + i % 10);
//
//			long rowId = _db.insert("Products", null, row);
//			Log.d("===", "Добавлена строка #" + rowId);
//		}
		
		ListView listView = findViewById(R.id.lvMain);
		
		String strVersion = "Версия Базы Данных: " + MySQLiteOpenHelper.DB_VERSION;
		Log.d(TAG, strVersion);
		Toast.makeText(this, strVersion, Toast.LENGTH_LONG).show();
		
		if (MySQLiteOpenHelper.DB_VERSION == 1)
		{
			Cursor cursor = _db.query(
					MySQLiteOpenHelper.PRODUCTS_TABLE_NAME,
					null, null, null, null, null,
					MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN
			);
			
			_adapter = new SimpleCursorAdapter(
					this,
					R.layout.product_item,
					cursor,
					new String[] {
							MySQLiteOpenHelper.PRODUCT_NAME_COLUMN,
							MySQLiteOpenHelper.PRODUCT_PRICE_COLUMN,
							MySQLiteOpenHelper.PRODUCT_WEIGHT_COLUMN
					},
					new int[] {
							R.id.tvName,
							R.id.tvPrice,
							R.id.tvWeight
					},
					0
			)
			{
				@Override
				public View getView(int position, View convertView, ViewGroup parent)
				{
					View view = super.getView(position, convertView, parent);
					if (position == _currentItem)
					{
						view.setBackgroundColor(_selectColor);
						_currentView = view;
					}
					else
					{
						view.setBackgroundColor(_normalColor);
					}
					return view;
				}
			};
		}
		else if (MySQLiteOpenHelper.DB_VERSION == 2)
		{
			String query = "SELECT Products._id AS _id, Products.name AS pname, " +
							"Products.price AS price, " +
							"Products.weight AS weight, Categories.name AS cname " +
							"FROM Products, Categories " +
							"WHERE Products.id_category = Categories._id " +
							"ORDER BY pname";
			
			Cursor cursor = _db.rawQuery(query, null);
			_adapter = new SimpleCursorAdapter(
					this,
					R.layout.product_item_with_category,
					cursor,
					new String[]
							{
									"pname",
									"cname",
									"price",
									"weight"
							},
					new int[]
							{
									R.id.tvName,
									R.id.tvCategory,
									R.id.tvPrice,
									R.id.tvWeight
							},
					0
			);
		}
		
		listView.setAdapter(_adapter);
		
		listView.setOnItemClickListener(new AdapterView.OnItemClickListener()
		{
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id)
			{
				if (_currentItem != -1)
				{
					_currentView.setBackgroundColor(_normalColor);
				}
				_currentView = view;
				_currentItem = position;
				_currentView.setBackgroundColor(_selectColor);
			}
		});
		
//		File dbFile = new File(_db.getPath());
//		if (Build.VERSION.SDK_INT >= 16)
//		{
//			_db.deleteDatabase(dbFile);
//		}
//		else
//		{
//			dbFile.delete();
//		}
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_main, menu);
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.action_add:
			{
				ContentValues row = new ContentValues();
				row.put(MySQLiteOpenHelper.PRODUCT_NAME_COLUMN, "Twix " + (int) (Math.random() * 1000));
				row.put(MySQLiteOpenHelper.PRODUCT_PRICE_COLUMN, (int) (Math.random() * 1000) / 10f);
				row.put(MySQLiteOpenHelper.PRODUCT_WEIGHT_COLUMN, (int) (Math.random() * 1000));
				long rowId = _db.insert(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, null, row);
				String msg = (rowId != -1) ? "Success" : "Error";
				Toast.makeText(this, msg, Toast.LENGTH_LONG).show();
				
				if (rowId != -1)
				{
					Cursor newCursor = _db.query(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, null, null, null, null, null, MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN);
					Cursor oldCursor = _adapter.swapCursor(newCursor);
					oldCursor.close();
				}
				break;
			}
			case R.id.action_edit:
			{
				if (_currentItem == -1)
				{
					Toast.makeText(this, "Не выбран продукт", Toast.LENGTH_LONG).show();
					break;
				}
				Cursor cursor = _adapter.getCursor();
				cursor.moveToPosition(_currentItem);
				int indexId = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN);
				int indexName = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_NAME_COLUMN);
				int indexPrice = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_PRICE_COLUMN);
				int indexWeight = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_WEIGHT_COLUMN);
				
				String strId = cursor.getString(indexId);
				String strName = cursor.getString(indexName);
				String strPrice  = cursor.getString(indexPrice);
				String strWeight  = cursor.getString(indexWeight);
				
				strName += "UPDATED";
				strPrice += "1";
				strWeight += "2";
				
				ContentValues row = new ContentValues();
				row.put(MySQLiteOpenHelper.PRODUCT_NAME_COLUMN, strName);
				row.put(MySQLiteOpenHelper.PRODUCT_PRICE_COLUMN, strPrice);
				row.put(MySQLiteOpenHelper.PRODUCT_WEIGHT_COLUMN, strWeight);
				
				_db.update(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, row, "_id=?", new String[] { strId });
				
				Cursor newCursor = _db.query(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, null, null, null, null, null, MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN);
				Cursor oldCursor = _adapter.swapCursor(newCursor);
				oldCursor.close();
				break;
			}
			case R.id.action_remove:
			{
				if (_currentItem == -1)
				{
					Toast.makeText(this, "Не выбран продукт", Toast.LENGTH_LONG).show();
					break;
				}
				Cursor cursor = _adapter.getCursor();
				cursor.moveToPosition(_currentItem);
				int indexId = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN);
				int rowAffected = _db.delete(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, "_id=?", new String[]{ String.valueOf(cursor.getInt(indexId)) });
				Toast.makeText(this, "Удалено строк: " + rowAffected, Toast.LENGTH_LONG).show();
				
				_currentItem = -1;
				Cursor newCursor = _db.query(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, null, null, null, null, null, MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN);
				Cursor oldCursor = _adapter.swapCursor(newCursor);
				oldCursor.close();
				break;
			}
		}
		return true;
	}
	
	@Override
	public void onDestroy()
	{
		super.onDestroy();
		_adapter.getCursor().close();
	}
}
