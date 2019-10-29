package com.vstrizhakov.crocodile.Helpers;

import android.os.Environment;
import android.util.Log;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Calendar;

public class LogHelper
{
    final static private String TAG = "CrocodileLogger";
    final static private String LOGS_FILE_NAME = "logs.txt";

    final static private LogHelper _instance = new LogHelper();

    private boolean _isDebug = true;
    private boolean _isFileDebug = true;
    private File _logsFile;

    static public LogHelper getInstance()
    {
        return _instance;
    }


    private LogHelper()
    {
        File logDirectory = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS);
        _logsFile = FileSystemHelper.getFileFromDir(logDirectory, LOGS_FILE_NAME, FileSystemHelper.MODE_CREATE_IF_NOT_EXISTS);
    }

    static public void log(String message)
    {
        if (getInstance()._isDebug)
        {
            Log.d(TAG, message);
        }
    }

    static public void log(Object sender, String message)
    {
        String resultMessage = "[" + Calendar.getInstance().getTime().toString() + "] " + sender.getClass().getName() + ": " + message;
        if (getInstance()._isDebug)
        {
            Log.d(TAG, resultMessage);
        }
        if (getInstance()._isFileDebug)
        {
            try
            {
                FileInputStream fileInputStream = new FileInputStream(getInstance()._logsFile);
                DataInputStream dataInputStream = new DataInputStream(fileInputStream);
                String existingText = "";
                try
                {
                    existingText = dataInputStream.readUTF();
                }
                catch (Exception ex)
                {
                }
                dataInputStream.close();
                FileOutputStream fileOutputStream = new FileOutputStream(getInstance()._logsFile);
                DataOutputStream dataOutputStream = new DataOutputStream(fileOutputStream);
                dataOutputStream.writeUTF(existingText + "\r\n" + resultMessage);
                dataOutputStream.close();
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Log.d(TAG, "log: " + fileNotFoundException.getMessage());
            }
            catch (IOException ioException)
            {
                Log.d(TAG, "log error: " + ioException.getClass().getSimpleName() + " " + ioException.getMessage());
            }
        }
    }

    public void setIsDebug(boolean isDebug)
    {
        _isDebug = isDebug;
    }

    public boolean getIsDebug()
    {
        return _isDebug;
    }
}
