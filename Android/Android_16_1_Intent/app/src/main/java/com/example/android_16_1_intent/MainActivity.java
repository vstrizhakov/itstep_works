package com.example.android_16_1_intent;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity
{
    private final static  int REQUEST_CAMERA = 987; //значение может быти любым
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
    public void btnActionDial(View v)
    {
        Intent oneIntent = new Intent();
        oneIntent.setAction(Intent.ACTION_DIAL);
        oneIntent.setData(Uri.parse("tel:+38 066 987-65-43"));
        this.startActivity(oneIntent);
    }
    public void btnActionContacts(View v)
    {
        Intent oneIntent = new Intent();
        oneIntent.setAction(Intent.ACTION_VIEW);
        oneIntent.setData(Uri.parse("content://contacts/people"));
        this.startActivity(oneIntent);
    }
    public void btnActionContact(View v)
    {
        Intent oneIntent = new Intent(Intent.ACTION_VIEW);
        oneIntent.setData(Uri.parse("content://contacts/people/2"));//1-номер контакта
        this.startActivity(oneIntent);
    }
    public void btnActionBrowser(View e)
    {
        Intent intent = new Intent(Intent.ACTION_VIEW);
        intent.setData(Uri.parse("http://facebook.com"));
        this.startActivity(intent);
    }
    public void btnActionSendSMS(View e)
    {
        Intent intent = new Intent(Intent.ACTION_SEND);
        intent.setType("text/plain");
        intent.putExtra(Intent.EXTRA_TEXT, "Hello Forever");
        this.startActivity(intent);
    }
    public void btnActionCamera(View e)
    {
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        this.startActivityForResult(intent, MainActivity.REQUEST_CAMERA);
    }
    @Override
    protected void  onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if(requestCode == MainActivity.REQUEST_CAMERA)
        {
            //----Результат камеры
            if(resultCode == Activity.RESULT_OK)
            {
                //---Пользователь успешно завершил активность
                Bitmap img = (Bitmap)data.getExtras().get("data");
                ImageView imageView = findViewById(R.id.ivImage);
                imageView.setImageBitmap(img);
            }
        }
    }
}
