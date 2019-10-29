package com.example.cwradio;

import android.content.res.Configuration;
import android.media.VolumeShaper;
import android.nfc.Tag;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.CompoundButton;
import android.widget.RadioButton;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private RadioButton rbRed;
    private RadioButton rbGreen;
    private RadioButton rbBlue;
    private final static String TAG = "======";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        this.rbRed = this.findViewById(R.id.rbRed);
        this.rbGreen = this.findViewById(R.id.rbGreen);
        this.rbBlue = this.findViewById(R.id.rbBlue);

        MyCheckedChangeListener myCCl = new MyCheckedChangeListener();

        this.rbRed.setOnCheckedChangeListener(myCCl);
        this.rbGreen.setOnCheckedChangeListener(myCCl);
        this.rbBlue.setOnCheckedChangeListener(myCCl);

        // смена ориентации
        if(getResources().getConfiguration().orientation == Configuration.ORIENTATION_PORTRAIT)
        {
            Log.d(TAG, "Портретная ориентация");
        }
        else if(getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
        {
            Log.d(TAG, "Альбомная ориентация");
        }
    }
    class MyCheckedChangeListener implements CompoundButton.OnCheckedChangeListener
    {
        @Override
       public void onCheckedChanged(CompoundButton buttonView, boolean isChecked)
        {
            if(isChecked)   // интересует только выбор Радиобаттона
            {
                if(buttonView.getId() == MainActivity.this.rbRed.getId())
                {
                    Toast.makeText(MainActivity.this, "Красный", Toast.LENGTH_SHORT).show();
                }
                else  if(buttonView.getId() == MainActivity.this.rbGreen.getId())
                {
                    Toast.makeText(MainActivity.this, "Зеленый", Toast.LENGTH_SHORT).show();
                }
                else  if(buttonView.getId() == MainActivity.this.rbBlue.getId())
                {
                    Toast.makeText(MainActivity.this, "Синий", Toast.LENGTH_SHORT).show();
                }
            }
        }
    }
}
