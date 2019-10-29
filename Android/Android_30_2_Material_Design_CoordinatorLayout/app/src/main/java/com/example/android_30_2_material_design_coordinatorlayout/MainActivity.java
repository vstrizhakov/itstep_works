package com.example.android_30_2_material_design_coordinatorlayout;

import android.graphics.Color;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;


public class MainActivity extends AppCompatActivity
{
    private LinearLayout llMain;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        this.llMain = this.findViewById(R.id.llList);

        Toolbar toolbar = this.findViewById(R.id.toolbar);
        toolbar.setTitleTextColor(Color.WHITE);
        toolbar.setSubtitleTextColor(Color.WHITE);
        this.setSupportActionBar(toolbar);

        ArrayList<String> arr = new ArrayList<>();
        for(int i=0; i<150; i++)
            arr.add("Hello "+i);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, arr);
        ListView lvList = (ListView)this.findViewById(R.id.lvList);
        lvList.setAdapter(adapter);

        /**
         * Обработка событий нажатий на плавающую кнопку
         */
        findViewById(R.id.fab).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                /**
                 * Без обратной связи
                 */
                // Snackbar.make(MainActivity.this.llMain, "Hello!!!", Snackbar.LENGTH_LONG).show();
                /**
                 * С обрантой связью
                 */
                Snackbar.make(MainActivity.this.llMain, "Android Forever!!!", Snackbar.LENGTH_INDEFINITE).setAction("OK", new View.OnClickListener()
                {
                    @Override
                    public void onClick(View view)
                    {
                        Toast.makeText(MainActivity.this, "OK pressed", Toast.LENGTH_SHORT).show();
                    }
                }).show();

            }
        });
    }
}
