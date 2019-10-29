package com.example.android_13_1_fragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class CalcFragment extends Fragment implements View.OnClickListener
{
    private final static String TAG = "===== CalcFragment";

    private EditText edtOne;
    private EditText edtTwo;
    private TextView tvResult;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        Log.d(TAG, "---- onCreateView");
        View v = inflater.inflate(R.layout.calc_fragment, container, false);

        this.edtOne = v.findViewById(R.id.edtOne);
        this.edtTwo = v.findViewById(R.id.edtTwo);
        this.tvResult = v.findViewById(R.id.edtRes);

        (v.findViewById(R.id.btnPlus)).setOnClickListener(this);
        (v.findViewById(R.id.btnMinus)).setOnClickListener(this);
        (v.findViewById(R.id.btnDivide)).setOnClickListener(this);
        (v.findViewById(R.id.btnMultiply)).setOnClickListener(this);

        return v;
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
