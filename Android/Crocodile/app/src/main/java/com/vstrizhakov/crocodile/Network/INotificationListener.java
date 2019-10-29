package com.vstrizhakov.crocodile.Network;

import com.vstrizhakov.crocodile.Api.Notification;

public interface INotificationListener
{
	void onPackageReceived(Notification notification);
}
