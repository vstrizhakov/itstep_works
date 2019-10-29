package com.vstrizhakov.crocodile;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.vstrizhakov.crocodile.Api.Models.AuthTokenResponse;
import com.vstrizhakov.crocodile.Helpers.GsonHelper;
import com.vstrizhakov.crocodile.Api.Notification;
import com.vstrizhakov.crocodile.Api.Request;
import com.vstrizhakov.crocodile.Api.Models.User;
import com.vstrizhakov.crocodile.Managers.UserManager;
import com.vstrizhakov.crocodile.Network.INotificationListener;

public class MainActivity extends BaseActivity implements INotificationListener
{
	private TextView _nickname;
	private Button _searchGameButton;
	private LinearLayout _loadingLayout;
	private ListView _waitingPlayersList;
	
	private ArrayAdapter<String> _adapter;
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		_nickname = findViewById(R.id.nickname);
		_searchGameButton = findViewById(R.id.searchGameButton);
		_loadingLayout= findViewById(R.id.loadingLayout);
		_waitingPlayersList = findViewById(R.id.waitingPlayersList);
		
		_adapter = new ArrayAdapter<>(this, R.layout.support_simple_spinner_dropdown_item);
		_waitingPlayersList.setAdapter(_adapter);
	}

	@Override
	protected void onServiceConnected()
	{
		addOnPackageReceivedListener(Constants.Protocol.Notification.Users.GET_USER_RESPONSE, this);
		addOnPackageReceivedListener(Constants.Protocol.Notification.Rooms.USER_ENTERED_ROOM, this);
		addOnPackageReceivedListener(Constants.Protocol.Notification.Rooms.USER_LEAVED_ROOM, this);

		AuthTokenResponse authToken = new AuthTokenResponse();
		authToken.token = UserManager.getInstance().getAuthToken();
		sendMessage(Request.fromMethodPathAndObject(Constants.Protocol.Request.Users.GET_USER, authToken));
	}

	@Override
	protected void onServiceDisconnected()
	{
		removeOnPackageReceivedListener(Constants.Protocol.Notification.Users.GET_USER_RESPONSE, this);
		removeOnPackageReceivedListener(Constants.Protocol.Notification.Rooms.USER_LEAVED_ROOM, this);
		removeOnPackageReceivedListener(Constants.Protocol.Notification.Rooms.USER_ENTERED_ROOM, this);
	}
	
	@Override
	public void onPackageReceived(Notification notification)
	{
		if (notification.getAction().contentEquals(Constants.Protocol.Notification.Users.GET_USER_RESPONSE))
		{
			final Object userResponse = GsonHelper.deserializeNotification(notification, User.class);
			final boolean isSuccessful = userResponse instanceof User;
			runOnUiThread(new Runnable()
			{
				@Override
				public void run()
				{
					if (isSuccessful)
					{
						_nickname.setText(((User)userResponse).nickname);
					}
				}
			});
		}
		else if (notification.getAction().contentEquals(Constants.Protocol.Notification.Rooms.USER_ENTERED_ROOM))
		{
			final Object userResponse = GsonHelper.deserializeNotification(notification, User.class);
			final boolean isSuccessful = userResponse instanceof User;
			runOnUiThread(new Runnable()
			{
				@Override
				public void run()
				{
					if (isSuccessful)
					{
						_adapter.add(((User)userResponse).nickname);
						_adapter.notifyDataSetChanged();
					}
				}
			});
		}
		else if (notification.getAction().contentEquals(Constants.Protocol.Notification.Rooms.USER_LEAVED_ROOM))
		{
			final Object userResponse = GsonHelper.deserializeNotification(notification, User.class);
			final boolean isSuccessful = userResponse instanceof User;
			runOnUiThread(new Runnable()
			{
				@Override
				public void run()
				{
					if (isSuccessful)
					{
						_adapter.remove(((User)userResponse).nickname);
						_adapter.notifyDataSetChanged();
					}
				}
			});
		}
	}
	
	public void onSearchGameButtonClick(View view)
	{
		sendMessage(Request.fromMethodPathAndString(Constants.Protocol.Request.Rooms.START_SEARCHING_ROOM, "{\"search_as\":1}"));
		
		_searchGameButton.setVisibility(View.GONE);
		_loadingLayout.setVisibility(View.VISIBLE);
		_waitingPlayersList.setVisibility(View.VISIBLE);
	}
	
	public void onCancelSearchGameButtonClick(View view)
	{
		sendMessage(Request.fromMethodPathAndObject(Constants.Protocol.Request.Rooms.STOP_SEARCHING_ROOM, null));
		
		_loadingLayout.setVisibility(View.GONE);
		_waitingPlayersList.setVisibility(View.INVISIBLE);
		_searchGameButton.setVisibility(View.VISIBLE);
	}
}
