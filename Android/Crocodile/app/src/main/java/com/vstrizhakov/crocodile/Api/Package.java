package com.vstrizhakov.crocodile.Api;

import com.vstrizhakov.crocodile.Constants;

import java.util.ArrayList;

public class Package
{
	final static protected String[] _requiredHeaders = new String[]
			{
					Constants.Protocol.Header.NAME,
					Constants.Protocol.Header.VERSION,
					Constants.Protocol.Header.TYPE
			};
	
	protected String _jsonData;
	
	protected ArrayList<Header> _headers;
	
	protected Package(ArrayList<Header> headers, String jsonData)
	{
		_headers = headers;
		_jsonData = jsonData;
	}
	
	protected Header getHeader(String key)
	{
		Header resultHeader = null;
		for (Header header : _headers)
		{
			if (header.getKey().contentEquals(key))
			{
				resultHeader = header;
			}
		}
		return resultHeader;
	}
	
	public String getName()
	{
		return getHeader(Constants.Protocol.Header.NAME).getValue();
	}
	
	public String getVersion()
	{
		return getHeader(Constants.Protocol.Header.VERSION).getValue();
	}
	
	public String getType()
	{
		return getHeader(Constants.Protocol.Header.TYPE).getValue();
	}
	
	public String getJsonData()
	{
		return _jsonData;
	}
	
	static public Package fromString(String str) throws Exception
	{
		int emptyLineIndex = str.indexOf(Constants.Protocol.EMPTY_LINE);
		
		String headersSection = str.substring(0, emptyLineIndex);
		String dataSection = str.substring(emptyLineIndex + Constants.Protocol.EMPTY_LINE.length());
		
		String[] headerLines = headersSection.split(Constants.Protocol.END_OF_LINE);
		
		ArrayList<Header> headers = new ArrayList<>();
		for (String headerLine : headerLines)
		{
			String[] keyValue = headerLine.split(": ");
			String key = keyValue[0];
			String value = keyValue[1];
			Header header = new Header(key, value);
			
			headers.add(header);
		}
		
		for (String headerKey : _requiredHeaders)
		{
			boolean hasHeader = false;
			for (Header header : headers)
			{
				if (header.getKey().contentEquals(headerKey))
				{
					hasHeader = true;
					break;
				}
			}
			if (!hasHeader)
			{
				throw new Exception("Required header " + headerKey + " is missing");
			}
		}
		return new Package(headers, dataSection);
	}
	
	@Override
	public String toString()
	{
		String result = "";
		for (Header header : _headers)
		{
			result += String.format("%s: %s%s", header.getKey(), header.getValue(), Constants.Protocol.END_OF_LINE);
		}
		result += String.format("%s%s", Constants.Protocol.END_OF_LINE, _jsonData);
		return result;
	}
}
