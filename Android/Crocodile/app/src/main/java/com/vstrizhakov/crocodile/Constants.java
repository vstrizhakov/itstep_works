package com.vstrizhakov.crocodile;

public class Constants
{
	public class Protocol
	{
		final static public String NAME = "CAPIP";
		final static public String EMPTY_LINE = "\r\n\r\n";
		final static public String END_OF_LINE = "\r\n";
		
		public class Version
		{
			final static public String TEST = "0.0";
			
			final static public String CURRENT = TEST;
		}
		
		public class Type
		{
			final static public String REQUEST = "Request";
			final static public String RESPONSE = "Response";
			final static public String NOTIFICATION = "Notification";
		}
		
		public class Header
		{
			final static public String NAME = "Name";
			final static public String VERSION = "Version";
			final static public String TYPE = "Type";
			final static public String METHOD_PATH = "Method-Path";
			final static public String RESULT_STRING = "Result-String";
			final static public String ACTION = "Action";
		}
		
		public class Result
		{
			final static public String OK = "Ok";
			final static public String ERROR = "Error";
		}
		
		public class Notification
		{
			final static public String ROOM_CREATED = "ROOM_CREATED";
			final static public String STROKE_ADDED = "STROKE_ADDED";
			
			public class Auth
			{
				final static public String GET_AUTH_TOKEN_RESPONSE = "GET_AUTH_TOKEN_RESPONSE";
				final static public String CHECK_AUTH_TOKEN_RESPONSE = "CHECK_AUTH_TOKEN_RESPONSE";
			}
			
			public class Users
			{
				final static public String GET_USER_RESPONSE = "GET_USER_RESPONSE";
			}
			
			public class Rooms
			{
				final static public String USER_ENTERED_ROOM = "USER_ENTERED_ROOM";
				final static public String USER_LEAVED_ROOM = "USER_LEAVED_ROOM";
			}
		}
		
		public class Request
		{
			public class Auth
			{
				final static private String ROOT = "auth.";
				
				final static public String GET_AUTH_TOKEN = ROOT + "get_auth_token";
				final static public String CHECK_AUTH_TOKEN = ROOT + "check_auth_token";
			}
			
			public class Users
			{
				final static private String ROOT = "users.";
				
				final static public String GET_USER = ROOT + "get_user";
			}
			
			public class Rooms
			{
				final static private String ROOT = "rooms.";
				
				final static public String START_SEARCHING_ROOM = ROOT + "enter_searching_room_queue";
				final static public String STOP_SEARCHING_ROOM = ROOT + "leave_searching_room_queue";
			}
		}
	}
}
