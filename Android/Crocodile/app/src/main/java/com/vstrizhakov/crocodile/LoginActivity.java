package com.vstrizhakov.crocodile;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.vstrizhakov.crocodile.Api.Models.AuthTokenResponse;
import com.vstrizhakov.crocodile.Api.Models.Error;
import com.vstrizhakov.crocodile.Helpers.GsonHelper;
import com.vstrizhakov.crocodile.Api.Notification;
import com.vstrizhakov.crocodile.Api.Request;
import com.vstrizhakov.crocodile.Api.Models.UserCredentials;
import com.vstrizhakov.crocodile.Managers.UserManager;
import com.vstrizhakov.crocodile.Network.INotificationListener;

public class LoginActivity extends BaseActivity implements INotificationListener
{
	//region Constants
	
	final static private String STATE_IDENTIFIER = "state";
	
	final static private int STATE_NONE = 0;
	final static private int STATE_LOGIN = 1;
	final static private int STATE_REGISTER = 2;
	
	//endregion
	
	//region Private Fields
	
	//region UI
	
	private LinearLayout _mainForm;
	private LinearLayout _form;
	private Button _applyFormButton;
	private EditText _nicknameField;
	private EditText _passwordField;
	private TextView _errorLabel;
	
	//endregion
	
	private int _state = STATE_NONE;
	
	//endregion
	
	//region
	
	//region Life Cycle
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_login);

		//region UI
		
		_mainForm = findViewById(R.id.main_form);
		_form = findViewById(R.id.form);
		_applyFormButton = findViewById(R.id.applyFormButton);
		_nicknameField = findViewById(R.id.nicknameField);
		_passwordField = findViewById(R.id.passwordField);
		_errorLabel = findViewById(R.id.errorLabel);
		
		//endregion
	}

	@Override
	protected void onServiceConnected()
	{
		addOnPackageReceivedListener(Constants.Protocol.Notification.Auth.GET_AUTH_TOKEN_RESPONSE, this);
		addOnPackageReceivedListener(Constants.Protocol.Notification.Auth.CHECK_AUTH_TOKEN_RESPONSE, this);

		String authToken = UserManager.getInstance().getSavedAuthToken(this);
		if (authToken != null)
		{
			sendMessage(Request.fromMethodPathAndString(Constants.Protocol.Request.Auth.CHECK_AUTH_TOKEN, "{\"token\":\"" + authToken + "\"}"));
		}
	}

	@Override
	protected void onServiceDisconnected()
	{
		removeOnPackageReceivedListener(Constants.Protocol.Notification.Auth.GET_AUTH_TOKEN_RESPONSE, this);
		removeOnPackageReceivedListener(Constants.Protocol.Notification.Auth.CHECK_AUTH_TOKEN_RESPONSE, this);
	}
	
	@Override
	public void onSaveInstanceState(Bundle bundle)
	{
		super.onSaveInstanceState(bundle);
		bundle.putInt(STATE_IDENTIFIER, _state);
	}
	
	@Override
	public void onRestoreInstanceState(Bundle bundle)
	{
		super.onRestoreInstanceState(bundle);
		int state = bundle.getInt(STATE_IDENTIFIER, STATE_NONE);
		setState(state);
	}
	
	//endregion
	
	//region Private Methods
	
	private void setState(int state)
	{
		switch (state)
		{
			case STATE_LOGIN:
				_mainForm.setVisibility(View.GONE);
				_form.setVisibility(View.VISIBLE);
				_applyFormButton.setText(R.string.enter_account);
				break;
			case STATE_REGISTER:
				_mainForm.setVisibility(View.GONE);
				_form.setVisibility(View.VISIBLE);
				_applyFormButton.setText(R.string.register_account);
				break;
			case STATE_NONE:
			default:
				state = STATE_NONE;
				_mainForm.setVisibility(View.VISIBLE);
				_form.setVisibility(View.GONE);
				_errorLabel.setVisibility(View.GONE	);
				_nicknameField.setText("");
				_passwordField.setText("");
				_errorLabel.setText("");
				break;
		}
		_state = state;
	}
	
	private void navigateOnMainActivity()
	{
		Intent intent = new Intent(getApplicationContext(), MainActivity.class);
		intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
		startActivity(intent);
	}
	
	//endregion
	
	//region Callbacks
	
	public void toFormClicked(View view)
	{
		setState((view.getId() == R.id.enterButton) ? STATE_LOGIN : STATE_REGISTER);
	}
	
	public void onFormCanceled(View view)
	{
		setState(STATE_NONE);
	}
	
	public void onFormApplied(View view)
	{
		UserCredentials uc = new UserCredentials(_nicknameField.getText().toString(), _passwordField.getText().toString());
		Request request = Request.fromMethodPathAndObject(Constants.Protocol.Request.Auth.GET_AUTH_TOKEN, uc);
		sendMessage(request);
	}
	
	@Override
	public void onPackageReceived(Notification notification)
	{
		if (notification.getAction().contentEquals(Constants.Protocol.Notification.Auth.GET_AUTH_TOKEN_RESPONSE))
		{
			final Object authTokenResponse = GsonHelper.deserializeNotification(notification, AuthTokenResponse.class);
			final boolean isSuccessful = authTokenResponse instanceof AuthTokenResponse;
			if (isSuccessful)
			{
				AuthTokenResponse authToken = (AuthTokenResponse)authTokenResponse;
				UserManager.getInstance().setAuthToken(this, authToken.token);
			}
			runOnUiThread(new Runnable()
			{
				@Override
				public void run()
				{
					if (!isSuccessful)
					{
						Error error = (Error)authTokenResponse;
						_errorLabel.setText(error.message);
						_errorLabel.setVisibility(View.VISIBLE);
					}
					else
					{
						navigateOnMainActivity();
					}
				}
			});
		}
		else if (notification.getAction().contentEquals(Constants.Protocol.Notification.Auth.CHECK_AUTH_TOKEN_RESPONSE))
		{
			final Object authTokenResponse = GsonHelper.deserializeNotification(notification, AuthTokenResponse.class);
			final boolean isSuccessful = authTokenResponse instanceof AuthTokenResponse;
			if (isSuccessful)
			{
				AuthTokenResponse authToken = (AuthTokenResponse)authTokenResponse;
				UserManager.getInstance().setAuthToken(this, authToken.token);
				runOnUiThread(new Runnable()
				{
					@Override
					public void run()
					{
						navigateOnMainActivity();
					}
				});
			}
		}
	}
	
	//endregion
}
