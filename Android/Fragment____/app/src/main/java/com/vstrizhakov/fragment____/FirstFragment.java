package com.vstrizhakov.fragment____;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class FirstFragment extends Fragment
{
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		View view = inflater.inflate(R.layout.first_fragment, container, false);
		Button btnFirst = view.findViewById(R.id.btnFirst);
		btnFirst.setOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				EditText editor = FirstFragment.this.getActivity().findViewById(R.id.edtFirst);
				Toast.makeText(FirstFragment.this.getActivity(), editor.getText(), Toast.LENGTH_LONG);
			}
		});
		return view;
	}
}
