package com.vstrizhakov.crocodile.Api;

import com.google.gson.Gson;
import com.vstrizhakov.crocodile.Constants;
import com.vstrizhakov.crocodile.Helpers.GsonHelper;

import java.util.ArrayList;

public class Request extends Package
{
	final static protected String[] _requiredHeaders = new String[]
			{
				Constants.Protocol.Header.METHOD_PATH
			};
	
	protected Request(ArrayList<Header> headers, String jsonData)
	{
		super(headers, jsonData);
	}
	
	public String getMethodPath()
	{
		return getHeader(Constants.Protocol.Header.METHOD_PATH).getValue();
	}
	
	static public Request fromMethodPathAndObject(String methodPath, Object object)
	{
		ArrayList<Header> headers = new ArrayList<>();
		headers.add(new Header(Constants.Protocol.Header.NAME, Constants.Protocol.NAME));
		headers.add(new Header(Constants.Protocol.Header.VERSION, Constants.Protocol.Version.CURRENT));
		headers.add(new Header(Constants.Protocol.Header.TYPE, Constants.Protocol.Type.REQUEST));
		headers.add(new Header(Constants.Protocol.Header.METHOD_PATH, methodPath));
		
		return new Request(headers, (object == null) ? "" : GsonHelper.serializeObject(object));
	}
	
	static public Request fromMethodPathAndString(String methodPath, String string)
	{
		
		ArrayList<Header> headers = new ArrayList<>();
		headers.add(new Header(Constants.Protocol.Header.NAME, Constants.Protocol.NAME));
		headers.add(new Header(Constants.Protocol.Header.VERSION, Constants.Protocol.Version.CURRENT));
		headers.add(new Header(Constants.Protocol.Header.TYPE, Constants.Protocol.Type.REQUEST));
		headers.add(new Header(Constants.Protocol.Header.METHOD_PATH, methodPath));
		
		return new Request(headers, string);
	}
	
	static public Request fromPackage(Package pkg) throws Exception
	{
		for (String header : _requiredHeaders)
		{
			if (pkg.getHeader(header).getValue().isEmpty())
			{
				throw new Exception("Required header " + header + " is missing");
			}
		}
		return new Request(pkg._headers, pkg._jsonData);
	}
}
