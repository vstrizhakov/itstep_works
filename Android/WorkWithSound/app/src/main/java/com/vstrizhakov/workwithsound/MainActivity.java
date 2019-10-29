package com.vstrizhakov.workwithsound;

import android.media.AudioAttributes;
import android.media.AudioManager;
import android.media.SoundPool;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity
{
	final static private String TAG = "===";
	final static private int MAX_STREAMS = 5;
	
	private SoundPool _soundPool;
	int _soundIdFromAssets;
	int _soundIdFromRaw;
	
	private int _streamIdAssets;
	private int _streamIdRaw;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		if (Build.VERSION.SDK_INT >= 21)
		{
			SoundPool.Builder builder = new SoundPool.Builder();
			builder.setMaxStreams(MAX_STREAMS);
			builder.setAudioAttributes(new AudioAttributes.Builder()
											.setUsage(AudioAttributes.USAGE_MEDIA)
											.setContentType(AudioAttributes.CONTENT_TYPE_MUSIC).build());
			_soundPool = builder.build();
		}
		else
		{
			_soundPool = new SoundPool(MAX_STREAMS, AudioManager.STREAM_MUSIC, 0);
		}
		
		_soundIdFromRaw = _soundPool.load(this, R.raw.gun, 1);
		
		try
		{
			_soundIdFromAssets = _soundPool.load(getAssets().openFd("music/explode.mp3"), 1);
		}
		catch (Exception ex)
		{
		
		}
	}
	
	public void btnClick(View view)
	{
		switch (view.getId())
		{
			case R.id.btnRaw:
				_streamIdRaw = _soundPool.play(_soundIdFromRaw, 1, 1, 0, 0, 1);
				break;
			case R.id.btnAssets:
				_streamIdAssets = _soundPool.play(_soundIdFromAssets, 1, 1, 0, 0, 1);
				break;
		}
	}
}
