package com.example.android_20_1_sqlite_onupgrade;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Toast;

import java.io.File;

public class MainActivity extends AppCompatActivity
{
    private MySQLiteOpenHelper dbHelper;
    private SimpleCursorAdapter adapter;

    private int nrmColor = Color.rgb(0xFF, 0xFF, 0xFF);
    private int slctColor = Color.rgb(0xB0, 0xFF, 0xC0);
    private int curItem = -1;
    private View curView = null;
    SQLiteDatabase db;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);



        this.dbHelper = new MySQLiteOpenHelper(this);
        ListView LV = this.findViewById(R.id.lvMain);
        SQLiteDatabase db = this.dbHelper.getWritableDatabase();
//        File file = new File(db.getPath());
//        file.delete();
        String strVersion = "Версия БД: "+MySQLiteOpenHelper.dbVersion;
        Log.d("===", strVersion);
        Toast.makeText(this, strVersion, Toast.LENGTH_SHORT).show();

        if(MySQLiteOpenHelper.dbVersion == 1)
        {
            Cursor C = db.query(MySQLiteOpenHelper.tdlNameProducts, null,null,null,null,null, MySQLiteOpenHelper.colProductName);
            this.adapter =  new SimpleCursorAdapter(this, R.layout.product_item, C,
                    new String[]{
                            MySQLiteOpenHelper.colProductName,
                            MySQLiteOpenHelper.colProductsPrice,
                            MySQLiteOpenHelper.colProductsWeight},
                    new int[]{
                            R.id.tvName,
                            R.id.tvPrice,
                            R.id.tvWeight },0)
            {
                @Override
                public View getView(int position, View convertView, ViewGroup parent)
                {
                    View view = super.getView(position, convertView, parent);
                    if(position==MainActivity.this.curItem)
                    {
                        view.setBackgroundColor(MainActivity.this.slctColor);
                        MainActivity.this.curView = view;
                    }
                    else
                        view.setBackgroundColor(MainActivity.this.nrmColor);
                    return view;
                }
            };

        }
        else if(MySQLiteOpenHelper.dbVersion == 2)
        {
            Cursor C = db.rawQuery("SELECT Products._id AS _id, Products.name AS pname, " +
                    "Products.price AS price, " +
                    "Products.weight AS weight, Categories.name AS cname " +
                    "FROM Products, Categories " +
                    "WHERE Products.id_category = Categories._id " +
                    "ORDER BY pname", null);

            this.adapter = new SimpleCursorAdapter(this, R.layout.product_item_category, C,
                    new String[]{"pname", "cname", "price", "weight"},
                    new int[]{R.id.tvName, R.id.tvCategory, R.id.tvPrice, R.id.tvWeight}, 0)
            {
                @Override
                public View getView(int position, View convertView, ViewGroup parent)
                {
                    View view = super.getView(position, convertView, parent);
                    if(position==MainActivity.this.curItem)
                    {
                        view.setBackgroundColor(MainActivity.this.slctColor);
                        MainActivity.this.curView = view;
                    }
                    else
                        view.setBackgroundColor(MainActivity.this.nrmColor);
                    return view;
                }
            };


        }


        LV.setAdapter(this.adapter);
        LV.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long id)
            {
                if (MainActivity.this.curItem != -1)
                {
                    MainActivity.this.curView.setBackgroundColor(MainActivity.this.nrmColor);
                }
                MainActivity.this.curView = view;
                MainActivity.this.curItem = position;
                MainActivity.this.curView.setBackgroundColor(MainActivity.this.slctColor);
            }
        });

    }

}
