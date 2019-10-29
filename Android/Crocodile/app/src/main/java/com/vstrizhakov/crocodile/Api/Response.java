package com.vstrizhakov.crocodile.Api;

import com.google.gson.Gson;
import com.vstrizhakov.crocodile.Api.Models.Error;
import com.vstrizhakov.crocodile.Constants;
import com.vstrizhakov.crocodile.Helpers.GsonHelper;

import java.util.ArrayList;

public class Response extends Package
{
	final static protected String[] _requiredHeaders = new String[]
			{
					Constants.Protocol.Header.RESULT_STRING
			};
	
	protected Response(ArrayList<Header> headers, String jsonData)
	{
		super(headers, jsonData);
	}
	
	public String getResultString()
	{
		return getHeader(Constants.Protocol.Header.RESULT_STRING).getValue();
	}
	
	static public Request SuccessfullFromObject(Object object)
	{
		ArrayList<Header> headers = new ArrayList<>();
		headers.add(new Header(Constants.Protocol.Header.NAME, Constants.Protocol.NAME));
		headers.add(new Header(Constants.Protocol.Header.VERSION, Constants.Protocol.Version.CURRENT));
		headers.add(new Header(Constants.Protocol.Header.TYPE, Constants.Protocol.Type.REQUEST));
		headers.add(new Header(Constants.Protocol.Header.RESULT_STRING, Constants.Protocol.Result.OK));
		
		Gson gson = new Gson();
		return new Request(headers, (object == null) ? "" : gson.toJson(object));
	}
	
	static public Request FailureWithError(Error error)
	{
		ArrayList<Header> headers = new ArrayList<>();
		headers.add(new Header(Constants.Protocol.Header.NAME, Constants.Protocol.NAME));
		headers.add(new Header(Constants.Protocol.Header.VERSION, Constants.Protocol.Version.CURRENT));
		headers.add(new Header(Constants.Protocol.Header.TYPE, Constants.Protocol.Type.REQUEST));
		headers.add(new Header(Constants.Protocol.Header.RESULT_STRING, Constants.Protocol.Result.ERROR));
		
		return new Request(headers, GsonHelper.serializeObject(error));
	}
	
	static public Response fromPackage(Package pkg) throws Exception
	{
		for (String header : _requiredHeaders)
		{
			if (pkg.getHeader(header).getValue().isEmpty())
			{
				throw new Exception("Required header " + header + " is missing");
			}
		}
		return new Response(pkg._headers, pkg._jsonData);
	}
}
