package com.example.android_34_1_notification;

import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.TaskStackBuilder;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PermissionGroupInfo;
import android.os.Build;
import android.support.v4.app.NotificationCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity
{
    private final static String CHANNEL_ID = "MyNoteId";
    private NotificationManager NM;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        this.NM = (NotificationManager)this.getSystemService(Context.NOTIFICATION_SERVICE);
        if(Build.VERSION.SDK_INT >= 26)
        {
            String name = "MyNotificationChannel";
            String descriotion = "My Channel Description";
            int importance = NotificationManager.IMPORTANCE_DEFAULT;

            NotificationChannel channel = new NotificationChannel(MainActivity.CHANNEL_ID, name, importance);
            channel.setDescription(descriotion);
            this.NM.createNotificationChannel(channel);
        }
    }
    public void btnClickOne(View view)
    {
        /**
         * Создание NotificationAppcompat.Builder
         */
        NotificationCompat.Builder builder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID);
        builder.setSmallIcon(R.drawable.cannabis);
        builder.setContentTitle("My cannabis=)");
        builder.setContentText("Fresh cannabis inexpensive");
        /**
         * Отправка уведомления
         */
        this.NM.notify(123, builder.build());//123 - идентификатор уведомления лучше обновить в классе
    }
    public void btnClickTwo(View view)
    {
        NotificationCompat.Builder builder =
                new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID);
        builder.setSmallIcon(android.R.drawable.ic_notification_overlay)
                .setContentTitle("Notification With Activity")
                .setContentText("Click to launch Activity!");
        builder.setAutoCancel(true);
        
        Intent resultIntent = new Intent(this, SecondActivity.class);
    
        TaskStackBuilder stackBuilder = TaskStackBuilder.create(this);
        stackBuilder.addParentStack(SecondActivity.class);
        stackBuilder.addNextIntent(resultIntent);
    
        PendingIntent resultPI = stackBuilder.getPendingIntent(0, PendingIntent.FLAG_UPDATE_CURRENT);
        builder.setContentIntent(resultPI);
        NM.notify(124, builder.build());
    }
}
