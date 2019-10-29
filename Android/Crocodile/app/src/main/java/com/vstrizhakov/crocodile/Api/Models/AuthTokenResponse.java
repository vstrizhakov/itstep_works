package com.vstrizhakov.crocodile.Api.Models;

import java.sql.Time;
import java.util.Date;

public class AuthTokenResponse
{
	public String token;
	public long lifetime;
	public Date created_at;
	
	public AuthTokenResponse()
	{
	
	}
}
