package com.vstrizhakov.contentdialogs;

import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

public class DialogFragmentOne extends DialogFragment implements View.OnClickListener
{
	public final static String DIALOGONE_LASTNAME = "dialog_one_lastname";
	public final static String DIALOGONE_FIRSTNAME = "dialog_one_firstname";
	
	private EditText edtLastName;
	private EditText edtFirstName;
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		View view = inflater.inflate(R.layout.dialog_one_fragment, container, false);
		view.findViewById(R.id.btnApply).setOnClickListener(this);
		view.findViewById(R.id.btnCancel).setOnClickListener(this);
		edtLastName = view.findViewById(R.id.edtLastName);
		edtFirstName = view.findViewById(R.id.edtFirstName);
		
		Bundle bundleArgs = getArguments();
		if (bundleArgs.containsKey(DialogFragmentOne.DIALOGONE_LASTNAME))
		{
			TextView tv = getActivity().findViewById(bundleArgs.getInt(DialogFragmentOne.DIALOGONE_LASTNAME));
			edtLastName.setText(tv.getText());
		}
		
		if (bundleArgs.containsKey(DialogFragmentOne.DIALOGONE_FIRSTNAME))
		{
			TextView tv = getActivity().findViewById(bundleArgs.getInt(DialogFragmentOne.DIALOGONE_FIRSTNAME));
			edtLastName.setText(tv.getText());
		}
		
		return view;
	}
	
	@Override
	public void onClick(View view)
	{
		switch (view.getId())
		{
			case R.id.btnApply:
				Bundle bundleArgs = getArguments();
				if (bundleArgs.containsKey(DialogFragmentOne.DIALOGONE_LASTNAME))
				{
					TextView textView = getActivity().findViewById(bundleArgs.getInt(DialogFragmentOne.DIALOGONE_LASTNAME));
					textView.setText(edtLastName.getText());
				}
				if (bundleArgs.containsKey(DialogFragmentOne.DIALOGONE_FIRSTNAME))
				{
					TextView textView = getActivity().findViewById(bundleArgs.getInt(DialogFragmentOne.DIALOGONE_FIRSTNAME));
					textView.setText(edtFirstName.getText());
				}
				edtLastName.setText("");
				edtFirstName.setText("");
				dismiss();
				break;
			case R.id.btnCancel:
				dismiss();
				break;
		}
	}
}
