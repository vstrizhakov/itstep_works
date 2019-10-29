@package com.example.android_13_1_fragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class FirstFragment extends Fragment
{
    private final static String TAG = "==== FirstFragment";
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle saveInstanceState)
    {
        Log.d(TAG, "OnCreateView");
        View v = inflater.inflate(R.layout.first_fragment, container, false);
        Button btnFirst = (Button) v.findViewById(R.id.btnFirst);
        btnFirst.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                Log.d(TAG, "onClick");
                EditText editFirst = FirstFragment.this.getActivity().findViewById(R.id.edtFirst);
                Toast.makeText(FirstFragment.this.getActivity(), editFirst.getText().toString(), Toast.LENGTH_LONG).show();

                //----Програмное добавление  фрагмента в Активность
            }
        });
        return v;
    }
}
