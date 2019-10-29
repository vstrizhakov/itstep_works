package com.vstrizhakov.buttonlisteners;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private final String TAG = "====";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void btnClick(View view)
    {
        int id = view.getId();
        TextView tv1 = findViewById(R.id.tv1);
        String text = "";
        switch (id)
        {
            case R.id.btn1:
                text = "Первая кнопка";
                break;
            case R.id.btn2:
                text = "Вторая кнопка";
                break;
        }
        Log.d(TAG, text);
        tv1.setText(text);
        Toast.makeText(this, text, Toast.LENGTH_SHORT).show();

    }
}
