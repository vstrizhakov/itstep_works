package com.example.android_31_2_appbarlayout;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toolbar;

public class MainActivity extends AppCompatActivity
{

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Toolbar toolbar = this.findViewById(R.id.toolbar);


        TextView tvOne =(TextView)this.findViewById(R.id.tvOne);
        String[] arr = {"Lemon", "Orenge", "Peach", "Banana", "Winter", "Summer", "Spring", "Autum",
                "Mondey", "Tuesday", "Wednesday", "Thursday", "Firday", "Saturday", "Sunday"};

        String content = "";
        for(int i=0; i<1000; i++)
            content += arr[(int)(Math.random()*arr.length)]+(i+1)+" ";
        tvOne.setText(content);
    }
}
