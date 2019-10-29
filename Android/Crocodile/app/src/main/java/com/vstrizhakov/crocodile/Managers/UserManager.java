package com.vstrizhakov.crocodile.Managers;

import android.content.Context;

import com.vstrizhakov.crocodile.Helpers.FileSystemHelper;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FilenameFilter;
import java.io.IOException;

public class UserManager
{
	//region Singleton
	
	final static private UserManager ourInstance = new UserManager();
	static public UserManager getInstance()
	{
		return ourInstance;
	}

	//endregion
	
	//region Constants
	
	final static private String DIRECTORY = "user_data";
	final static private String AUTH_TOKEN_FILE = "auth_token.dat";
	
	final static public int NON_AUTHORIZED = 0;
	final static public int AUTHORIZED = 1;
	
	//endregion
	
	//region Private Fields
	
	private String _authToken;
	private int _state = NON_AUTHORIZED;
	
	//endregion
	
	//region Life Cycle
	
	private UserManager()
	{
	}
	
	//endregion
	
	//region Public Methods
	
	public String getSavedAuthToken(Context context)
	{
		String authToken = null;
		
		File userDataDirectory = context.getDir(DIRECTORY, Context.MODE_PRIVATE);
		File authTokenFile = FileSystemHelper.getFileFromDir(userDataDirectory, AUTH_TOKEN_FILE);
		if (authTokenFile != null)
		{
			try
			{
				FileInputStream fileInputStream = new FileInputStream(authTokenFile);
				DataInputStream dataInputStream = new DataInputStream(fileInputStream);
				authToken = dataInputStream.readUTF();
				dataInputStream.close();
			}
			catch (FileNotFoundException fileNotFoundException)
			{
			
			}
			catch (IOException ioException)
			{
			
			}
		}
		return authToken;
	}
	
	public void setAuthToken(Context context, String authToken)
	{
		_authToken = authToken;
		File userDataDirectory = context.getDir(DIRECTORY, Context.MODE_PRIVATE);
		File authTokenFile = FileSystemHelper.getFileFromDir(userDataDirectory, AUTH_TOKEN_FILE, FileSystemHelper.MODE_CREATE_IF_NOT_EXISTS);
		try
		{
			FileOutputStream fileOutputStream = new FileOutputStream(authTokenFile);
			DataOutputStream dataOutputStream = new DataOutputStream(fileOutputStream);
			dataOutputStream.writeUTF(_authToken);
			dataOutputStream.close();
		}
		catch (FileNotFoundException fileNotFoundException)
		{

		}
		catch (IOException ioException)
		{

		}
	}
	
	public String getAuthToken()
	{
		return _authToken;
	}
	
	//endregion
}
