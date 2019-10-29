package com.vstrizhakov.crocodile.Network;

import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;

public abstract class NetworkConnection
{
	private Socket _socket;
	private ByteArrayOutputStream _memoryStream;
	private DataInputStream _socketInputStream;
	private DataOutputStream _socketOutputStream;
	private byte[] _buf;
	
	public NetworkConnection()
	{
		_memoryStream = new ByteArrayOutputStream();
		_buf = new byte[2048];
	}

	public void initialize(Socket socket) throws IOException
	{
		_socket = socket;
		_socketInputStream = new DataInputStream(_socket.getInputStream());
		_socketOutputStream = new DataOutputStream(_socket.getOutputStream());
	}
	
	private int readMessageSize() throws IOException
	{
		final int sizeOfInt = 4;
		byte[] buf = new byte[sizeOfInt];
		int totalReadCount = 0;
		do
		{
			int readCount = _socketInputStream.read(buf, totalReadCount, sizeOfInt);
			if (readCount == -1)
			{
				throw new IOException("Zero bytes received");
			}
			totalReadCount += readCount;
		} while (totalReadCount < sizeOfInt);
		return ByteBuffer.wrap(buf).order(ByteOrder.nativeOrder()).getInt();
	}
	
	protected byte[] readMessage() throws IOException
	{
		int messageSize = readMessageSize();
		_memoryStream.reset();
		while (_memoryStream.size() < messageSize)
		{
			int countToRead = Math.min(_buf.length, messageSize - _memoryStream.size());
			int readCount = _socketInputStream.read(_buf, 0, countToRead);
			if (readCount == -1)
			{
				throw new IOException();
			}
			_memoryStream.write(_buf, 0, readCount);
		}
		return _memoryStream.toByteArray();
	}
	
	private void writeMessageSize(int messageSize) throws IOException
	{
		byte[] buf = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(messageSize).array();
		_socketOutputStream.write(buf, 0, buf.length);
	}
	
	protected void writeMessage(byte[] message) throws IOException
	{
		writeMessageSize(message.length);
		_socketOutputStream.write(message, 0, message.length);
	}
	
	public void close()
	{
		try
		{
			_memoryStream.close();
			_socketOutputStream.close();
			_socketInputStream.close();
			_socket.close();
		}
		catch (IOException ioException)
		{
		
		}
	}
}
