package com.vstrizhakov.crocodile.Network;

public interface INetworkConnectionListener
{
	void onNetworkDataReceived(byte[] data);
	void onNetworkConnectionLost();
}
