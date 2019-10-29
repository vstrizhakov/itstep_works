package com.example.android_18_1_sqlite;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

public class MainActivity extends AppCompatActivity
{

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        MySQLiteOpenHelper dbHelper = new MySQLiteOpenHelper(this);
        SQLiteDatabase db = dbHelper.getWritableDatabase();

        //-----Заполняем БД
//        for (int i=0;i<50;i++)
//        {
//            ContentValues row = new ContentValues();
//            row.put("name", "Snickers "+(i+1));
//            row.put("price", 12.50+i%10);
//            row.put("weight", 45+i%10);
//
//            long rowID = db.insert("Products", null, row);
//            Log.d("===", "Добавление, строка = "+rowID);
//        }
        //------Чтение с БД
        Cursor cursor = db.query("Products", null,null, null, null, null, "weight");
        if(cursor.moveToFirst())
        {
            //---Получение индексов столбцов
            int indexID = cursor.getColumnIndex("id");
            int indexName = cursor.getColumnIndex("name");
            int indexPrice = cursor.getColumnIndex("price");
            int indexWeight = cursor.getColumnIndex("weight");
            //-----Извлечение данных каждой строки результирующей таблицы
            do
            {
                Log.d("====", "id = "+cursor.getInt(indexID)+" name = "+cursor.getString(indexName)+" price = "+cursor.getDouble(indexPrice)+" weight = "+cursor.getInt(indexWeight));
            }
            while (cursor.moveToNext());
            cursor.close();
        }
    }
}
