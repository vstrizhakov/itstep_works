package com.vstrizhakov.contentdialogs;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.text.Layout;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.zip.Inflater;

public class DialogFragmentTwo extends DialogFragment
{
	public final static String DIALOGTWO_HEIGHT = "dialog_two_height";
	public final static String DIALOGTWO_WEIGHT = "dialog_two_weight";
	
	private EditText edtHeight;
	private EditText edtWeight;
	
	@Override
	public Dialog onCreateDialog(Bundle saveInstanceState)
	{
		LayoutInflater inflater = getActivity().getLayoutInflater();
		View view = inflater.inflate(R.layout.layout_two, null, false);
		AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
		builder.setTitle("Укажите рост и вес");
		builder.setView(view);
		
		edtHeight = view.findViewById(R.id.edtHeight);
		edtWeight = view.findViewById(R.id.edtWeight);
		
		builder.setNegativeButton("Отменить",
				new DialogInterface.OnClickListener()
				{
					@Override
					public void onClick(DialogInterface dialog, int which)
					{
					}
				});
		
		builder.setPositiveButton("Применить",
				new DialogInterface.OnClickListener()
				{
					@Override
					public void onClick(DialogInterface dialog, int which)
					{
						Bundle bundleArgs = DialogFragmentTwo.this.getArguments();
						if (bundleArgs.containsKey(DialogFragmentTwo.DIALOGTWO_HEIGHT))
						{
							TextView textView = DialogFragmentTwo.this.getActivity().findViewById(bundleArgs.getInt(DialogFragmentTwo.DIALOGTWO_HEIGHT));
							textView.setText(edtHeight.getText());
						}
						if (bundleArgs.containsKey(DialogFragmentTwo.DIALOGTWO_WEIGHT))
						{
							TextView textView = DialogFragmentTwo.this.getActivity().findViewById(bundleArgs.getInt(DialogFragmentTwo.DIALOGTWO_WEIGHT));
							textView.setText(edtWeight.getText());
						}
					}
				});
		
		Bundle bundleArgs = getArguments();
		if (bundleArgs.containsKey(DialogFragmentTwo.DIALOGTWO_HEIGHT))
		{
			TextView textView = getActivity().findViewById(bundleArgs.getInt(DialogFragmentTwo.DIALOGTWO_HEIGHT));
			edtHeight.setText(textView.getText());
		}
		if (bundleArgs.containsKey(DialogFragmentTwo.DIALOGTWO_WEIGHT))
		{
			TextView textView = getActivity().findViewById(bundleArgs.getInt(DialogFragmentTwo.DIALOGTWO_WEIGHT));
			edtWeight.setText(textView.getText());
		}
		return builder.create();
	}
}
