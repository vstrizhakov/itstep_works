package com.vstrizhakov.texteditor;

import android.Manifest;
import android.content.Context;
import android.content.DialogInterface;
import android.content.pm.PackageManager;
import android.content.res.AssetManager;
import android.os.Environment;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.InputStream;
import java.io.LineNumberReader;
import java.lang.reflect.Array;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
	private File _currentDirectory;
	private File _currentFile;
	private ListView _filesListView;
	private ArrayAdapter<String> _adapter;
	private AlertDialog _dialog;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		int permission  = ActivityCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE);
		if (permission != PackageManager.PERMISSION_GRANTED)
		{
			ActivityCompat.requestPermissions(
					this,
					new String[] {
							Manifest.permission.READ_EXTERNAL_STORAGE,
							Manifest.permission.WRITE_EXTERNAL_STORAGE
					}, 1);
		}
		_currentDirectory = Environment.getExternalStorageDirectory();
		_dialog = createDialog();
		
		try
		{
			FileOutputStream FOS = openFileOutput("test.txt", Context.MODE_PRIVATE);
			String str = "Hello, world!\nAndroid forever!";
			byte[] bytes = str.getBytes();
			FOS.write(bytes, 0, bytes.length);
			FOS.close();
		}
		catch (Exception ex)
		{
		
		}
		
		try
		{
			FileInputStream FIS = openFileInput("test.txt");
			byte[] bytes = new byte[1024];
			int cnt = FIS.read(bytes, 0, bytes.length);
			FIS.close();
			String str = new String(bytes, 0, cnt, "UTF8");
			Toast.makeText(this, str, Toast.LENGTH_LONG);
			Log.d("====", str);
		}
		catch (Exception ex)
		{
		
		}
		
		AssetManager assetManager = getAssets();
		try
		{
			InputStream IS = assetManager.open("images/exam.txt");
			byte[] b = new byte[1024];
			ByteArrayOutputStream BAOS = new ByteArrayOutputStream();
			do
			{
				int cnt = IS.read(b, 0, b.length);
				if (cnt == -1) break;
				BAOS.write(b, 0, cnt);
			} while (IS.available() > 0);
			byte[] a = BAOS.toByteArray();
			String str = new String(a, 0, a.length, "UTF8");
			BAOS.close();
			Log.d("===", str);
		}
		catch (Exception ex)
		{
			Log.d("===Exception", ex.getMessage());
		}
	}
	
	public void filesListClick(View view)
	{
	
	}
	
	public void openFileClick(View view)
	{
		if (isExternalStorageWritable() && _dialog != null)
		{
			_dialog.show();
		}
	}
	
	public void createFileClick(View view)
	{
		if (_currentDirectory == null) return;
		AlertDialog.Builder builder = new AlertDialog.Builder(this, android.R.style.Theme_Holo_Light_Dialog);
		builder.setTitle("Введите имя файла");
		final EditText editor = new EditText(this);
		builder.setView(editor);
		builder.setNegativeButton("Cancel", null);
		builder.setPositiveButton("Ok",
				new DialogInterface.OnClickListener()
				{
					@Override
					public void onClick(DialogInterface dialog, int which)
					{
						try
						{
							FileOutputStream FOS = new FileOutputStream(new File(_currentDirectory, editor.getText().toString()));
							FOS.close();
						}
						catch (Exception ex)
						{
							Toast.makeText(MainActivity.this, "ОШибка", Toast.LENGTH_LONG).show();;
						}
					}
				});
		builder.create().show();
	}
	
	public void saveFileClick(View view)
	{
		if (_currentFile == null)
		{
			Toast.makeText(this, "Для сохранения необходимо предварительно выбрать и открыть файл", Toast.LENGTH_LONG).show();;
			return;
		}
		if (isExternalStorageWritable())
		{
			EditText editor = findViewById(R.id.editor);
			String content = editor.getText().toString();
			try
			{
				FileWriter writer = new FileWriter(_currentFile);
				writer.write(content + "\r\n");
				writer.close();
				Toast.makeText(this, "Файл успешно сохранен", Toast.LENGTH_LONG).show();;
			}
			catch (Exception ex)
			{
				Toast.makeText(this, "Ошибка записи в файл", Toast.LENGTH_LONG).show();
			}
		}
		else
		{
			Toast.makeText(this, "Внешний нсоитель не готов", Toast.LENGTH_LONG).show();;
		}
	}
	
	private AlertDialog createDialog()
	{
		ArrayList<String> filesList = fillDirectory(_currentDirectory);
		AlertDialog.Builder builder = new AlertDialog.Builder(
				this,
				android.R.style.Theme_Holo_Light_Dialog);
		builder.setTitle(_currentDirectory.getAbsolutePath());
		_filesListView = new ListView(this);
		
		_adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, filesList);
		_filesListView.setAdapter(_adapter);
		
		_filesListView.setOnItemClickListener(new AdapterView.OnItemClickListener()
		{
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id)
			{
				String item = _adapter.getItem(position).replaceAll("[\\[\\]]*", "");
				File file = (item.compareTo("..") == 0)
							 ? _currentDirectory.getParentFile()
							 : new File(_currentDirectory, item);
				if (file.isDirectory())
				{
					_adapter.clear();
					ArrayList<String> filesList = fillDirectory(file);
					if (file.compareTo(Environment.getExternalStorageDirectory()) != 0)
					{
						_adapter.add(("[..]"));
					}
					
					_adapter.addAll(filesList);
					_currentDirectory = file;
					_dialog.setTitle(_currentDirectory.getAbsolutePath());
				}
				else
				{
					try
					{
						LineNumberReader LR = new LineNumberReader(new FileReader(file));
						String s = "";
						while (true)
						{
							String str = LR.readLine();
							if (str == null) break;
							s += str + "\n";
						}
						LR.close();
						EditText editor = findViewById(R.id.editor);
						editor.setText(s);
						_currentFile = file;
					}
					catch (Exception ex)
					{
						Toast.makeText(MainActivity.this, "Ошибка открытия файла", Toast.LENGTH_LONG);
					}
					_dialog.dismiss();
				}
			}
		});
		
		builder.setView(_filesListView);
		builder.setNegativeButton("Закрыть", null);
		return builder.create();
	}
	
	//проверяет готовность внешнего носителя для операций чтения/записи.
	public  boolean isExternalStorageWritable()
	{
		String state = Environment.getExternalStorageState();
		return (state.equals(Environment.MEDIA_MOUNTED));
	}
	//Проверяет готовность вншнего носителя для операции чтения.
	public  boolean isExternalStorageReadable()
	{
		String state = Environment.getExternalStorageState();
		return (state.equals(Environment.MEDIA_MOUNTED) || state.equals(Environment.MEDIA_MOUNTED_READ_ONLY));
	}
	
	private ArrayList<String> fillDirectory(File dir)
	{
		ArrayList<String> filesList = new ArrayList<>();
		if (isExternalStorageReadable())
		{
			File[] files = dir.listFiles();
			if (files != null)
			{
				for (File file : files)
				{
					if (file.isDirectory())
					{
						filesList.add("[" + file.getName() + "]");
					}
					else
					{
						filesList.add(file.getName());
					}
				}
			}
		}
		return filesList;
	}
}
