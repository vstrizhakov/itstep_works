package com.vstrizhakov.crocodile.Helpers;

import java.io.File;

public class FileSystemHelper
{
	//region Constants
	
	final static public int MODE_NONE = 0;
	final static public int MODE_CREATE_IF_NOT_EXISTS = 1;
	
	//endregion
	
	static public File getFileFromDir(File dir, String name)
	{
		return getFileFromDir(dir, name, MODE_NONE);
	}
	
	static public File getFileFromDir(File dir, String name, int mode)
	{
		if (mode != MODE_NONE
			&& mode != MODE_CREATE_IF_NOT_EXISTS)
		{
			throw new IllegalArgumentException();
		}
		File result = null;
		if (dir.isDirectory())
		{
			File[] childFiles = dir.listFiles();
			if (childFiles != null)
			{
				for (File file : childFiles)
				{
					if (file.isFile() && file.getName().contentEquals(name))
					{
						result = file;
						break;
					}
				}
			}
			if (result == null && mode == MODE_CREATE_IF_NOT_EXISTS)
			{
				result = new File(dir, name);
			}
		}
		return result;
	}
}
