package com.vstrizhakov.database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabaseLockedException;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class MySQLiteOpenHelper extends SQLiteOpenHelper
{
	private final static String TAG = "===";
	private final static String _dbName = "MyDbOne";
	
	public final static int DB_VERSION = 1;
	public final static String PRODUCTS_TABLE_NAME = "Products";
	public final static String PRODUCT_NAME_COLUMN = "name";
	public final static String PRODUCT_PRICE_COLUMN = "price";
	public final static String PRODUCT_WEIGHT_COLUMN = "weight";
	public final static String PRODUCT_INDEX_COLUMN = "_id";
	
	public MySQLiteOpenHelper(Context context)
	{
		super(context, _dbName, null, DB_VERSION);
	}
	
	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
	{
		Log.d("===", "newVersion = " + newVersion + ", odlVersion = " + oldVersion);
		if (oldVersion == 1 && newVersion == 2)
		{
			String query = "CREATE TABLE Categories " +
							"(" +
							"_id integer NOT NULL PRIMARY KEY AUTOINCREMENT, " +
							"name text" +
							")";
			db.execSQL(query);
			
			ContentValues row = new ContentValues();
			row.put("name", "Кондитерскаие изделия");
			db.insert("Categories", null, row);
			
			row = new ContentValues();
			row.put("name", "Напитки");
			db.insert("Categories", null, row);
			
			row = new ContentValues();
			row.put("name", "Салаты");
			db.insert("Categories", null, row);
			
			db.execSQL("ALTER TABLE Products ADD COLUMN id_category integer");
			
			row = new ContentValues();
			row.put("id_category", 1);
			db.update(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, row, null, null);
		}
	}
	
	@Override
	public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion)
	{
		Log.d("===", "onDowngrade: newVersion = " + newVersion + ", odlVersion = " + oldVersion);
		if (oldVersion == 2 && newVersion == 1)
		{
			String query = "ALTER TABLE Products RENAME TO OldProducts";
			db.execSQL(query);
			
			query = "CREATE TABLE Products(" +
					"_id integer NOT NULL PRIMARY KEY AUTOINCREMENT, " +
					"name text, " +
					"price real, " +
					"weight integer)";
			db.execSQL(query);
			
			Cursor cursor = db.query("OldProducts", null, null, null, null, null, null);
			if (cursor.moveToFirst())
			{
				int indexId = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN);
				int indexName = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_NAME_COLUMN);
				int indexPrice = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_PRICE_COLUMN);
				int indexWeight = cursor.getColumnIndex(MySQLiteOpenHelper.PRODUCT_WEIGHT_COLUMN);
				
				do
				{
					ContentValues row = new ContentValues();
					row.put(MySQLiteOpenHelper.PRODUCT_INDEX_COLUMN, cursor.getInt(indexId));
					row.put(MySQLiteOpenHelper.PRODUCT_NAME_COLUMN, cursor.getString(indexName));
					row.put(MySQLiteOpenHelper.PRODUCT_PRICE_COLUMN, cursor.getDouble(indexPrice));
					row.put(MySQLiteOpenHelper.PRODUCT_WEIGHT_COLUMN, cursor.getInt(indexWeight));
					db.insert(MySQLiteOpenHelper.PRODUCTS_TABLE_NAME, null, row);
				} while (cursor.moveToNext());
			}
			
			query = "DROP TABLE Categories";
			db.execSQL(query);
			query = "DROP TABLE OldProducts";
			db.execSQL(query);
		}
	}
	
	@Override
	public void onCreate(SQLiteDatabase db)
	{
		Log.d(TAG, "onCreate: " + db.getPath());
		String query = "CREATE TABLE Products(" +
				"_id integer not null primary key autoincrement, " +
				"name text, " +
				"price real, " +
				"weight integer)";
		db.execSQL(query);
		
		ContentValues row = new ContentValues();
		row.put("name", "Snickers");
		row.put("price", 12.5);
		row.put("weight", 45);
		db.insert(PRODUCTS_TABLE_NAME, null, row);
		
		row = new ContentValues();
		row.put("name", "Mars");
		row.put("price", 1.5);
		row.put("weight", 45);
		db.insert(PRODUCTS_TABLE_NAME, null, row);
		
		row = new ContentValues();
		row.put("name", "Bounty");
		row.put("price", 42.5);
		row.put("weight", 85);
		db.insert(PRODUCTS_TABLE_NAME, null, row);
	}
	
	@Override
	public void onOpen(SQLiteDatabase db)
	{
		Log.d(TAG, "onUpgrade: " + db.getPath());
	}
}
