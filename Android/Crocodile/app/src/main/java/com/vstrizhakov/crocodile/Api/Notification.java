package com.vstrizhakov.crocodile.Api;

import com.vstrizhakov.crocodile.Constants;

import java.util.ArrayList;

public class Notification extends Package
{
	final static protected String[] _requiredHeaders = new String[]
			{
					Constants.Protocol.Header.ACTION
			};
	
	public String getAction()
	{
		return getHeader(Constants.Protocol.Header.ACTION).getValue();
	}
	
	protected Notification(ArrayList<Header> headers, String jsonData)
	{
		super(headers, jsonData);
	}
	
	static public Notification fromPackage(Package pkg) throws Exception
	{
		for (String header : _requiredHeaders)
		{
			if (pkg.getHeader(header).getValue().isEmpty())
			{
				throw new Exception("Required header " + header + " is missing");
			}
		}
		return new Notification(pkg._headers, pkg._jsonData);
	}
	
	public boolean isError()
	{
		return _jsonData.contains("\"message\"");
	}
}
