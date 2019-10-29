package com.vstrizhakov.fragment____;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class CalcFragment extends Fragment implements View.OnClickListener
{
	private EditText edtOne;
	private EditText edtTwo;
	private TextView tvResult;
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup containter, Bundle savedInstanceState)
	{
		View view = inflater.inflate(R.layout.calc_fragment, containter, false);
		
		edtOne = view.findViewById(R.id.edtOne);
		edtTwo = view.findViewById(R.id.edtTwo);
		tvResult = view.findViewById(R.id.edtRes);
		
		view.findViewById(R.id.btnPlus).setOnClickListener(this);
		view.findViewById(R.id.btnMinus).setOnClickListener(this);
		view.findViewById(R.id.btnDivide).setOnClickListener(this);
		view.findViewById(R.id.btnMultiply).setOnClickListener(this);
		return view;
	}
	
	@Override
	public void onClick(View view)
	{
		try
		{
			double one = Double.parseDouble(this.edtOne.getText().toString());
			double two = Double.parseDouble(this.edtTwo.getText().toString());
			double result = 0;
			switch (view.getId())
			{
				case R.id.btnPlus:
					result = one+two;
					break;
				case R.id.btnMinus:
					result = one-two;
					break;
				case R.id.btnMultiply:
					result = one*two;
					break;
				case R.id.btnDivide:
					result = one/two;
					break;
			}
			this.tvResult.setText(String.valueOf(result));
		}
		catch (Exception e)
		{
			Toast.makeText(this.getActivity(), e.getMessage(), Toast.LENGTH_SHORT).show();
		}
	}
}
